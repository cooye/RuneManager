﻿namespace RuneApp
{
    partial class Generate
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
			this.loadoutList = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_runtest = new System.Windows.Forms.Button();
			this.btn_powerrunes = new System.Windows.Forms.Button();
			this.btnHelp = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.runeBox = new RuneApp.RuneBox();
			this.runeDial = new RuneApp.RuneDial();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBox1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// loadoutList
			// 
			this.loadoutList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.loadoutList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.loadoutList.FullRowSelect = true;
			this.loadoutList.Location = new System.Drawing.Point(12, 12);
			this.loadoutList.Name = "loadoutList";
			this.loadoutList.Size = new System.Drawing.Size(718, 693);
			this.loadoutList.Sorting = System.Windows.Forms.SortOrder.Descending;
			this.loadoutList.TabIndex = 0;
			this.loadoutList.UseCompatibleStateImageBehavior = false;
			this.loadoutList.View = System.Windows.Forms.View.Details;
			this.loadoutList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
			this.loadoutList.SelectedIndexChanged += new System.EventHandler(this.loadoutList_SelectedIndexChanged);
			this.loadoutList.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Points";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Levels";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btn_runtest);
			this.groupBox1.Controls.Add(this.btn_powerrunes);
			this.groupBox1.Controls.Add(this.btnHelp);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.runeBox);
			this.groupBox1.Controls.Add(this.runeDial);
			this.groupBox1.Location = new System.Drawing.Point(736, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(260, 693);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Scoring";
			// 
			// btn_runtest
			// 
			this.btn_runtest.Location = new System.Drawing.Point(179, 48);
			this.btn_runtest.Name = "btn_runtest";
			this.btn_runtest.Size = new System.Drawing.Size(75, 23);
			this.btn_runtest.TabIndex = 102;
			this.btn_runtest.Text = "Run";
			this.btn_runtest.UseVisualStyleBackColor = true;
			this.btn_runtest.Click += new System.EventHandler(this.btn_runtest_Click);
			// 
			// btn_powerrunes
			// 
			this.btn_powerrunes.Location = new System.Drawing.Point(179, 77);
			this.btn_powerrunes.Name = "btn_powerrunes";
			this.btn_powerrunes.Size = new System.Drawing.Size(75, 23);
			this.btn_powerrunes.TabIndex = 101;
			this.btn_powerrunes.Text = "Powerups";
			this.btn_powerrunes.UseVisualStyleBackColor = true;
			this.btn_powerrunes.Click += new System.EventHandler(this.btn_powerrunes_Click);
			// 
			// btnHelp
			// 
			this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnHelp.Location = new System.Drawing.Point(209, 19);
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(45, 23);
			this.btnHelp.TabIndex = 89;
			this.btnHelp.Text = "Help?";
			this.btnHelp.UseVisualStyleBackColor = true;
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(179, 664);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 0;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(98, 664);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// runeBox
			// 
			this.runeBox.Location = new System.Drawing.Point(6, 472);
			this.runeBox.Name = "runeBox";
			this.runeBox.Size = new System.Drawing.Size(248, 186);
			this.runeBox.TabIndex = 104;
			this.runeBox.TabStop = false;
			this.runeBox.Text = "runeBox1";
			this.runeBox.Visible = false;
			this.runeBox.OnClickHide += new System.EventHandler(this.runeBox_hidden);
			// 
			// runeDial
			// 
			this.runeDial.Loadout = null;
			this.runeDial.Location = new System.Drawing.Point(-13, 309);
			this.runeDial.Name = "runeDial";
			this.runeDial.Size = new System.Drawing.Size(225, 175);
			this.runeDial.TabIndex = 103;
			this.runeDial.RuneClick += new System.EventHandler<RuneApp.RuneClickEventArgs>(this.runeDial_RuneClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 708);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Maximum = 1000;
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 16);
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// Generate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 730);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.loadoutList);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Generate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Generate";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Generate_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.ListView loadoutList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btn_powerrunes;
        private System.Windows.Forms.Button btn_runtest;
		private RuneDial runeDial;
		private RuneBox runeBox;
	}
}