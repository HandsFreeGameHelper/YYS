using ScreenCaptureApp.Utils;
using System.Windows.Forms;
using static ScreenCaptureApp.Main.ChallengeFactory;
using static ScreenCaptureApp.Utils.Contains;

namespace ScreenCaptureApp.UI
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private PictureBox pictureBox1;
    private PictureBox pictureBox2;
    private List<PictureBox> pictureBoxes = new();
    private Button button1;
    private Button button2;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      button1 = new Button();
      button2 = new Button();
      pictureBox1 = new PictureBox();
      pictureBox2 = new PictureBox();
      richTextBox1 = new RichTextBox();
      button3 = new Button();
      comboBox1 = new ComboBox();
      label1 = new Label();
      comboBox2 = new ComboBox();
      label2 = new Label();
      button4 = new Button();
      textBox1 = new TextBox();
      label3 = new Label();
      label4 = new Label();
      label6 = new Label();
      button5 = new Button();
      label7 = new Label();
      label8 = new Label();
      label9 = new Label();
      label10 = new Label();
      groupBox1 = new GroupBox();
      label15 = new Label();
      label14 = new Label();
      label13 = new Label();
      label12 = new Label();
      button6 = new Button();
      comboBox4 = new ComboBox();
      comboBox3 = new ComboBox();
      label11 = new Label();
      checkBox1 = new CheckBox();
      YYS = new TabControl();
      tabPage1 = new TabPage();
      label16 = new Label();
      tabPage2 = new TabPage();
      groupBox2 = new GroupBox();
      tabPage3 = new TabPage();
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
      groupBox1.SuspendLayout();
      YYS.SuspendLayout();
      tabPage1.SuspendLayout();
      tabPage2.SuspendLayout();
      groupBox2.SuspendLayout();
      tabPage3.SuspendLayout();
      SuspendLayout();
      // 
      // button1
      // 
      button1.Location = new Point(487, 332);
      button1.Name = "button1";
      button1.Size = new Size(75, 23);
      button1.TabIndex = 0;
      button1.Text = "开始";
      button1.UseVisualStyleBackColor = true;
      button1.Click += button1_Click;
      // 
      // button2
      // 
      button2.Location = new Point(666, 335);
      button2.Name = "button2";
      button2.Size = new Size(75, 23);
      button2.TabIndex = 1;
      button2.Text = "停止";
      button2.UseVisualStyleBackColor = true;
      button2.Click += button2_Click;
      // 
      // pictureBox1
      // 
      pictureBox1.Location = new Point(380, 50);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new Size(354, 209);
      pictureBox1.TabIndex = 2;
      pictureBox1.TabStop = false;
      // 
      // pictureBox2
      // 
      pictureBox2.Location = new Point(6, 50);
      pictureBox2.Name = "pictureBox2";
      pictureBox2.Size = new Size(361, 209);
      pictureBox2.TabIndex = 22;
      pictureBox2.TabStop = false;
      // 
      // richTextBox1
      // 
      richTextBox1.Location = new Point(487, 6);
      richTextBox1.Name = "richTextBox1";
      richTextBox1.Size = new Size(254, 292);
      richTextBox1.TabIndex = 3;
      richTextBox1.Text = "";
      // 
      // button3
      // 
      button3.Location = new Point(584, 304);
      button3.Name = "button3";
      button3.Size = new Size(75, 23);
      button3.TabIndex = 4;
      button3.Text = "清空";
      button3.UseVisualStyleBackColor = true;
      button3.Click += button3_Click;
      // 
      // comboBox1
      // 
      comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox1.FormattingEnabled = true;
      comboBox1.Items.AddRange(new object[] { "", "普通副本", "突破" });
      comboBox1.Location = new Point(66, 52);
      comboBox1.Name = "comboBox1";
      comboBox1.Size = new Size(121, 25);
      comboBox1.TabIndex = 5;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(3, 55);
      label1.Name = "label1";
      label1.Size = new Size(56, 17);
      label1.TabIndex = 6;
      label1.Text = "挑战类型";
      // 
      // comboBox2
      // 
      comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox2.FormattingEnabled = true;
      comboBox2.Items.AddRange(new object[] { "", "个人", "阴阳寮", "觉醒副本任意层", "御灵任意层", "八岐大蛇1-10层", "八岐大蛇11层", "八岐大蛇12层", "卑弥呼1层", "卑弥呼2层", "卑弥呼3层", "业原火贪", "业原火嗔", "业原火痴", "永生之海1层", "永生之海2层", "永生之海3-4层" });
      comboBox2.Location = new Point(66, 97);
      comboBox2.Name = "comboBox2";
      comboBox2.Size = new Size(121, 25);
      comboBox2.TabIndex = 7;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(3, 102);
      label2.Name = "label2";
      label2.Size = new Size(56, 17);
      label2.TabIndex = 8;
      label2.Text = "挑战关卡";
      // 
      // button4
      // 
      button4.Location = new Point(6, 265);
      button4.Name = "button4";
      button4.Size = new Size(75, 23);
      button4.TabIndex = 9;
      button4.Text = "确定";
      button4.UseVisualStyleBackColor = true;
      button4.Click += button4_Click;
      // 
      // textBox1
      // 
      textBox1.Location = new Point(65, 143);
      textBox1.Name = "textBox1";
      textBox1.Size = new Size(122, 23);
      textBox1.TabIndex = 10;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(3, 147);
      label3.Name = "label3";
      label3.Size = new Size(56, 17);
      label3.TabIndex = 11;
      label3.Text = "挑战次数";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.ForeColor = Color.Red;
      label4.Location = new Point(65, 174);
      label4.Name = "label4";
      label4.Size = new Size(118, 17);
      label4.TabIndex = 12;
      label4.Text = "*注意：不得超过150";
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.BackColor = Color.Red;
      label6.Location = new Point(3, 22);
      label6.Name = "label6";
      label6.Size = new Size(289, 17);
      label6.TabIndex = 14;
      label6.Text = "*设置前请确保在停止的状态下，如已开始，请先停止";
      // 
      // button5
      // 
      button5.Location = new Point(125, 265);
      button5.Name = "button5";
      button5.Size = new Size(75, 23);
      button5.TabIndex = 15;
      button5.Text = "重置";
      button5.UseVisualStyleBackColor = true;
      button5.Click += button5_Click;
      // 
      // label7
      // 
      label7.AutoSize = true;
      label7.Location = new Point(6, 335);
      label7.Name = "label7";
      label7.Size = new Size(56, 17);
      label7.TabIndex = 16;
      label7.Text = "挑战进度";
      // 
      // label8
      // 
      label8.AutoSize = true;
      label8.Location = new Point(78, 335);
      label8.Name = "label8";
      label8.Size = new Size(27, 17);
      label8.TabIndex = 17;
      label8.Text = "0/0";
      // 
      // label9
      // 
      label9.AutoSize = true;
      label9.Location = new Point(144, 335);
      label9.Name = "label9";
      label9.Size = new Size(56, 17);
      label9.TabIndex = 18;
      label9.Text = "当前状态";
      // 
      // label10
      // 
      label10.AutoSize = true;
      label10.Location = new Point(217, 335);
      label10.Name = "label10";
      label10.Size = new Size(12, 17);
      label10.TabIndex = 19;
      label10.Text = " ";
      // 
      // groupBox1
      // 
      groupBox1.Controls.Add(label15);
      groupBox1.Controls.Add(label14);
      groupBox1.Controls.Add(label13);
      groupBox1.Controls.Add(label12);
      groupBox1.Controls.Add(button6);
      groupBox1.Controls.Add(comboBox4);
      groupBox1.Controls.Add(comboBox3);
      groupBox1.Location = new Point(19, 54);
      groupBox1.Name = "groupBox1";
      groupBox1.Size = new Size(288, 288);
      groupBox1.TabIndex = 20;
      groupBox1.TabStop = false;
      groupBox1.Text = "校准";
      // 
      // label15
      // 
      label15.AutoSize = true;
      label15.ForeColor = Color.Red;
      label15.Location = new Point(63, 28);
      label15.Name = "label15";
      label15.Size = new Size(129, 34);
      label15.TabIndex = 7;
      label15.Text = "画面分辨率\n 801*481~2038*1178";
      // 
      // label14
      // 
      label14.AutoSize = true;
      label14.Location = new Point(47, 199);
      label14.Name = "label14";
      label14.Size = new Size(176, 17);
      label14.TabIndex = 6;
      label14.Text = "请提前到对应画面后再点击校准";
      // 
      // label13
      // 
      label13.AutoSize = true;
      label13.Location = new Point(71, 137);
      label13.Name = "label13";
      label13.Size = new Size(61, 17);
      label13.TabIndex = 5;
      label13.Text = "开始/结算";
      // 
      // label12
      // 
      label12.AutoSize = true;
      label12.Location = new Point(71, 73);
      label12.Name = "label12";
      label12.Size = new Size(56, 17);
      label12.TabIndex = 4;
      label12.Text = "校准模式";
      // 
      // button6
      // 
      button6.Location = new Point(101, 239);
      button6.Name = "button6";
      button6.Size = new Size(75, 23);
      button6.TabIndex = 3;
      button6.Text = "校准";
      button6.UseVisualStyleBackColor = true;
      button6.Click += button6_Click;
      // 
      // comboBox4
      // 
      comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox4.FormattingEnabled = true;
      comboBox4.Items.AddRange(new object[] { "", "开始画面", "结算画面" });
      comboBox4.Location = new Point(71, 155);
      comboBox4.Name = "comboBox4";
      comboBox4.Size = new Size(121, 25);
      comboBox4.TabIndex = 1;
      // 
      // comboBox3
      // 
      comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox3.FormattingEnabled = true;
      comboBox3.Items.AddRange(new object[] { "", "任意御魂副本通用", "任意觉醒副本通用", "任意御灵副本通用" });
      comboBox3.Location = new Point(71, 93);
      comboBox3.Name = "comboBox3";
      comboBox3.Size = new Size(121, 25);
      comboBox3.TabIndex = 0;
      // 
      // label11
      // 
      label11.AutoSize = true;
      label11.ForeColor = Color.DarkOrange;
      label11.Location = new Point(8, 19);
      label11.Name = "label11";
      label11.Size = new Size(176, 17);
      label11.TabIndex = 0;
      label11.Text = "首次使用或开始后无反应时使用";
      // 
      // checkBox1
      // 
      checkBox1.AutoSize = true;
      checkBox1.Location = new Point(217, 147);
      checkBox1.Name = "checkBox1";
      checkBox1.Size = new Size(75, 21);
      checkBox1.TabIndex = 21;
      checkBox1.Text = "组队挑战";
      checkBox1.UseVisualStyleBackColor = true;
      // 
      // YYS
      // 
      YYS.Controls.Add(tabPage1);
      YYS.Controls.Add(tabPage2);
      YYS.Controls.Add(tabPage3);
      YYS.Location = new Point(12, 12);
      YYS.Name = "YYS";
      YYS.SelectedIndex = 0;
      YYS.Size = new Size(781, 409);
      YYS.TabIndex = 23;
      // 
      // tabPage1
      // 
      tabPage1.Controls.Add(label16);
      tabPage1.Controls.Add(button3);
      tabPage1.Controls.Add(button2);
      tabPage1.Controls.Add(richTextBox1);
      tabPage1.Controls.Add(button1);
      tabPage1.Controls.Add(label10);
      tabPage1.Controls.Add(label9);
      tabPage1.Controls.Add(label8);
      tabPage1.Controls.Add(label7);
      tabPage1.Controls.Add(label6);
      tabPage1.Controls.Add(label1);
      tabPage1.Controls.Add(checkBox1);
      tabPage1.Controls.Add(label2);
      tabPage1.Controls.Add(comboBox1);
      tabPage1.Controls.Add(comboBox2);
      tabPage1.Controls.Add(label3);
      tabPage1.Controls.Add(textBox1);
      tabPage1.Controls.Add(button5);
      tabPage1.Controls.Add(label4);
      tabPage1.Controls.Add(button4);
      tabPage1.Location = new Point(4, 26);
      tabPage1.Name = "tabPage1";
      tabPage1.Padding = new Padding(3);
      tabPage1.Size = new Size(773, 379);
      tabPage1.TabIndex = 0;
      tabPage1.Text = "设定";
      tabPage1.UseVisualStyleBackColor = true;
      // 
      // label16
      // 
      label16.AutoSize = true;
      label16.Location = new Point(6, 218);
      label16.Name = "label16";
      label16.Size = new Size(0, 17);
      label16.TabIndex = 22;
      // 
      // tabPage2
      // 
      tabPage2.Controls.Add(groupBox2);
      tabPage2.Location = new Point(4, 26);
      tabPage2.Name = "tabPage2";
      tabPage2.Padding = new Padding(3);
      tabPage2.Size = new Size(773, 379);
      tabPage2.TabIndex = 1;
      tabPage2.Text = "开始";
      tabPage2.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      groupBox2.Controls.Add(pictureBox1);
      groupBox2.Controls.Add(pictureBox2);
      groupBox2.Location = new Point(14, 25);
      groupBox2.Name = "groupBox2";
      groupBox2.Size = new Size(744, 298);
      groupBox2.TabIndex = 23;
      groupBox2.TabStop = false;
      groupBox2.Text = "画面";
      // 
      // tabPage3
      // 
      tabPage3.Controls.Add(label11);
      tabPage3.Controls.Add(groupBox1);
      tabPage3.Location = new Point(4, 26);
      tabPage3.Name = "tabPage3";
      tabPage3.Padding = new Padding(3);
      tabPage3.Size = new Size(773, 379);
      tabPage3.TabIndex = 2;
      tabPage3.Text = "校准";
      tabPage3.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(7F, 17F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(808, 428);
      Controls.Add(YYS);
      FormBorderStyle = FormBorderStyle.Fixed3D;
      MaximizeBox = false;
      Name = "Form1";
      Text = "YYS";
      FormClosing += Form1_FormClosing;
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
      groupBox1.ResumeLayout(false);
      groupBox1.PerformLayout();
      YYS.ResumeLayout(false);
      tabPage1.ResumeLayout(false);
      tabPage1.PerformLayout();
      tabPage2.ResumeLayout(false);
      groupBox2.ResumeLayout(false);
      tabPage3.ResumeLayout(false);
      tabPage3.PerformLayout();
      ResumeLayout(false);
    }

    #endregion
    private RichTextBox richTextBox1;
    private Button button3;
    private ComboBox comboBox1;
    private Label label1;
    private ComboBox comboBox2;
    private Label label2;
    private Button button4;
    private TextBox textBox1;
    private Label label3;
    private Label label4;
    private Label label6;
    private Button button5;
    private Label label7;
    private Label label8;
    private Label label9;
    private Label label10;
    private GroupBox groupBox1;
    private ComboBox comboBox4;
    private ComboBox comboBox3;
    private Label label11;
    private Label label14;
    private Label label13;
    private Label label12;
    private Button button6;
    private Label label15;
    private CheckBox checkBox1;
    private TabControl YYS;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TabPage tabPage3;
    private Label label16;
    private GroupBox groupBox2;
  }
}