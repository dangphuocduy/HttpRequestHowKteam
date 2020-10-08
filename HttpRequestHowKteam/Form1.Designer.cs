namespace HttpRequestHowKteam
{
    partial class Form1
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
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnGetDataWithCookies = new System.Windows.Forms.Button();
            this.btnPostDataLogin = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.btnVerifyEmail = new System.Windows.Forms.Button();
            this.btnDowloadFile = new System.Windows.Forms.Button();
            this.btnFakeIP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(21, 23);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 0;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnGetDataWithCookies
            // 
            this.btnGetDataWithCookies.Location = new System.Drawing.Point(114, 23);
            this.btnGetDataWithCookies.Name = "btnGetDataWithCookies";
            this.btnGetDataWithCookies.Size = new System.Drawing.Size(153, 23);
            this.btnGetDataWithCookies.TabIndex = 0;
            this.btnGetDataWithCookies.Text = "Get Data With Cookies";
            this.btnGetDataWithCookies.UseVisualStyleBackColor = true;
            this.btnGetDataWithCookies.Click += new System.EventHandler(this.btnGetDataWithCookies_Click);
            // 
            // btnPostDataLogin
            // 
            this.btnPostDataLogin.Location = new System.Drawing.Point(273, 23);
            this.btnPostDataLogin.Name = "btnPostDataLogin";
            this.btnPostDataLogin.Size = new System.Drawing.Size(153, 23);
            this.btnPostDataLogin.TabIndex = 0;
            this.btnPostDataLogin.Text = "Post Login";
            this.btnPostDataLogin.UseVisualStyleBackColor = true;
            this.btnPostDataLogin.Click += new System.EventHandler(this.btnPostDataLogin_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(21, 100);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(153, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Tra cứu hoá đơn";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Location = new System.Drawing.Point(191, 100);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(153, 23);
            this.btnUploadFile.TabIndex = 0;
            this.btnUploadFile.Text = "Upload File";
            this.btnUploadFile.UseVisualStyleBackColor = true;
            this.btnUploadFile.Click += new System.EventHandler(this.btnUploadFile_Click);
            // 
            // btnVerifyEmail
            // 
            this.btnVerifyEmail.Location = new System.Drawing.Point(21, 146);
            this.btnVerifyEmail.Name = "btnVerifyEmail";
            this.btnVerifyEmail.Size = new System.Drawing.Size(153, 23);
            this.btnVerifyEmail.TabIndex = 0;
            this.btnVerifyEmail.Text = "Verified Email";
            this.btnVerifyEmail.UseVisualStyleBackColor = true;
            this.btnVerifyEmail.Click += new System.EventHandler(this.btnVerifyEmail_Click);
            // 
            // btnDowloadFile
            // 
            this.btnDowloadFile.Location = new System.Drawing.Point(191, 146);
            this.btnDowloadFile.Name = "btnDowloadFile";
            this.btnDowloadFile.Size = new System.Drawing.Size(153, 23);
            this.btnDowloadFile.TabIndex = 0;
            this.btnDowloadFile.Text = "Dowload File";
            this.btnDowloadFile.UseVisualStyleBackColor = true;
            this.btnDowloadFile.Click += new System.EventHandler(this.btnDowloadFile_Click);
            // 
            // btnFakeIP
            // 
            this.btnFakeIP.Location = new System.Drawing.Point(372, 100);
            this.btnFakeIP.Name = "btnFakeIP";
            this.btnFakeIP.Size = new System.Drawing.Size(153, 23);
            this.btnFakeIP.TabIndex = 0;
            this.btnFakeIP.Text = "Fake IP";
            this.btnFakeIP.UseVisualStyleBackColor = true;
            this.btnFakeIP.Click += new System.EventHandler(this.btnFakeIP_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 275);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnFakeIP);
            this.Controls.Add(this.btnDowloadFile);
            this.Controls.Add(this.btnVerifyEmail);
            this.Controls.Add(this.btnUploadFile);
            this.Controls.Add(this.btnPostDataLogin);
            this.Controls.Add(this.btnGetDataWithCookies);
            this.Controls.Add(this.btnGetData);
            this.Name = "Form1";
            this.Text = "HttpRequest HowKtean";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnGetDataWithCookies;
        private System.Windows.Forms.Button btnPostDataLogin;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.Button btnVerifyEmail;
        private System.Windows.Forms.Button btnDowloadFile;
        private System.Windows.Forms.Button btnFakeIP;
    }
}

