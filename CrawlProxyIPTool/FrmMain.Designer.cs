namespace CrawlProxyIPTool
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTest = new System.Windows.Forms.TextBox();
            this.btnGetIP_xicidaili = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnGetIP_zdaye = new System.Windows.Forms.Button();
            this.btnGetIP = new System.Windows.Forms.Button();
            this.chkCheck = new System.Windows.Forms.CheckBox();
            this.chkHTTPS = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numCheckTimeout = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCheckTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTest
            // 
            this.txtTest.Location = new System.Drawing.Point(171, 12);
            this.txtTest.Multiline = true;
            this.txtTest.Name = "txtTest";
            this.txtTest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTest.Size = new System.Drawing.Size(337, 426);
            this.txtTest.TabIndex = 0;
            // 
            // btnGetIP_xicidaili
            // 
            this.btnGetIP_xicidaili.Location = new System.Drawing.Point(12, 137);
            this.btnGetIP_xicidaili.Name = "btnGetIP_xicidaili";
            this.btnGetIP_xicidaili.Size = new System.Drawing.Size(144, 23);
            this.btnGetIP_xicidaili.TabIndex = 1;
            this.btnGetIP_xicidaili.Text = "Get IP xicidaili";
            this.btnGetIP_xicidaili.UseVisualStyleBackColor = true;
            this.btnGetIP_xicidaili.Click += new System.EventHandler(this.btnGetIP_xicidaili_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(12, 415);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(144, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnGetIP_zdaye
            // 
            this.btnGetIP_zdaye.Location = new System.Drawing.Point(12, 166);
            this.btnGetIP_zdaye.Name = "btnGetIP_zdaye";
            this.btnGetIP_zdaye.Size = new System.Drawing.Size(144, 23);
            this.btnGetIP_zdaye.TabIndex = 3;
            this.btnGetIP_zdaye.Text = "Get IP zdaye";
            this.btnGetIP_zdaye.UseVisualStyleBackColor = true;
            this.btnGetIP_zdaye.Click += new System.EventHandler(this.btnGetIP_zdaye_Click);
            // 
            // btnGetIP
            // 
            this.btnGetIP.Location = new System.Drawing.Point(12, 85);
            this.btnGetIP.Name = "btnGetIP";
            this.btnGetIP.Size = new System.Drawing.Size(144, 46);
            this.btnGetIP.TabIndex = 3;
            this.btnGetIP.Text = "Get IP All";
            this.btnGetIP.UseVisualStyleBackColor = true;
            this.btnGetIP.Click += new System.EventHandler(this.btnGetIP_Click);
            // 
            // chkCheck
            // 
            this.chkCheck.AutoSize = true;
            this.chkCheck.Location = new System.Drawing.Point(12, 14);
            this.chkCheck.Name = "chkCheck";
            this.chkCheck.Size = new System.Drawing.Size(84, 16);
            this.chkCheck.TabIndex = 4;
            this.chkCheck.Text = "校验IP地址";
            this.chkCheck.UseVisualStyleBackColor = true;
            // 
            // chkHTTPS
            // 
            this.chkHTTPS.AutoSize = true;
            this.chkHTTPS.Location = new System.Drawing.Point(12, 36);
            this.chkHTTPS.Name = "chkHTTPS";
            this.chkHTTPS.Size = new System.Drawing.Size(102, 16);
            this.chkHTTPS.TabIndex = 4;
            this.chkHTTPS.Text = "检验有效HTTPS";
            this.chkHTTPS.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "校验超时：";
            // 
            // numCheckTimeout
            // 
            this.numCheckTimeout.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCheckTimeout.Location = new System.Drawing.Point(72, 58);
            this.numCheckTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCheckTimeout.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCheckTimeout.Name = "numCheckTimeout";
            this.numCheckTimeout.Size = new System.Drawing.Size(55, 21);
            this.numCheckTimeout.TabIndex = 6;
            this.numCheckTimeout.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "毫秒";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numCheckTimeout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkHTTPS);
            this.Controls.Add(this.chkCheck);
            this.Controls.Add(this.btnGetIP);
            this.Controls.Add(this.btnGetIP_zdaye);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnGetIP_xicidaili);
            this.Controls.Add(this.txtTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "抓取代理IP工具";
            ((System.ComponentModel.ISupportInitialize)(this.numCheckTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.Button btnGetIP_xicidaili;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnGetIP_zdaye;
        private System.Windows.Forms.Button btnGetIP;
        private System.Windows.Forms.CheckBox chkCheck;
        private System.Windows.Forms.CheckBox chkHTTPS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numCheckTimeout;
        private System.Windows.Forms.Label label2;
    }
}

