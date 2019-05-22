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
            this.components = new System.ComponentModel.Container();
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
            this.dataInfo = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGetIP_xxgzs = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.chkTimer = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numTimer = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.timRun = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numCheckTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTest
            // 
            this.txtTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTest.Location = new System.Drawing.Point(171, 12);
            this.txtTest.Multiline = true;
            this.txtTest.Name = "txtTest";
            this.txtTest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTest.Size = new System.Drawing.Size(381, 271);
            this.txtTest.TabIndex = 0;
            // 
            // btnGetIP_xicidaili
            // 
            this.btnGetIP_xicidaili.Location = new System.Drawing.Point(12, 166);
            this.btnGetIP_xicidaili.Name = "btnGetIP_xicidaili";
            this.btnGetIP_xicidaili.Size = new System.Drawing.Size(144, 23);
            this.btnGetIP_xicidaili.TabIndex = 1;
            this.btnGetIP_xicidaili.Text = "Get IP xicidaili";
            this.btnGetIP_xicidaili.UseVisualStyleBackColor = true;
            this.btnGetIP_xicidaili.Click += new System.EventHandler(this.btnGetIP_xicidaili_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(558, 231);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(109, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnGetIP_zdaye
            // 
            this.btnGetIP_zdaye.Location = new System.Drawing.Point(12, 195);
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
            this.chkCheck.Checked = true;
            this.chkCheck.CheckState = System.Windows.Forms.CheckState.Checked;
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
            // dataInfo
            // 
            this.dataInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataInfo.Location = new System.Drawing.Point(12, 289);
            this.dataInfo.Name = "dataInfo";
            this.dataInfo.RowTemplate.Height = 23;
            this.dataInfo.Size = new System.Drawing.Size(655, 150);
            this.dataInfo.TabIndex = 9;
            this.dataInfo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataInfo_CellMouseDoubleClick);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 260);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(144, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGetIP_xxgzs
            // 
            this.btnGetIP_xxgzs.Location = new System.Drawing.Point(12, 137);
            this.btnGetIP_xxgzs.Name = "btnGetIP_xxgzs";
            this.btnGetIP_xxgzs.Size = new System.Drawing.Size(144, 23);
            this.btnGetIP_xxgzs.TabIndex = 1;
            this.btnGetIP_xxgzs.Text = "Get IP xxgzs";
            this.btnGetIP_xxgzs.UseVisualStyleBackColor = true;
            this.btnGetIP_xxgzs.Click += new System.EventHandler(this.btnGetIP_xxgzs_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.Location = new System.Drawing.Point(558, 260);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(109, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // chkTimer
            // 
            this.chkTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTimer.AutoSize = true;
            this.chkTimer.Location = new System.Drawing.Point(558, 14);
            this.chkTimer.Name = "chkTimer";
            this.chkTimer.Size = new System.Drawing.Size(96, 16);
            this.chkTimer.TabIndex = 10;
            this.chkTimer.Text = "定时启动流程";
            this.chkTimer.UseVisualStyleBackColor = true;
            this.chkTimer.CheckedChanged += new System.EventHandler(this.chkTimer_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(556, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "定时";
            // 
            // numTimer
            // 
            this.numTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numTimer.Location = new System.Drawing.Point(588, 38);
            this.numTimer.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.numTimer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTimer.Name = "numTimer";
            this.numTimer.Size = new System.Drawing.Size(45, 21);
            this.numTimer.TabIndex = 12;
            this.numTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTimer.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(638, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "分钟";
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(558, 65);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(109, 23);
            this.btnRun.TabIndex = 13;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // timRun
            // 
            this.timRun.Interval = 60000;
            this.timRun.Tick += new System.EventHandler(this.timRun_Tick);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(558, 94);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(109, 23);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 450);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.numTimer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkTimer);
            this.Controls.Add(this.dataInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numCheckTimeout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkHTTPS);
            this.Controls.Add(this.chkCheck);
            this.Controls.Add(this.btnGetIP);
            this.Controls.Add(this.btnGetIP_zdaye);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnGetIP_xxgzs);
            this.Controls.Add(this.btnGetIP_xicidaili);
            this.Controls.Add(this.txtTest);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "抓取代理IP工具";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCheckTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimer)).EndInit();
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
        private System.Windows.Forms.DataGridView dataInfo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGetIP_xxgzs;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.CheckBox chkTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numTimer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Timer timRun;
        private System.Windows.Forms.Button btnStop;
    }
}

