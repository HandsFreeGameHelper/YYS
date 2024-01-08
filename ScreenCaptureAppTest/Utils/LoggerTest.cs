using NLog;
using NLog.Config;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ScreenCaptureAppTest.Utils;

internal class LoggerTest
{

  [Test]
  public void Test1()
  {
    LogManager.Configuration = new XmlLoggingConfiguration(@"./nlog.config");

    var logger = LogManager.GetCurrentClassLogger();
    logger.Info("This is an informational message.");
    logger.Error("This is an error message.");

    // Other code in your application...

    LogManager.Flush();
  }
}
