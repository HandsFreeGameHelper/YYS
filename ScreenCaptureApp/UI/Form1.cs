using NLog;
using ScreenCaptureApp.Main;
using ScreenCaptureApp.Utils;
using System.Threading;
using static ScreenCaptureApp.Utils.Contains;

namespace ScreenCaptureApp.UI
{
  public partial class Form1 : Form
  {
    private Logger logger = LoggerHelper.GetLogger();
    private int MaxCount = 0;
    private int RCount = 0;
    private Random Random = new Random();
    private List<IntPtr> targetHWnds = new List<IntPtr>();
    private string CType { get; set; } = new(EMPTY);
    private string CEnergyValue { get; set; } = new(EMPTY);
    private string? RestType { get; set; } = new(EMPTY);
    private string? RestModel { get; set; } = new(EMPTY);
    private bool isRestModel = false;
    private bool isTeam = false;
    private bool isRequestToStop;
    private bool isRequestToReset;
    private List<KeyValuePair<IntPtr, PictureBox>> Pics = new List<KeyValuePair<IntPtr, PictureBox>>();
    public Form1()
    {
      InitializeComponent();
      pictureBoxes.Add(pictureBox1);
      pictureBoxes.Add(pictureBox2);
      Console.SetOut(new TextBoxWriter(richTextBox1));
      this.richTextBox1.HideSelection = false;
      RestLable10();
      RestSelectBox();
      WindowsFilter.GetWindows();
      targetHWnds = WindowsFilter.WindowHandles;
      this.isRequestToStop = true;

      try
      {
        targetHWnds.ForEach(wnds =>
        {
          this.Pics.Add(new(wnds, this.pictureBoxes.Next()));
          new Thread(() =>
          {
            StartUIThread(wnds);
          }).Start();
          new Thread(() =>
          {
            StartTask(wnds);
          }).Start();
        });
      }
      catch (Exception ex)
      {
        logger.Error(ex.ToString());
      }
    }

