using ScreenCaptureApp.Main;
using ScreenCaptureApp.Utils;

namespace ScreenCaptureApp
{
  public partial class Form1 : Form
  {
    private int MaxCount = 50;
    private int RCount = 0;
    private Random Random = new Random();
    private System.Windows.Forms.Timer timer;
    private IntPtr targetHWnd;
    private string? CType { get; set; } = new(Utils.Contains.EMPTY);
    private string? CEnergyValue { get; set; } = new(Utils.Contains.EMPTY);

    public Form1()
    {
      InitializeComponent();
      Console.SetOut(new TextBoxWriter(richTextBox1));
      this.richTextBox1.HideSelection = false;
      timer = new System.Windows.Forms.Timer();
      timer.Interval = 1; // 设置定时器间隔，单位为毫秒
      timer.Tick += Timer_Tick!;

      // 替换窗口标题或类名为目标窗口的标题或类名
      string windowTitle = "阴阳师-网易游戏";
      targetHWnd = SystemRuntimes.FindWindow(null, windowTitle);
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      if (sender != null)
      {
        if (targetHWnd != IntPtr.Zero)
        {
          if (this.richTextBox1.TextLength > 524288)
          {
            this.richTextBox1.Clear();
          }
          if (!string.IsNullOrEmpty(this.CType))
          {
            Thread.Sleep(10);
          }
          if (RCount >= MaxCount)
          {
            Console.WriteLine($@"挑战结束");
            timer.Stop();
          }
          SystemRuntimes.RECT windowRect;
          SystemRuntimes.GetWindowRect(targetHWnd, out windowRect);

          int width = windowRect.Right - windowRect.Left;
          int height = windowRect.Bottom - windowRect.Top;
          IntPtr hdcWindow = SystemRuntimes.GetDC(targetHWnd);
          IntPtr hdcMemDC = WindowsRuntimes.CreateCompatibleDC(hdcWindow);
          IntPtr hBitmap = WindowsRuntimes.CreateCompatibleBitmap(hdcWindow, width, height);
          IntPtr hOld = WindowsRuntimes.SelectObject(hdcMemDC, hBitmap);

          WindowsRuntimes.BitBlt(hdcMemDC, 0, 0, width, height, hdcWindow, 0, 0, 13369376); // 13369376 is SRCCOPY constant

          if (pictureBox1.Image != null)
          {
            pictureBox1.Image.Dispose();
          }
          using (Bitmap bmp = Bitmap.FromHbitmap(hBitmap))
          {
            int newWidth = (int)(bmp.Width * 0.5);
            int newHeight = (int)(bmp.Height * 0.5);
            Bitmap scaledBmp = new Bitmap(bmp, newWidth, newHeight);

            WindowsRuntimes.SelectObject(hdcMemDC, hOld);
            WindowsRuntimes.DeleteObject(hBitmap);
            WindowsRuntimes.DeleteDC(hdcMemDC);
            SystemRuntimes.ReleaseDC(targetHWnd, hdcWindow);
            if (Random.Challenge(CType, this.CEnergyValue, windowRect, scaledBmp))
            {
              RCount++;
              Console.WriteLine($@"已成功挑战{RCount}次");
            }
            pictureBox1.Image = scaledBmp;
          }
          GC.Collect();
        }
        else
        {
          Console.WriteLine("Window not found.");
        }
      }
    }
    private void button1_Click(object sender, EventArgs e)
    {
      Console.WriteLine($@"开始");
      this.RCount = 0;
      timer.Start();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      pictureBox1.Image = pictureBox1.Image.ReMoveImage();
      Console.WriteLine($@"停止");
      this.RCount = 0;
      timer.Stop();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      this.richTextBox1.Clear();
    }

    private void button4_Click(object sender, EventArgs e)
    {
      try
      {
        label5.Text = Utils.Contains.EMPTY;
        this.MaxCount = int.Parse(this.textBox1.Text);
        this.CType = comboBox1.SelectedItem?.ToString();
        var selection = comboBox2.SelectedItem?.ToString();
        var energyValue = "";
        if (!ChallengeFactory.TryJudgeChallengeModel(this.CType, selection, out energyValue))
        {
          label5.Location = new Point(70, 460);
          label5.ForeColor = Color.Red;
          label5.Text = "请正确地选择挑战类型或挑战关卡，请点击停止后重新选择";
        }
        else
        {
          label5.Location = new Point(30, 460);
          this.CEnergyValue = energyValue;
          label5.ForeColor = Color.Green;
          label5.Text = $@"设置成功 当前选择的是进行 {this.CType} 模式下 的 {selection} 关卡 挑战 {this.MaxCount} 次，请点击开始";
        }
      }
      catch (Exception)
      {
        label5.Location = new Point(70, 460);
        label5.ForeColor = Color.Red;
        label5.Text = "请输入正确的挑战次数，例：30";
      }

    }

    private void button5_Click(object sender, EventArgs e)
    {
      timer.Stop();
      this.label5.Text = Utils.Contains.EMPTY;
      this.textBox1.Clear();
      comboBox1.SelectedItem = Utils.Contains.EMPTY;
      comboBox2.SelectedItem = Utils.Contains.EMPTY;
      this.RCount = 0;
      this.CType = Utils.Contains.EMPTY;
      this.CEnergyValue = Utils.Contains.EMPTY;
      richTextBox1.Clear();
      pictureBox1.Image = pictureBox1.Image.ReMoveImage();
    }

  }
}
