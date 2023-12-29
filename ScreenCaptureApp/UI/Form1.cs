using ScreenCaptureApp.Main;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;

namespace ScreenCaptureApp.UI
{
  public partial class Form1 : Form
  {
    private int MaxCount = 0;
    private int RCount = 0;
    private Random Random = new Random();
    private System.Windows.Forms.Timer timer;
    private IntPtr targetHWnd;
    private string? CType { get; set; } = new(Utils.Contains.EMPTY);
    private string? CEnergyValue { get; set; } = new(Utils.Contains.EMPTY);
    private string? RestType { get; set; } = new(Utils.Contains.EMPTY);
    private string? RestModel { get; set; } = new(Utils.Contains.EMPTY);
    private bool islocked = false;
    private bool isRestModel = false;
    public Form1()
    {
      InitializeComponent();
      Console.SetOut(new TextBoxWriter(richTextBox1));
      this.richTextBox1.HideSelection = false;
      timer = new System.Windows.Forms.Timer();
      timer.Interval = 1; // ���ö�ʱ���������λΪ����
      timer.Tick += Timer_Tick!;
      RestLable10();
      RestSelectBox();
      // �滻���ڱ��������ΪĿ�괰�ڵı��������
      string windowTitle = "����ʦ-������Ϸ";
      targetHWnd = SystemRuntimes.FindWindow(null, windowTitle);
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      try
      {
        if (sender != null)
        {
          if (targetHWnd != IntPtr.Zero)
          {
            SystemRuntimes.RECT windowRect;
            SystemRuntimes.GetWindowRect(targetHWnd, out windowRect);

            var widthAndHeight = windowRect.GetWidthAndHeight();
            IntPtr hdcWindow = SystemRuntimes.GetDC(targetHWnd);
            IntPtr hdcMemDC = WindowsRuntimes.CreateCompatibleDC(hdcWindow);
            IntPtr hBitmap = WindowsRuntimes.CreateCompatibleBitmap(hdcWindow, widthAndHeight.Item1, widthAndHeight.Item2);
            IntPtr hOld = WindowsRuntimes.SelectObject(hdcMemDC, hBitmap);

            WindowsRuntimes.BitBlt(hdcMemDC, 0, 0, widthAndHeight.Item1, widthAndHeight.Item2, hdcWindow, 0, 0, 13369376); // 13369376 is SRCCOPY constant

            pictureBox1.Image = pictureBox1.Image.ReMoveImage();

            using (Bitmap bmp = Bitmap.FromHbitmap(hBitmap))
            {
              int newWidth = (int)(ImagesConfig.RegionWidth * 0.5);
              int newHeight = (int)(ImagesConfig.RegionHeight * 0.5);
              Bitmap scaledBmp = new Bitmap(bmp, newWidth, newHeight);

              WindowsRuntimes.SelectObject(hdcMemDC, hOld);
              WindowsRuntimes.DeleteObject(hBitmap);
              WindowsRuntimes.DeleteDC(hdcMemDC);
              SystemRuntimes.ReleaseDC(targetHWnd, hdcWindow);
              pictureBox1.Image = scaledBmp;
              if (!this.isRestModel)
              {
                if (!islocked && Random.Challenge(CType, windowRect, scaledBmp, this.CEnergyValue))
                {
                  islocked = !islocked;
                  this.label10.ForeColor = Color.Blue;
                  this.label10.Text = @"��ս��ʼ���ȴ���ս����";
                }
                if (islocked && Random.Challenge(CType, windowRect, scaledBmp))
                {
                  islocked = !islocked;
                  RCount++;
                  this.label10.ForeColor = Color.Blue;
                  this.label10.Text = @"��ս�������ȴ���ս��ʼ";
                  Console.WriteLine($@"�ѳɹ���ս{RCount}��");
                }
                if (RCount >= MaxCount)
                {
                  Console.WriteLine($@"��ս����");
                  button2_Click(sender, e);
                }
                UpdateLable8();
              }
              else
              {
                if (!scaledBmp.RestImages(this.RestType, this.RestModel))
                {
                  Console.WriteLine(@"У׼ʧ��");
                  this.label14.ForeColor = Color.Red;
                  this.label14.Text = $@"У׼ʧ��!{Environment.NewLine}���� ֹͣ ��ť������";
                }
                Console.WriteLine(@"У׼�ɹ�");
                this.label14.ForeColor = Color.Red;
                this.label14.Text = $@"У׼�ɹ�!{Environment.NewLine}�����úò�����ʼ��ս";
                this.isRestModel = false;
                timer.Stop();
              }
            }
            GC.Collect();
          }
          else
          {
            Console.WriteLine("Window not found.");
            button2_Click(sender, e);
          }
        }
      }
      catch { }
    }
    private void button1_Click(object sender, EventArgs e)
    {
      Console.WriteLine($@"��ʼ");
      timer.Start();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      pictureBox1.Image = pictureBox1.Image.ReMoveImage();
      this.label10.ForeColor = Color.Red;
      this.label10.Text = @"��սֹͣ";
      Console.WriteLine($@"ֹͣ");
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
          UpdateLable8();
        }
      }
      catch (Exception)
      {
        label5.Location = new Point(70, 460);
        label5.ForeColor = Color.Red;
        label5.Text = "��������ȷ����ս����������30";
        UpdateLable8();
      }

    }

    private void button5_Click(object sender, EventArgs e)
    {
      button2_Click(sender, e);
      this.label5.Text = Utils.Contains.EMPTY;
      this.textBox1.Clear();
      this.RCount = 0;
      this.MaxCount = 0;
      this.CType = Utils.Contains.EMPTY;
      this.CEnergyValue = Utils.Contains.EMPTY;
      richTextBox1.Clear();
      this.islocked = false;
      this.isRestModel = false;
      UpdateLable8();
      RestLable10();
      RestSelectBox();
      Console.WriteLine(@"������");
    }

    private void UpdateLable8()
    {
      this.label8.Text = $@"{this.RCount}/{this.MaxCount}";
    }

    private void RestLable10()
    {
      this.label10.ForeColor = Color.Red;
      this.label10.Text = $@"     �ȴ���ʼ     {Environment.NewLine}��ʼǰ��ȷ������ս����";
    }

    private void RestSelectBox()
    {
      comboBox1.SelectedItem = Utils.Contains.ChallengeType.NOMAL;
      comboBox2.SelectedItem = Utils.Contains.ChallengeSelection.BAQI_11;
      comboBox3.SelectedItem = Utils.Contains.EMPTY;
      comboBox4.SelectedItem = Utils.Contains.EMPTY;
    }

    private void button6_Click(object sender, EventArgs e)
    {
      this.isRestModel = true;
      this.RestType = this.comboBox3.SelectedItem.ToString();
      this.RestModel = this.comboBox4.SelectedItem.ToString();
      this.timer.Start();
    }
  }
}