    private void StartTask(IntPtr intPtr)
    {
      var threadID = Environment.CurrentManagedThreadId;
      var islocked = false;
      while (true)
      {
        if (!this.isRequestToStop)
        {
          if (intPtr != IntPtr.Zero)
          {
            UpdateCheckbox1Checked();
            SystemRuntimes.RECT windowRect;
            SystemRuntimes.GetWindowRect(intPtr, out windowRect);

            var widthAndHeight = windowRect.GetWidthAndHeight();
            IntPtr hdcWindow = SystemRuntimes.GetDC(intPtr);
            IntPtr hdcMemDC = WindowsRuntimes.CreateCompatibleDC(hdcWindow);
            IntPtr hBitmap = WindowsRuntimes.CreateCompatibleBitmap(hdcWindow, widthAndHeight.Item1, widthAndHeight.Item2);
            IntPtr hOld = WindowsRuntimes.SelectObject(hdcMemDC, hBitmap);

            WindowsRuntimes.BitBlt(hdcMemDC, 0, 0, widthAndHeight.Item1, widthAndHeight.Item2, hdcWindow, 0, 0, 13369376); // 13369376 is SRCCOPY constant

            using (Bitmap bmp = Bitmap.FromHbitmap(hBitmap))
            {
              WindowsRuntimes.SelectObject(hdcMemDC, hOld);
              WindowsRuntimes.DeleteObject(hBitmap);
              WindowsRuntimes.DeleteDC(hdcMemDC);
              SystemRuntimes.ReleaseDC(intPtr, hdcWindow);
              if (!this.isRestModel)
              {
                if (!islocked && Random.Challenge(CType, windowRect, bmp, this.CEnergyValue, this.isTeam, intPtr))
                {
                  Thread.Sleep(100);
                  islocked = !islocked;
                  RCount++;
                  this.label8.Text = ChallengeType.TUPO.Equals(CType) ? $@"已突破{RCount}次" : $@"{RCount}/{this.MaxCount}";
                  this.label10.ForeColor = Color.Blue;
                  this.label10.Text = $@"{threadID}: 挑战开始，等待挑战结束";
                  logger.Info(this.label8.Text);
                  logger.Info(this.label10.Text);
                }
                if ((islocked || isTeam) && Random.Challenge(CType, windowRect, bmp))
                {
                  islocked = !islocked;
                  this.label10.ForeColor = Color.Blue;
                  this.label10.Text = $@"{threadID}: 挑战结束，等待挑战开始";
                  logger.Logs(LogLevel.Info, $@"{threadID}: 已成功挑战{RCount}次");
                }
                if (!ChallengeType.TUPO.Equals(CType) && RCount >= MaxCount)
                {

                  var stopFlag = true;
                  while (stopFlag)
                  {
                    using (var tempBmp = intPtr.GetBitmap())
                    {
                      if (Random.Challenge(CType, windowRect, tempBmp))
                      {
                        stopFlag = false;
                        logger.Logs(LogLevel.Info, $@"{threadID}: 已成功挑战{RCount}次");
                        break;
                      }
                    }
                  }
                  logger.Logs(LogLevel.Info, $@"{threadID}: 挑战结束");
                  Stop();
                }
              }
              else
              {
                if (!bmp.RestImages(this.RestType, this.RestModel, this.isTeam))
                {
                  logger.Logs(LogLevel.Warn, $@"{threadID}: 校准失败");
                  this.label14.ForeColor = Color.Red;
                  this.label14.Text = $@"{threadID}: 校准失败!{Environment.NewLine}请点击 停止 按钮后重试";
                }
                else
                {
                  logger.Logs(LogLevel.Info, $@"{threadID}: 校准成功");
                  this.label14.ForeColor = Color.Red;
                  this.label14.Text = $@"{threadID}: 校准成功!{Environment.NewLine}请设置好参数后开始挑战";
                }
                this.isRestModel = false;
                this.isRequestToStop = true;
              }
            }
            GC.Collect();
          }
          else
          {
            logger.Logs(LogLevel.Error, $@"{threadID}: Window not found.");
            Stop();
          }
        }
        if (isRequestToReset)
        {
          islocked = false;
          RCount = 0;
        }
        Thread.Sleep(0);
      }
    }
    private void StartUIThread(IntPtr intPtr)
    {
      while (true)
      {
        if (!this.isRequestToStop)
        {
          if (intPtr != IntPtr.Zero)
          {
            SystemRuntimes.RECT windowRect;
            SystemRuntimes.GetWindowRect(intPtr, out windowRect);

            var widthAndHeight = windowRect.GetWidthAndHeight();
            IntPtr hdcWindow = SystemRuntimes.GetDC(intPtr);
            IntPtr hdcMemDC = WindowsRuntimes.CreateCompatibleDC(hdcWindow);
            IntPtr hBitmap = WindowsRuntimes.CreateCompatibleBitmap(hdcWindow, widthAndHeight.Item1, widthAndHeight.Item2);
            IntPtr hOld = WindowsRuntimes.SelectObject(hdcMemDC, hBitmap);

            WindowsRuntimes.BitBlt(hdcMemDC, 0, 0, widthAndHeight.Item1, widthAndHeight.Item2, hdcWindow, 0, 0, 13369376); // 13369376 is SRCCOPY constant

            using (Bitmap bmp = Bitmap.FromHbitmap(hBitmap))
            {
              int newWidth = (int)(bmp.Width * 0.5 * 0.88);
              int newHeight = (int)(bmp.Height * 0.5 * 0.88);
              Bitmap scaledBmp = new Bitmap(bmp, newWidth, newHeight);

              WindowsRuntimes.SelectObject(hdcMemDC, hOld);
              WindowsRuntimes.DeleteObject(hBitmap);
              WindowsRuntimes.DeleteDC(hdcMemDC);
              SystemRuntimes.ReleaseDC(intPtr, hdcWindow);
              this.Pics.Where(x => x.Key == intPtr).First().Value.Image = scaledBmp;
            }
            GC.Collect();
          }
          else
          {
            logger.Logs(LogLevel.Error, $@"Window not found.");
            Stop();
          }
        }
        Thread.Sleep(1);
      }
    }
  }
}
