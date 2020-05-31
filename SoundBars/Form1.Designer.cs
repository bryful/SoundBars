namespace SoundBars
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.btnPlay = new System.Windows.Forms.Button();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.numLevelMax = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.numLevelCount = new System.Windows.Forms.NumericUpDown();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.btnExport = new System.Windows.Forms.Button();
			this.tbTargetDir = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.setdirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.btnFlat = new System.Windows.Forms.Button();
			this.btnOrg = new System.Windows.Forms.Button();
			this.makeSoundBar1 = new SoundBars.MakeSoundBar();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numLevelMax)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numLevelCount)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnPlay
			// 
			this.btnPlay.Location = new System.Drawing.Point(541, 358);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(75, 45);
			this.btnPlay.TabIndex = 12;
			this.btnPlay.Text = "Start";
			this.btnPlay.UseVisualStyleBackColor = true;
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(23, 358);
			this.trackBar1.Maximum = 0;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(505, 45);
			this.trackBar1.TabIndex = 11;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(13, 38);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(603, 19);
			this.textBox1.TabIndex = 10;
			this.textBox1.Text = "使い方はめんどくさいのでReadme.mdを読んでください。\r\npng連番に描かれたサウンドレベル表示をjsonデータに変換します。";
			// 
			// numLevelMax
			// 
			this.numLevelMax.Location = new System.Drawing.Point(359, 106);
			this.numLevelMax.Maximum = new decimal(new int[] {
            2200,
            0,
            0,
            0});
			this.numLevelMax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numLevelMax.Name = "numLevelMax";
			this.numLevelMax.Size = new System.Drawing.Size(75, 19);
			this.numLevelMax.TabIndex = 9;
			this.numLevelMax.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(241, 108);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 12);
			this.label2.TabIndex = 8;
			this.label2.Text = "Pictの幅(Levelの強さ)";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 108);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(124, 12);
			this.label1.TabIndex = 7;
			this.label1.Text = "Pictの高さ(Levelの諧調)";
			// 
			// numLevelCount
			// 
			this.numLevelCount.Location = new System.Drawing.Point(160, 106);
			this.numLevelCount.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.numLevelCount.Name = "numLevelCount";
			this.numLevelCount.Size = new System.Drawing.Size(75, 19);
			this.numLevelCount.TabIndex = 6;
			this.numLevelCount.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(47, 131);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(387, 23);
			this.progressBar1.TabIndex = 5;
			this.progressBar1.Visible = false;
			// 
			// btnExport
			// 
			this.btnExport.Location = new System.Drawing.Point(505, 113);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(111, 49);
			this.btnExport.TabIndex = 4;
			this.btnExport.Text = "Export";
			this.btnExport.UseVisualStyleBackColor = true;
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// tbTargetDir
			// 
			this.tbTargetDir.Location = new System.Drawing.Point(125, 65);
			this.tbTargetDir.Name = "tbTargetDir";
			this.tbTargetDir.ReadOnly = true;
			this.tbTargetDir.Size = new System.Drawing.Size(491, 19);
			this.tbTargetDir.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(44, 65);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Directory";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.setdirToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 409);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(644, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setdirToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// setdirToolStripMenuItem
			// 
			this.setdirToolStripMenuItem.Name = "setdirToolStripMenuItem";
			this.setdirToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.setdirToolStripMenuItem.Text = "SetDirectory";
			this.setdirToolStripMenuItem.Click += new System.EventHandler(this.setdirToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.exportToolStripMenuItem.Text = "Export";
			this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.aboutToolStripMenuItem.Text = "バージョン情報の表示";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(644, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// btnFlat
			// 
			this.btnFlat.Location = new System.Drawing.Point(47, 167);
			this.btnFlat.Name = "btnFlat";
			this.btnFlat.Size = new System.Drawing.Size(75, 23);
			this.btnFlat.TabIndex = 14;
			this.btnFlat.Text = "Flat2";
			this.btnFlat.UseVisualStyleBackColor = true;
			this.btnFlat.Click += new System.EventHandler(this.btnFlat_Click);
			// 
			// btnOrg
			// 
			this.btnOrg.Location = new System.Drawing.Point(359, 167);
			this.btnOrg.Name = "btnOrg";
			this.btnOrg.Size = new System.Drawing.Size(75, 23);
			this.btnOrg.TabIndex = 15;
			this.btnOrg.Text = "元に";
			this.btnOrg.UseVisualStyleBackColor = true;
			this.btnOrg.Click += new System.EventHandler(this.btnOrg_Click);
			// 
			// makeSoundBar1
			// 
			this.makeSoundBar1.LevelCount = 18;
			this.makeSoundBar1.LevelMax = 255;
			this.makeSoundBar1.Location = new System.Drawing.Point(13, 196);
			this.makeSoundBar1.Name = "makeSoundBar1";
			this.makeSoundBar1.NumLavelCount = this.numLevelCount;
			this.makeSoundBar1.NumLavelMax = this.numLevelMax;
			this.makeSoundBar1.PlayBtn = this.btnPlay;
			this.makeSoundBar1.ProgressBar = this.progressBar1;
			this.makeSoundBar1.Size = new System.Drawing.Size(603, 156);
			this.makeSoundBar1.TabIndex = 13;
			this.makeSoundBar1.Text = "makeSoundBar2";
			this.makeSoundBar1.TrackBar = this.trackBar1;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(128, 167);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 16;
			this.button2.Text = "Flat3";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(644, 431);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btnOrg);
			this.Controls.Add(this.btnFlat);
			this.Controls.Add(this.makeSoundBar1);
			this.Controls.Add(this.btnPlay);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.numLevelMax);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.numLevelCount);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tbTargetDir);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximumSize = new System.Drawing.Size(660, 470);
			this.MinimumSize = new System.Drawing.Size(660, 470);
			this.Name = "Form1";
			this.Text = "SoundBars";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numLevelMax)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numLevelCount)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnPlay;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.NumericUpDown numLevelMax;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numLevelCount;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.TextBox tbTargetDir;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem setdirToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private MakeSoundBar makeSoundBar1;
		private System.Windows.Forms.Button btnFlat;
		private System.Windows.Forms.Button btnOrg;
		private System.Windows.Forms.Button button2;
	}
}

