using ScreenCaptureApp.Main.Models;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;

namespace ScreenCaptureApp.UI;

public partial class Form1 : Form
{
  private void startBtn_Click(object sender, EventArgs e)
  {
    this.isRequestToReset = false;
    logger.Logs(NLog.LogLevel.Info, $@"开始");
    this.pictureBoxes.ForEach(x =>
    {
      x.Show();
    });
    this.Pics.ForEach(x =>
    {
      x.Value.IsRequestToStop = false;
      x.Value.IsLocked = false;
    });
  }

  private void stopBtn_Click(object sender, EventArgs e)
  {
    Stop();
  }

  private void clearLogBtn_Click(object sender, EventArgs e)
  {
    this.richTextBox1.Clear();
  }

  private void setBtn_Click(object sender, EventArgs e)
  {
    this.CType = challengeTypeComboBox.SelectedItem?.ToString() ?? EMPTY;
    var selection = challengeSelectionComboBox.SelectedItem?.ToString();
    var energyValue = "";
    var judgeRes = ModelBase.TryJudgeChallengeModel(this.CType, selection, out energyValue);
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
          label16.Text = $@"设置成功 {Environment.NewLine}当前选择的是进行 {this.CType} 模式下 {Environment.NewLine} {selection} 关卡 挑战 {this.MaxCount} 次，请点击开始";
          logger.Info(label16.Text);
          ResetProcessLable();
        }
      }
      catch (Exception)
      {
        label16.ForeColor = Color.Red;
        label16.Text = "请输入正确的挑战次数，例：30";
        logger.Error(label16.Text);
        ResetProcessLable();
      }
    }
    else
    {
      label16.ForeColor = Color.Green;
      label16.Text = $@"设置成功 {Environment.NewLine}当前选择的是进行 {this.CType} 模式下 的 {selection} 关卡 ，请点击开始";
      logger.Info(label16.Text);
    }

  }

  private void resetBtn_Click(object sender, EventArgs e)
  {
    stopBtn_Click(sender, e);
    this.label16.Text = EMPTY;
    this.textBox1.Clear();
    this.CType = EMPTY;
    this.CEnergyValue = EMPTY;
    richTextBox1.Clear();
    this.isRestModel = false;
    this.isRequestToReset = true;
    this.MaxCount = 0;
    ResetProcessLable();
    ResetAfterStartLable();
    ResetSelectBox();
    ReSetIsTeamCheckBox();
    logger.Logs(NLog.LogLevel.Info, @"已重置");
  }

  private void fixBtn_Click(object sender, EventArgs e)
  {
    this.isRestModel = true;
    this.RestType = this.comboBox3.SelectedItem.ToString();
    this.RestModel = this.comboBox4.SelectedItem.ToString();
  }

  private void Form1_FormClosing(object sender, FormClosingEventArgs e)
  {
    Environment.Exit(0);
  }

  private void UpdateCheckbox1Checked()
  {
    this.isTeam = this.isTeamCheckBox.Checked;
  }

  private void ReSetIsTeamCheckBox()
  {
    this.isTeamCheckBox.Checked = false;
  }

  private void ResetProcessLable()
  {
    this.processLable.Text = $@"{0}/{this.MaxCount}";
  }

  private void ResetAfterStartLable()
  {
    this.afterStartLable.ForeColor = Color.Red;
    this.afterStartLable.Text = $@"     等待开始     {Environment.NewLine}开始前请确保在挑战界面";
    logger.Info(afterStartLable.Text);
  }

  private void ResetSelectBox()
  {
    challengeTypeComboBox.SelectedItem = EMPTY;
    challengeSelectionComboBox.SelectedItem = EMPTY;
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
    this.Pics.ForEach(x =>
    {
      x.Value.IsRequestToStop = true;
    });
    this.isRequestToReset = false;
    this.afterStartLable.ForeColor = Color.Red;
    this.afterStartLable.Text = @"挑战停止";
    logger.Logs(NLog.LogLevel.Info, $@"停止");
    LoggerHelper.ZipAndUploadLogs();
  }

  private void challengeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
  {
    var selectedItem = challengeTypeComboBox.SelectedItem;
    AfterChallengeSelectionList = ChallengeSelectionList.Where(x => x.StartsWith(selectedItem?.ToString() ?? EMPTY)).ToList();
    challengeSelectionComboBox.Items.Clear();
    challengeSelectionComboBox.Items.AddRange(AfterChallengeSelectionList.ToArray());
  }

  private void InitComboboxs()
  {
    challengeTypeComboBox.Items.AddRange(ChallengeTypeList.ToArray());
    challengeSelectionComboBox.Items.AddRange(ChallengeSelectionList.ToArray());
  }

}
