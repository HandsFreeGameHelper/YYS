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
      timer.Interval = 1; // ���ö�ʱ���������λΪ����
      timer.Tick += Timer_Tick!;

      // �滻���ڱ��������ΪĿ�괰�ڵı��������
      string windowTitle = "����ʦ-������Ϸ";
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
            Console.WriteLine($@"��ս����");
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
              Console.WriteLine($@"�ѳɹ���ս{RCount}��");
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
      Console.WriteLine($@"��ʼ");
      this.RCount = 0;
      timer.Start();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      pictureBox1.Image = pictureBox1.Image.ReMoveImage();
      Console.WriteLine($@"ֹͣ");
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
          label5.Text = "����ȷ��ѡ����ս���ͻ���ս�ؿ�������ֹͣ������ѡ��";
        }
        else
        {
          label5.Location = new Point(30, 460);
          this.CEnergyValue = energyValue;
          label5.ForeColor = Color.Green;
          label5.Text = $@"���óɹ� ��ǰѡ����ǽ��� {this.CType} ģʽ�� �� {selection} �ؿ� ��ս {this.MaxCount} �Σ�������ʼ";
        }
      }
      catch (Exception)
      {
        label5.Location = new Point(70, 460);
        label5.ForeColor = Color.Red;
        label5.Text = "��������ȷ����ս����������30";
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
