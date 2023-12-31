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
      label5 = new Label();
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
      ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
      groupBox1.SuspendLayout();
      SuspendLayout();
      // 
      // button1
      // 
      button1.Location = new Point(711, 423);
      button1.Name = "button1";
      button1.Size = new Size(75, 23);
      button1.TabIndex = 0;
      button1.Text = "开始";
      button1.UseVisualStyleBackColor = true;
      button1.Click += button1_Click;
      // 
      // button2
      // 
      button2.Location = new Point(836, 423);
      button2.Name = "button2";
      button2.Size = new Size(75, 23);
      button2.TabIndex = 1;
      button2.Text = "停止";
      button2.UseVisualStyleBackColor = true;
      button2.Click += button2_Click;
      // 
      // pictureBox1
      // 
      pictureBox1.Location = new Point(0, 0);
      pictureBox1.Name = "pictureBox1";
      pictureBox1.Size = new Size(576, 320);
      pictureBox1.TabIndex = 2;
      pictureBox1.TabStop = false;
      // 
      // richTextBox1
      // 
      richTextBox1.Location = new Point(593, 12);
      richTextBox1.Name = "richTextBox1";
      richTextBox1.Size = new Size(254, 292);
      richTextBox1.TabIndex = 3;
      richTextBox1.Text = "";
      // 
      // button3
      // 
      button3.Location = new Point(679, 317);
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
      comboBox1.Items.AddRange(new object[] { "", "普通副本" });
      comboBox1.Location = new Point(30, 371);
      comboBox1.Name = "comboBox1";
      comboBox1.Size = new Size(121, 25);
      comboBox1.TabIndex = 5;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(55, 347);
      label1.Name = "label1";
      label1.Size = new Size(56, 17);
      label1.TabIndex = 6;
      label1.Text = "挑战类型";
      // 
      // comboBox2
      // 
      comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox2.FormattingEnabled = true;
      comboBox2.Items.AddRange(new object[] { "", "觉醒副本任意层", "御灵任意层", "八岐大蛇1-10层", "八岐大蛇11层", "八岐大蛇12层", "卑弥呼1层", "卑弥呼2层", "卑弥呼3层", "业原火贪", "业原火嗔", "业原火痴", "永生之海1层", "永生之海2层", "永生之海3-4层", "", "任意御魂副本通用", "任意御灵副本通用", "任意觉醒副本通用", "", "开始画面", "结算画面" });
      comboBox2.Location = new Point(179, 371);
      comboBox2.Name = "comboBox2";
      comboBox2.Size = new Size(121, 25);
      comboBox2.TabIndex = 7;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(212, 347);
      label2.Name = "label2";
      label2.Size = new Size(56, 17);
      label2.TabIndex = 8;
      label2.Text = "挑战关卡";
      // 
      // button4
      // 
      button4.Location = new Point(103, 428);
      button4.Name = "button4";
      button4.Size = new Size(75, 23);
      button4.TabIndex = 9;
      button4.Text = "确定";
      button4.UseVisualStyleBackColor = true;
      button4.Click += button4_Click;
      // 
      // textBox1
      // 
      textBox1.Location = new Point(325, 373);
      textBox1.Name = "textBox1";
      textBox1.Size = new Size(100, 23);
      textBox1.TabIndex = 10;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(339, 347);
      label3.Name = "label3";
      label3.Size = new Size(56, 17);
      label3.TabIndex = 11;
      label3.Text = "挑战次数";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.ForeColor = Color.Red;
      label4.Location = new Point(314, 399);
      label4.Name = "label4";
      label4.Size = new Size(118, 17);
      label4.TabIndex = 12;
      label4.Text = "*注意：不得超过150";
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new Point(70, 460);
      label5.Name = "label5";
      label5.Size = new Size(0, 17);
      label5.TabIndex = 13;
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.BackColor = Color.Red;
      label6.Location = new Point(30, 323);
      label6.Name = "label6";
      label6.Size = new Size(289, 17);
      label6.TabIndex = 14;
      label6.Text = "*设置前请确保在停止的状态下，如已开始，请先停止";
      // 
      // button5
      // 
      button5.Location = new Point(203, 428);
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
      label7.Location = new Point(459, 347);
      label7.Name = "label7";
      label7.Size = new Size(56, 17);
      label7.TabIndex = 16;
      label7.Text = "挑战进度";
      // 
      // label8
      // 
      label8.AutoSize = true;
      label8.Location = new Point(472, 379);
      label8.Name = "label8";
      label8.Size = new Size(27, 17);
      label8.TabIndex = 17;
      label8.Text = "0/0";
      // 
      // label9
      // 
      label9.AutoSize = true;
      label9.Location = new Point(579, 347);
      label9.Name = "label9";
      label9.Size = new Size(56, 17);
      label9.TabIndex = 18;
      label9.Text = "当前状态";
      // 
      // label10
      // 
      label10.AutoSize = true;
      label10.Location = new Point(564, 379);
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
      groupBox1.Location = new Point(853, 43);
      groupBox1.Name = "groupBox1";
      groupBox1.Size = new Size(176, 233);
      groupBox1.TabIndex = 20;
      groupBox1.TabStop = false;
      groupBox1.Text = "校准";
      // 
      // label15
      // 
      label15.AutoSize = true;
      label15.ForeColor = Color.Red;
      label15.Location = new Point(6, 19);
      label15.Name = "label15";
      label15.Size = new Size(129, 34);
      label15.TabIndex = 7;
      label15.Text = "画面分辨率\n 801*481~2038*1178";
      // 
      // label14
      // 
      label14.AutoSize = true;
      label14.Location = new Point(0, 160);
      label14.Name = "label14";
      label14.Size = new Size(176, 17);
      label14.TabIndex = 6;
      label14.Text = "请提前到对应画面后再点击校准";
      // 
      // label13
      // 
      label13.AutoSize = true;
      label13.Location = new Point(21, 101);
      label13.Name = "label13";
      label13.Size = new Size(61, 17);
      label13.TabIndex = 5;
      label13.Text = "开始/结算";
      // 
      // label12
      // 
      label12.AutoSize = true;
      label12.Location = new Point(21, 53);
      label12.Name = "label12";
      label12.Size = new Size(56, 17);
      label12.TabIndex = 4;
      label12.Text = "校准模式";
      // 
      // button6
      // 
      button6.Location = new Point(42, 194);
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
      comboBox4.Location = new Point(21, 121);
      comboBox4.Name = "comboBox4";
      comboBox4.Size = new Size(121, 25);
      comboBox4.TabIndex = 1;
      // 
      // comboBox3
      // 
      comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox3.FormattingEnabled = true;
      comboBox3.Items.AddRange(new object[] { "", "任意御魂副本通用", "任意觉醒副本通用", "任意御灵副本通用" });
      comboBox3.Location = new Point(21, 73);
      comboBox3.Name = "comboBox3";
      comboBox3.Size = new Size(121, 25);
      comboBox3.TabIndex = 0;
      // 
      // label11
      // 
      label11.AutoSize = true;
      label11.ForeColor = Color.DarkOrange;
      label11.Location = new Point(853, 23);
      label11.Name = "label11";
      label11.Size = new Size(176, 17);
      label11.TabIndex = 0;
      label11.Text = "首次使用或开始后无反应时使用";
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(7F, 17F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1032, 484);
      Controls.Add(label11);
      Controls.Add(groupBox1);
      Controls.Add(label10);
      Controls.Add(label9);
      Controls.Add(label8);
      Controls.Add(label7);
      Controls.Add(button5);
      Controls.Add(label6);
      Controls.Add(label5);
      Controls.Add(label4);
      Controls.Add(label3);
      Controls.Add(textBox1);
      Controls.Add(button4);
      Controls.Add(label2);
      Controls.Add(comboBox2);
      Controls.Add(label1);
      Controls.Add(comboBox1);
      Controls.Add(button3);
      Controls.Add(richTextBox1);
      Controls.Add(pictureBox1);
      Controls.Add(button2);
      Controls.Add(button1);
      Name = "Form1";
      Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
      groupBox1.ResumeLayout(false);
      groupBox1.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
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
    private Label label5;
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
  }
}