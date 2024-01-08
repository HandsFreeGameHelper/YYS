using ScreenCaptureApp.Main;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;

namespace ScreenCaptureApp.UI;

public partial class Form1 : Form
{
  private void button1_Click(object sender, EventArgs e)
  {
    logger.Logs(NLog.LogLevel.Info, $@"开始");
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
          logger.Warn(label16.Text);
        }
        else
        {
          label16.ForeColor = Color.Green;
          label16.Text = $@"设置成功 {Environment.NewLine}当前选择的是进行 {this.CType} 模式下 的 {selection} 关卡 挑战 {this.MaxCount} 次，请点击开始";
          logger.Info(label16.Text);
          ResetLable8();
        }
      }
      catch (Exception)
      {
        label16.ForeColor = Color.Red;
        label16.Text = "请输入正确的挑战次数，例：30";
        logger.Error(label16.Text);
        ResetLable8();
      }
    }
    else
    {
      label16.ForeColor = Color.Green;
      label16.Text = $@"设置成功 {Environment.NewLine}当前选择的是进行 {this.CType} 模式下 的 {selection} 关卡 ，请点击开始";
      logger.Info(label16.Text);
    }

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
    logger.Logs(NLog.LogLevel.Info, @"已重置");
  }

  private void button6_Click(object sender, EventArgs e)
  {
    this.isRestModel = true;
    this.RestType = this.comboBox3.SelectedItem.ToString();
    this.RestModel = this.comboBox4.SelectedItem.ToString();
    this.isRequestToStop = false;
  }

  private void Form1_FormClosing(object sender, FormClosingEventArgs e)
  {
    Environment.Exit(0);
  }

  private void UpdateCheckbox1Checked()
  {
    this.isTeam = this.checkBox1.Checked;
  }

  private void ReSetCheckbox1()
  {
    this.checkBox1.Checked = false;
  }

  private void ResetLable8()
  {
    this.label8.Text = $@"{0}/{this.MaxCount}";
  }

  private void RestLable10()
  {
    this.label10.ForeColor = Color.Red;
    this.label10.Text = $@"     等待开始     {Environment.NewLine}开始前请确保在挑战界面";
    logger.Info(label10.Text);
  }

  private void RestSelectBox()
  {
    comboBox1.SelectedItem = ChallengeType.NOMAL;
    comboBox2.SelectedItem = ChallengeSelection.BAQI_11;
    comboBox3.SelectedItem = EMPTY;
    comboBox4.SelectedItem = EMPTY;
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
    logger.Logs(NLog.LogLevel.Info, $@"停止");
    this.isRequestToStop = true;
  }
}
