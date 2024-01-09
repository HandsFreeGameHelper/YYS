using Newtonsoft.Json;
using NLog;
using NLog.Config;
using System.Data;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace ScreenCaptureApp.Utils;


public static class LoggerHelper
{
  private static readonly Logger logger = LogManager.GetCurrentClassLogger();

  static LoggerHelper() 
  {
    InitProperties();
  }
  public static Logger DefualtLogger
  {
    get { return logger; } 
  }

  public static void Logs(this Logger logger, LogLevel logLevel, string message) 
  {
    logger.Log(logLevel, message);
    Console.WriteLine(message);
  }

  public static void ZipLog() 
  {
    string logDirectory = LogManager.Configuration.Variables["logDirectory"].ToString()!;
    string logFilePath = Path.Combine(logDirectory, "sqlLog.sql");

    logger.Info("Start zip old logs.");

    // 压缩日志文件为 ZIP
    CompressLogFileToZip(logFilePath);
  }

  public static async void OnPostUpLoad() 
  {
    // 指定目录路径
    string directoryPath = @"Logs";

    // 获取目录中的所有 zip 文件
    string[] zipFiles = Directory.GetFiles(directoryPath, "*.zip");

    foreach (string filePath in zipFiles)
      {
        byte[] fileBytes = File.ReadAllBytes(filePath);
        string base64Content = Convert.ToBase64String(fileBytes);

        // Send base64 content to the server asynchronously
        await SendToServerAsync(base64Content, filePath);
      }
  }

  private async static Task<bool> SendToServerAsync(string base64Content,string filePath)
  {
    try
    {
      string url = Contains.LOGGINGSERVICE;
      var model = new OnPostUpLoadModel { Base64Content = base64Content };
      string jsonData = JsonConvert.SerializeObject(new[] { model });

      using (HttpClient client = new HttpClient())
      {
        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync(url, content);

        if (response.IsSuccessStatusCode)
        {
          string responseContent = await response.Content.ReadAsStringAsync();
          // Handle the server response, e.g., display it in a MessageBox
          logger.Logs(LogLevel.Info, $"Server Response: {responseContent}");
          File.Delete(filePath);
          return true;
        }
        else
        {
          // Handle non-success status codes
          logger.Logs(LogLevel.Warn, $"Warn: {response.StatusCode}");
        }
      }
    }
    catch (Exception ex)
    {
      // Handle exceptions, e.g., display an error message
      logger.Logs(LogLevel.Error, $"Error: {ex.Message}");
    }
    return false;
  }
  private static void InitProperties()
  {
    logger.Properties["request-ipv6"] = NetTools.GetLocalIPv6Address();
    ZipLog();
    OnPostUpLoad();
  }

  private static void CompressLogFileToZip(string filePath)
  {
    try
    {
      logger.ShutDown();

      string zipFilePath =$@"{filePath}_{DateTime.Now.ToString(@"yyyy_MM_dd_HH_mm_ss")}.zip";

      using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
      using (FileStream zipFileStream = new FileStream(zipFilePath, FileMode.Create, FileAccess.Write))
      using (ZipArchive zipArchive = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
      {
        // 将日志文件内容添加到 ZIP 文件
        var zipEntry = zipArchive.CreateEntry(Path.GetFileName(filePath));
        using (Stream entryStream = zipEntry.Open())
        {
          fileStream.CopyTo(entryStream);
        }
      }

      // 删除原始的非压缩日志文件
      File.Delete(filePath);
      EnableDefaultLogger();
      logger.Info($"日志文件已压缩至 {zipFilePath}");
    }
    catch (Exception e)
    {
      logger.Error(e.ToString());
    }
    finally 
    {
      EnableDefaultLogger();
      LogManager.Flush();
    }
  }

  private static void EnableLogger(this Logger logger,LogLevel logLevel)
  {
    var rules = LogManager.Configuration.LoggingRules;

    // 遍历规则，找到与传入的 Logger 相关的规则并更改其日志级别
    foreach (LoggingRule rule in rules)
    {
      if (rule.LoggerNamePattern == logger.Name)
      {
        rule.EnableLoggingForLevel(logLevel);
        break;
      }
    }
  }
  private static void ShutDown(this Logger logger) 
  {
    logger.Factory.Shutdown();
  }
  private static void EnableDefaultLogger() 
  {
    LogManager.Configuration = new XmlLoggingConfiguration(@"./nlog.config");
  }

  private class OnPostUpLoadModel
  {
    public string? Base64Content { get; set; }
  }
}
