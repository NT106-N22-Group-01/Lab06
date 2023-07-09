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
			SuspendLayout();
			// 
			// buttonConnect
			// 
			buttonConnect.Font = new Font("Open Sans Medium", 11F, FontStyle.Bold, GraphicsUnit.Point);
			buttonConnect.Location = new Point(12, 12);
			buttonConnect.Name = "buttonConnect";
			buttonConnect.Size = new Size(118, 48);
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
			// FptClient
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1502, 617);
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
			Text = "Form1";
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
	}
}