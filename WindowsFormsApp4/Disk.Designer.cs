
using System;

namespace DiskTest11
{
    partial class Disk
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartTest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SectorSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFT_SectorSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TestDataMode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CircleNumble = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TestMode = new System.Windows.Forms.ComboBox();
            this.TestTime = new System.Windows.Forms.TextBox();
            this.TestNum = new System.Windows.Forms.TextBox();
            this.TestPercent = new System.Windows.Forms.TextBox();
            this.BlockSize = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TestOrNot = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartTest
            // 
            this.StartTest.Location = new System.Drawing.Point(315, 712);
            this.StartTest.Name = "StartTest";
            this.StartTest.Size = new System.Drawing.Size(156, 37);
            this.StartTest.TabIndex = 12;
            this.StartTest.Text = "开始测试";
            this.StartTest.UseVisualStyleBackColor = true;
            this.StartTest.Click += new System.EventHandler(this.StartTestClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 694);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Disk selection";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.Size,
            this.Column3,
            this.SectorSize,
            this.DFT_SectorSize});
            this.dataGridView1.Location = new System.Drawing.Point(34, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(673, 137);
            this.dataGridView1.TabIndex = 9;
            // 
            // name
            // 
            this.name.HeaderText = "Drive";
            this.name.MinimumWidth = 8;
            this.name.Name = "name";
            this.name.Width = 150;
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.MinimumWidth = 8;
            this.Size.Name = "Size";
            this.Size.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "属性";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // SectorSize
            // 
            this.SectorSize.HeaderText = "扇区总数";
            this.SectorSize.MinimumWidth = 8;
            this.SectorSize.Name = "SectorSize";
            this.SectorSize.Width = 150;
            // 
            // DFT_SectorSize
            // 
            this.DFT_SectorSize.HeaderText = "扇区大小";
            this.DFT_SectorSize.MinimumWidth = 8;
            this.DFT_SectorSize.Name = "DFT_SectorSize";
            this.DFT_SectorSize.Width = 150;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TestDataMode);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.CircleNumble);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TestMode);
            this.groupBox2.Controls.Add(this.TestTime);
            this.groupBox2.Controls.Add(this.TestNum);
            this.groupBox2.Controls.Add(this.TestPercent);
            this.groupBox2.Controls.Add(this.BlockSize);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.TestOrNot);
            this.groupBox2.Location = new System.Drawing.Point(34, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(673, 459);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edit details";
            // 
            // TestDataMode
            // 
            this.TestDataMode.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TestDataMode.FormattingEnabled = true;
            this.TestDataMode.Items.AddRange(new object[] {
            "全0",
            "全1",
            "随机数"});
            this.TestDataMode.Location = new System.Drawing.Point(153, 129);
            this.TestDataMode.Name = "TestDataMode";
            this.TestDataMode.Size = new System.Drawing.Size(130, 39);
            this.TestDataMode.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 31);
            this.label7.TabIndex = 20;
            this.label7.Text = "数据类型";
            // 
            // CircleNumble
            // 
            this.CircleNumble.Location = new System.Drawing.Point(153, 406);
            this.CircleNumble.Name = "CircleNumble";
            this.CircleNumble.Size = new System.Drawing.Size(130, 39);
            this.CircleNumble.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 409);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 31);
            this.label6.TabIndex = 18;
            this.label6.Text = "循环次数";
            // 
            // TestMode
            // 
            this.TestMode.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TestMode.FormattingEnabled = true;
            this.TestMode.Items.AddRange(new object[] {
            "随机读写验证",
            "随机只读",
            "随机只写",
            "顺序读写验证",
            "顺序只读",
            "顺序只写"});
            this.TestMode.Location = new System.Drawing.Point(153, 74);
            this.TestMode.Name = "TestMode";
            this.TestMode.Size = new System.Drawing.Size(488, 39);
            this.TestMode.TabIndex = 17;
            // 
            // TestTime
            // 
            this.TestTime.Location = new System.Drawing.Point(153, 360);
            this.TestTime.Name = "TestTime";
            this.TestTime.Size = new System.Drawing.Size(130, 39);
            this.TestTime.TabIndex = 10;
            // 
            // TestNum
            // 
            this.TestNum.Location = new System.Drawing.Point(153, 310);
            this.TestNum.Name = "TestNum";
            this.TestNum.Size = new System.Drawing.Size(130, 39);
            this.TestNum.TabIndex = 9;
            // 
            // TestPercent
            // 
            this.TestPercent.Location = new System.Drawing.Point(153, 184);
            this.TestPercent.Name = "TestPercent";
            this.TestPercent.Size = new System.Drawing.Size(130, 39);
            this.TestPercent.TabIndex = 8;
            // 
            // BlockSize
            // 
            this.BlockSize.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BlockSize.DisplayMember = "1";
            this.BlockSize.FormattingEnabled = true;
            this.BlockSize.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.BlockSize.Location = new System.Drawing.Point(153, 248);
            this.BlockSize.Name = "BlockSize";
            this.BlockSize.Size = new System.Drawing.Size(130, 39);
            this.BlockSize.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 31);
            this.label5.TabIndex = 6;
            this.label5.Text = "测试时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 31);
            this.label4.TabIndex = 5;
            this.label4.Text = "测试次数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Block size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "测试容量";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "测试模式";
            // 
            // TestOrNot
            // 
            this.TestOrNot.AutoSize = true;
            this.TestOrNot.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TestOrNot.Location = new System.Drawing.Point(6, 27);
            this.TestOrNot.Name = "TestOrNot";
            this.TestOrNot.Size = new System.Drawing.Size(200, 35);
            this.TestOrNot.TabIndex = 0;
            this.TestOrNot.Text = "Test this drive";
            this.TestOrNot.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(34, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(686, 35);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Automatically select all fixed drives at the start of testing";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Disk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 761);
            this.Controls.Add(this.StartTest);
            this.Controls.Add(this.groupBox1);
            this.Name = "Disk";
            this.Text = "Disk";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion
        private System.Windows.Forms.Button StartTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox TestMode;
        private System.Windows.Forms.TextBox TestTime;
        private System.Windows.Forms.TextBox TestNum;
        private System.Windows.Forms.TextBox TestPercent;
        private System.Windows.Forms.ComboBox BlockSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox TestOrNot;
        private System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.DataGridViewTextBoxColumn name;
        public System.Windows.Forms.DataGridViewTextBoxColumn Size;
        public System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        public System.Windows.Forms.DataGridViewTextBoxColumn SectorSize;
        public System.Windows.Forms.DataGridViewTextBoxColumn DFT_SectorSize;
        public System.Windows.Forms.ComboBox TestDataMode;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CircleNumble;
        private System.Windows.Forms.Label label6;
    }
}