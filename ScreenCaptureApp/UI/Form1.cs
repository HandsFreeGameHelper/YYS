using ScreenCaptureApp.Main;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;

namespace ScreenCaptureApp.UI
{
  public partial class Form1 : Form
  {
    private int MaxCount = 0;
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
    private object bmpLock = new object();
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

      targetHWnds.ForEach(wnds =>
      {
        this.Pics.Add(new(wnds, this.pictureBoxes.Next()));
        new Thread(() =>
        {
          StartUIThread(wnds, targetHWnds.Count);
        }).Start();
        new Thread(() =>
        {
          StartTask(wnds);
        }).Start();
      });
    }

    private void button1_Click(object sender, EventArgs e)
    {
      Console.WriteLine($@"开始");
      this.isRequestToStop = false;
      this.pictureBoxes.ForEach(x =>
      {
        x.Show();
      });
    }

    private void button2_Click(object sender, EventArgs e)
    {
      Stop();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      this.richTextBox1.Clear();
    }

    private void button4_Click(object sender, EventArgs e)
    {
      this.CType = comboBox1.SelectedItem?.ToString() ?? EMPTY;
      var selection = comboBox2.SelectedItem?.ToString();
      var energyValue = "";
      var judgeRes = ChallengeFactory.TryJudgeChallengeModel(this.CType, selection, out energyValue);
      this.CEnergyValue = energyValue;
      if (!ChallengeType.TUPO.Equals(this.CType))
      {
        try
        {
          label16.Text = EMPTY;
          this.MaxCount = int.Parse(this.textBox1.Text);
          if (!judgeRes)
          {
            label16.ForeColor = Color.Red;
            label16.Text = "请正确地选择挑战类型或挑战关卡，请点击停止后重新选择";
          }
          else
          {
            label16.ForeColor = Color.Green;
            label16.Text = $@"设置成功 {Environment.NewLine}当前选择的是进行 {this.CType} 模式下 的 {selection} 关卡 挑战 {this.MaxCount} 次，请点击开始";
            ResetLable8();
          }
        }
        catch (Exception)
        {
          label16.ForeColor = Color.Red;
          label16.Text = "请输入正确的挑战次数，例：30";
          ResetLable8();
        }
      }
      else
      {
        label16.ForeColor = Color.Green;
        label16.Text = $@"设置成功 {Environment.NewLine}当前选择的是进行 {this.CType} 模式下 的 {selection} 关卡 ，请点击开始";
      }
     
    }

    private void Stop()
    {
      this.pictureBoxes.ForEach(x =>
      {
        x.Image = x.Image.ReMoveImage();
        x.Hide();
      });

      this.label10.ForeColor = Color.Red;
      this.label10.Text = @"挑战停止";
      Console.WriteLine($@"停止");
      this.isRequestToStop = true;
    }

    private void button5_Click(object sender, EventArgs e)
    {
      button2_Click(sender, e);
      this.label16.Text = EMPTY;
      this.textBox1.Clear();
      this.CType = EMPTY;
      this.CEnergyValue = EMPTY;
      richTextBox1.Clear();
      this.isRestModel = false;
      this.isRequestToReset = true;
      this.MaxCount = 0;
      ResetLable8();
      RestLable10();
      RestSelectBox();
      ReSetCheckbox1();
      Console.WriteLine(@"已重置");
    }

    private void ResetLable8()
    {
      this.label8.Text = $@"{0}/{this.MaxCount}";
    }

    private void RestLable10()
    {
      this.label10.ForeColor = Color.Red;
      this.label10.Text = $@"     等待开始     {Environment.NewLine}开始前请确保在挑战界面";
    }

    private void RestSelectBox()
    {
      comboBox1.SelectedItem = ChallengeType.NOMAL;
      comboBox2.SelectedItem = ChallengeSelection.BAQI_11;
      comboBox3.SelectedItem = EMPTY;
      comboBox4.SelectedItem = EMPTY;
    }

    private void button6_Click(object sender, EventArgs e)
    {
      this.isRestModel = true;
      this.RestType = this.comboBox3.SelectedItem.ToString();
      this.RestModel = this.comboBox4.SelectedItem.ToString();
      this.isRequestToStop = false;
    }

    private void UpdateCheckbox1Checked()
    {
      this.isTeam = this.checkBox1.Checked;
    }

    private void ReSetCheckbox1()
    {
      this.checkBox1.Checked = false;
    }

    private void StartTask(IntPtr intPtr)
    {
      var islocked = false;
      var RCount = 0;
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
                if (!islocked && Random.Challenge(CType, windowRect, bmp, this.CEnergyValue, this.isTeam , intPtr))
                {
                  islocked = this.isTeam ? islocked : !islocked;
                  if (!ChallengeType.TUPO.Equals(CType))
                  {
                    RCount++;
                    this.label8.Text = $@"{RCount}/{this.MaxCount}";
                    this.label10.ForeColor = Color.Blue;
                  }
                  this.label10.Text = @"挑战开始，等待挑战结束";
                }
                if ((islocked || isTeam) && Random.Challenge(CType, windowRect, bmp))
                {
                  islocked = this.isTeam ? islocked : !islocked;
                  this.label10.ForeColor = Color.Blue;
                  this.label10.Text = @"挑战结束，等待挑战开始";
                  Console.WriteLine($@"已成功挑战{RCount}次");
                }
                if (!ChallengeType.TUPO.Equals(CType) && RCount >= MaxCount)
                {
                  Console.WriteLine($@"挑战结束");
                  Stop();
                }
              }
              else
              {
                if (!bmp.RestImages(this.RestType, this.RestModel, this.isTeam))
                {
                  Console.WriteLine(@"校准失败");
                  this.label14.ForeColor = Color.Red;
                  this.label14.Text = $@"校准失败!{Environment.NewLine}请点击 停止 按钮后重试";
                }
                else
                {
                  Console.WriteLine(@"校准成功");
                  this.label14.ForeColor = Color.Red;
                  this.label14.Text = $@"校准成功!{Environment.NewLine}请设置好参数后开始挑战";
                }
                this.isRestModel = false;
                this.isRequestToStop = true;
              }
            }
            GC.Collect();
          }
          else
          {
            Console.WriteLine("Window not found.");
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
    private void StartUIThread(IntPtr intPtr, int imagecount)
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
            Console.WriteLine("Window not found.");
            Stop();
          }
        }
        Thread.Sleep(1);
      }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      System.Environment.Exit(0);
    }
  }
}
