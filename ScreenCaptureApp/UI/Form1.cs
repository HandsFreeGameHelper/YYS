using NLog;
using ScreenCaptureApp.Main;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;

namespace ScreenCaptureApp.UI
{
  public partial class Form1 : Form
  {
    private Logger logger = LoggerHelper.DefualtLogger;

    private int MaxCount = 0;

    private Random Random = new Random();

    private List<IntPtr> targetHWnds = new List<IntPtr>();

    private List<KeyValuePair<IntPtr, GameProperties>> Pics = new List<KeyValuePair<IntPtr, GameProperties>>();

    private string CType { get; set; } = new(EMPTY);
    private string CEnergyValue { get; set; } = new(EMPTY);
    private string? RestType { get; set; } = new(EMPTY);
    private string? RestModel { get; set; } = new(EMPTY);
    private bool isRestModel = false;
    private bool isTeam = false;
    private bool isRequestToReset;

    public Form1()
    {
      InitializeComponent();
      InitComboboxs();
      InitializeFormFunction();
    }

    private void StartTask(IntPtr intPtr)
    {
      var threadID = Environment.CurrentManagedThreadId;
      int processid;
      SystemRuntimes.GetWindowThreadProcessId(intPtr, out processid);
      var properties = this.FindProperties(intPtr);
      while (true)
      {
        if (!properties.IsRequestToStop)
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
                if (!properties.IsLocked && Random.StartChallenge(CType, windowRect, bmp, this.CEnergyValue, this.isTeam, intPtr))
                {
                  Thread.Sleep(100);
                  properties.IsLocked = !properties.IsLocked;
                  properties.CurrentCout++;
                  this.processLable.Text = ChallengeType.TUPO.Equals(CType) ? $@"已突破{properties.CurrentCout}次" : $@"{properties.CurrentCout}/{this.MaxCount}";
                  this.afterStartLable.ForeColor = Color.Blue;
                  this.afterStartLable.Text = $@"{threadID}_{processid} : 挑战开始，等待挑战结束";
                  logger.Info(this.processLable.Text);
                  logger.Info(this.afterStartLable.Text);
                }
                if ((properties.IsLocked || isTeam) && Random.EndChallenge(CType, windowRect, bmp))
                {
                  properties.IsLocked = !properties.IsLocked;
                  this.afterStartLable.ForeColor = Color.Blue;
                  this.afterStartLable.Text = $@"{threadID}_{processid} : 挑战结束，等待挑战开始";
                  logger.Logs(LogLevel.Info, $@"{threadID}_{processid} : 已成功挑战{properties.CurrentCout}次");
                }
                if (!ChallengeType.TUPO.Equals(CType) && properties.CurrentCout >= MaxCount)
                {
                  var stopFlag = true;

                  while (stopFlag)
                  {
                    using (var tempBmp = intPtr.GetBitmap())
                    {
                      if (Random.EndChallenge(CType, windowRect, tempBmp))
                      {
                        stopFlag = false;
                        logger.Logs(LogLevel.Info, $@"{threadID}_{processid} : 已成功挑战{properties.CurrentCout}次");
                        break;
                      }
                    }
                  }
                  logger.Logs(LogLevel.Info, $@"{threadID}_{processid} : 挑战结束");
                  properties.IsRequestToStop = true;
                }
                if (this.Pics.Any(x => x.Value.IsRequestToStop == true))
                {
                  Stop();
                }
              }
              else
              {
                if (!bmp.RestImages(this.RestType, this.RestModel, this.isTeam))
                {
                  logger.Logs(LogLevel.Warn, $@"{threadID}_{processid} : 校准失败");
                  this.label14.ForeColor = Color.Red;
                  this.label14.Text = $@"{threadID}_{processid} : 校准失败!{Environment.NewLine}请点击 停止 按钮后重试";
                }
                else
                {
                  logger.Logs(LogLevel.Info, $@"{threadID}_{processid} : 校准成功");
                  this.label14.ForeColor = Color.Red;
                  this.label14.Text = $@"{threadID}_{processid} : 校准成功!{Environment.NewLine}请设置好参数后开始挑战";
                }
                this.isRestModel = false;
                properties.IsRequestToStop = true;
              }
            }
            GC.Collect();
          }
          else
          {
            logger.Logs(LogLevel.Error, $@"{threadID}_{processid} : Window not found.");
            properties.IsRequestToStop = true;
          }
          Thread.Sleep(0);
        }
        if (isRequestToReset)
        {
          this.Pics.ForEach(x =>
          {
            x.Value.IsRequestToStop = true;
            x.Value.CurrentCout = 0;
            x.Value.IsLocked = false;
          });
          Thread.Sleep(0);
        }
        Thread.Sleep(0);
      }
    }

    #region UI

    private void StartUIThread(IntPtr intPtr)
    {
      var properties = this.FindProperties(intPtr);
      while (true)
      {
        if (!properties.IsRequestToStop)
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
              int newWidth = (int)(bmp.Width * 0.5 * 0.68);
              int newHeight = (int)(bmp.Height * 0.5 * 0.68);
              Bitmap scaledBmp = new Bitmap(bmp, newWidth, newHeight);

              WindowsRuntimes.SelectObject(hdcMemDC, hOld);
              WindowsRuntimes.DeleteObject(hBitmap);
              WindowsRuntimes.DeleteDC(hdcMemDC);
              SystemRuntimes.ReleaseDC(intPtr, hdcWindow);
              this.FindProperties(intPtr).WindowPic.Image = scaledBmp;
            }
            GC.Collect();
          }
          else
          {
            logger.Logs(LogLevel.Error, $@"Window not found.");
            properties.IsRequestToStop = true;
          }
        }
        Thread.Sleep(1);
      }
    }

    #endregion

    private GameProperties FindProperties(IntPtr intPtr)
    {
      return this.Pics.Where(x => x.Key == intPtr).First().Value;
    }

    private class GameProperties
    {
      private PictureBox? _windowPic;

      public PictureBox WindowPic { get => Guard.GetNotNull(this._windowPic, nameof(this.WindowPic)); set => this._windowPic = value; }

      public int CurrentCout { get; set; } = 0;

      public bool IsRequestToStop { get; set; } = true;

      public bool IsLocked { get; set; } = false;
    }

    private void InitializeFormFunction() 
    {
      pictureBoxes.Add(pictureBox1);
      pictureBoxes.Add(pictureBox2);
      Console.SetOut(new TextBoxWriter(richTextBox1));
      this.richTextBox1.HideSelection = false;
      ResetAfterStartLable();
      ResetSelectBox();
      WindowsFilter.GetWindows();
      targetHWnds = WindowsFilter.WindowHandles;
      try
      {
        targetHWnds.ForEach(wnds =>
        {
          this.Pics.Add(new(wnds, new()
          {
            WindowPic = this.pictureBoxes.Next(),
          }));
          //new Thread(() =>
          //{
          //  StartUIThread(wnds);
          //}).Start();
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
  }
}
