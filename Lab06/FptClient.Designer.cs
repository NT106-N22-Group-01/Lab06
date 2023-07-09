namespace Lab06
{
	partial class FptClient
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			buttonConnect = new Button();
			textBoxPort = new TextBox();
			labelPort = new Label();
			textBoxPassword = new TextBox();
			labelPassword = new Label();
			textBoxUsername = new TextBox();
			labelUsername = new Label();
			textBoxURL = new TextBox();
			URL = new Label();
			listViewDownload = new ListView();
			FileName = new ColumnHeader();
			Date = new ColumnHeader();
			Size = new ColumnHeader();
			groupBoxLog = new GroupBox();
			richTextBoxLog = new RichTextBox();
			buttonBrowse = new Button();
			buttonUpload = new Button();
			richTextBoxUpload = new RichTextBox();
			buttonDisconnect = new Button();
			buttonRefresh = new Button();
			groupBoxLog.SuspendLayout();
			SuspendLayout();
			// 
			// buttonConnect
			// 
			buttonConnect.Font = new Font("Open Sans Medium", 11F, FontStyle.Bold, GraphicsUnit.Point);
			buttonConnect.Location = new Point(15, 12);
			buttonConnect.Name = "buttonConnect";
			buttonConnect.Size = new Size(155, 48);
			buttonConnect.TabIndex = 17;
			buttonConnect.Text = "Connect";
			buttonConnect.UseVisualStyleBackColor = true;
			buttonConnect.Click += buttonConnect_Click;
			// 
			// textBoxPort
			// 
			textBoxPort.Font = new Font("Open Sans Medium", 11F, FontStyle.Bold, GraphicsUnit.Point);
			textBoxPort.Location = new Point(1371, 76);
			textBoxPort.Name = "textBoxPort";
			textBoxPort.Size = new Size(108, 37);
			textBoxPort.TabIndex = 16;
			textBoxPort.Text = "21";
			textBoxPort.TextAlign = HorizontalAlignment.Center;
			// 
			// labelPort
			// 
			labelPort.AutoSize = true;
			labelPort.Font = new Font("Open Sans Medium", 11F, FontStyle.Bold, GraphicsUnit.Point);
			labelPort.Location = new Point(1304, 77);
			labelPort.Name = "labelPort";
			labelPort.Size = new Size(61, 32);
			labelPort.TabIndex = 15;
			labelPort.Text = "Port";
			// 
			// textBoxPassword
			// 
			textBoxPassword.Font = new Font("Open Sans Medium", 11F, FontStyle.Bold, GraphicsUnit.Point);
			textBoxPassword.Location = new Point(1011, 74);
			textBoxPassword.Name = "textBoxPassword";
			textBoxPassword.PasswordChar = '*';
			textBoxPassword.Size = new Size(269, 37);
			textBoxPassword.TabIndex = 14;
			// 
			// labelPassword
			// 
			labelPassword.AutoSize = true;
			labelPassword.Font = new Font("Open Sans Medium", 11F, FontStyle.Bold, GraphicsUnit.Point);
			labelPassword.Location = new Point(883, 75);
			labelPassword.Name = "labelPassword";
			labelPassword.Size = new Size(122, 32);
			labelPassword.TabIndex = 13;
			labelPassword.Text = "Password";
			// 
			// textBoxUsername
			// 
			textBoxUsername.Font = new Font("Open Sans Medium", 11F, FontStyle.Bold, GraphicsUnit.Point);
			textBoxUsername.Location = new Point(584, 72);
			textBoxUsername.Name = "textBoxUsername";
			textBoxUsername.Size = new Size(269, 37);
			textBoxUsername.TabIndex = 12;
			// 
			// labelUsername
			// 
			labelUsername.AutoSize = true;
			labelUsername.Font = new Font("Open Sans Medium", 11F, FontStyle.Bold, GraphicsUnit.Point);
			labelUsername.Location = new Point(447, 75);
			labelUsername.Name = "labelUsername";
			labelUsername.Size = new Size(131, 32);
			labelUsername.TabIndex = 11;
			labelUsername.Text = "Username";
			// 
			// textBoxURL
			// 
			textBoxURL.Font = new Font("Open Sans Medium", 11F, FontStyle.Bold, GraphicsUnit.Point);
			textBoxURL.Location = new Point(187, 72);
			textBoxURL.Name = "textBoxURL";
			textBoxURL.Size = new Size(241, 37);
			textBoxURL.TabIndex = 10;
			// 
			// URL
			// 
			URL.AutoSize = true;
			URL.Font = new Font("Open Sans Medium", 11F, FontStyle.Bold, GraphicsUnit.Point);
			URL.Location = new Point(12, 72);
			URL.Name = "URL";
			URL.Size = new Size(169, 32);
			URL.TabIndex = 9;
			URL.Text = "Server URL/IP";
			// 
			// listViewDownload
			// 
			listViewDownload.Columns.AddRange(new ColumnHeader[] { FileName, Date, Size });
			listViewDownload.Location = new Point(12, 152);
			listViewDownload.Name = "listViewDownload";
			listViewDownload.Size = new Size(754, 418);
			listViewDownload.TabIndex = 18;
			listViewDownload.UseCompatibleStateImageBehavior = false;
			listViewDownload.View = View.Details;
			listViewDownload.DoubleClick += listViewDownload_DoubleClick;
			// 
			// FileName
			// 
			FileName.Text = "Name";
			FileName.Width = 500;
			// 
			// Date
			// 
			Date.Text = "Date";
			Date.Width = 165;
			// 
			// Size
			// 
			Size.Text = "Size";
			Size.Width = 80;
			// 
			// groupBoxLog
			// 
			groupBoxLog.Controls.Add(richTextBoxLog);
			groupBoxLog.Font = new Font("Open Sans Medium", 11F, FontStyle.Bold, GraphicsUnit.Point);
			groupBoxLog.Location = new Point(12, 588);
			groupBoxLog.Name = "groupBoxLog";
			groupBoxLog.Size = new Size(1467, 239);
			groupBoxLog.TabIndex = 19;
			groupBoxLog.TabStop = false;
			groupBoxLog.Text = "LOG";
			// 
			// richTextBoxLog
			// 
			richTextBoxLog.Dock = DockStyle.Fill;
			richTextBoxLog.Location = new Point(3, 33);
			richTextBoxLog.Name = "richTextBoxLog";
			richTextBoxLog.Size = new Size(1461, 203);
			richTextBoxLog.TabIndex = 0;
			richTextBoxLog.Text = "";
			// 
			// buttonBrowse
			// 
			buttonBrowse.Enabled = false;
			buttonBrowse.Font = new Font("Open Sans Medium", 11F, FontStyle.Bold, GraphicsUnit.Point);
			buttonBrowse.Location = new Point(1011, 373);
			buttonBrowse.Name = "buttonBrowse";
			buttonBrowse.Size = new Size(118, 48);
			buttonBrowse.TabIndex = 20;
			buttonBrowse.Text = "Browse";
			buttonBrowse.UseVisualStyleBackColor = true;
			buttonBrowse.Click += buttonBrowse_Click;
			// 
			// buttonUpload
			// 
			buttonUpload.Enabled = false;
			buttonUpload.Font = new Font("Open Sans Medium", 11F, FontStyle.Bold, GraphicsUnit.Point);
			buttonUpload.Location = new Point(1187, 373);
			buttonUpload.Name = "buttonUpload";
			buttonUpload.Size = new Size(118, 48);
			buttonUpload.TabIndex = 21;
			buttonUpload.Text = "Upload";
			buttonUpload.UseVisualStyleBackColor = true;
			buttonUpload.Click += buttonUpload_Click;
			// 
			// richTextBoxUpload
			// 
			richTextBoxUpload.Enabled = false;
			richTextBoxUpload.Location = new Point(793, 238);
			richTextBoxUpload.Name = "richTextBoxUpload";
			richTextBoxUpload.Size = new Size(683, 113);
			richTextBoxUpload.TabIndex = 22;
			richTextBoxUpload.Text = "";
			// 
			// buttonDisconnect
			// 
			buttonDisconnect.Enabled = false;
			buttonDisconnect.Font = new Font("Open Sans Medium", 11F, FontStyle.Bold, GraphicsUnit.Point);
			buttonDisconnect.Location = new Point(187, 12);
			buttonDisconnect.Name = "buttonDisconnect";
			buttonDisconnect.Size = new Size(155, 48);
			buttonDisconnect.TabIndex = 23;
			buttonDisconnect.Text = "Disconnect";
			buttonDisconnect.UseVisualStyleBackColor = true;
			buttonDisconnect.Click += buttonDisconnect_Click;
			// 
			// buttonRefresh
			// 
			buttonRefresh.Enabled = false;
			buttonRefresh.Font = new Font("Open Sans Medium", 11F, FontStyle.Bold, GraphicsUnit.Point);
			buttonRefresh.Location = new Point(359, 12);
			buttonRefresh.Name = "buttonRefresh";
			buttonRefresh.Size = new Size(155, 48);
			buttonRefresh.TabIndex = 24;
			buttonRefresh.Text = "Refresh";
			buttonRefresh.UseVisualStyleBackColor = true;
			buttonRefresh.Click += buttonRefresh_Click;
			// 
			// FptClient
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1502, 843);
			Controls.Add(buttonRefresh);
			Controls.Add(buttonDisconnect);
			Controls.Add(richTextBoxUpload);
			Controls.Add(buttonUpload);
			Controls.Add(buttonBrowse);
			Controls.Add(groupBoxLog);
			Controls.Add(listViewDownload);
			Controls.Add(buttonConnect);
			Controls.Add(textBoxPort);
			Controls.Add(labelPort);
			Controls.Add(textBoxPassword);
			Controls.Add(labelPassword);
			Controls.Add(textBoxUsername);
			Controls.Add(labelUsername);
			Controls.Add(textBoxURL);
			Controls.Add(URL);
			Name = "FptClient";
			Text = "FTP Client";
			groupBoxLog.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button buttonConnect;
		private TextBox textBoxPort;
		private Label labelPort;
		private TextBox textBoxPassword;
		private Label labelPassword;
		private TextBox textBoxUsername;
		private Label labelUsername;
		private TextBox textBoxURL;
		private Label URL;
		private ListView listViewDownload;
		private ColumnHeader FileName;
		private ColumnHeader Date;
		private ColumnHeader Size;
		private GroupBox groupBoxLog;
		private RichTextBox richTextBoxLog;
		private Button buttonBrowse;
		private Button buttonUpload;
		private RichTextBox richTextBoxUpload;
		private Button buttonDisconnect;
		private Button buttonRefresh;
	}
}