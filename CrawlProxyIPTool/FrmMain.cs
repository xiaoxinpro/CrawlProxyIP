using CrawlProxyIP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrawlProxyIPTool
{
    public partial class FrmMain : Form
    {
        DataTable DT_Info = new DataTable();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            DT_Info.Columns.Add("IP");
            DT_Info.Columns.Add("状态");
            DT_Info.Columns.Add("开始时间");
            DT_Info.Columns.Add("结束时间");
            DT_Info.Columns.Add("耗时");
            DT_Info.Columns.Add("错误信息");

            dataInfo.DataSource = DT_Info;
            DT_Info.Rows.Add("0.0.0.0", "Init", DateTime.Now.ToString("HH:mm:ss.fff"), DateTime.Now.ToString("HH:mm:ss.fff"), 0.0, "null");
        }

        private void btnGetIP_Click(object sender, EventArgs e)
        {
            txtTest.Clear();
            ProxyIP proxyIP = new ProxyIP();
            proxyIP.IsCheck = chkCheck.Checked;
            proxyIP.IsHTTPS = chkHTTPS.Checked;
            proxyIP.CheckTimeout = Convert.ToInt32(numCheckTimeout.Value);
            proxyIP.EventGetIPDone += new ProxyIP.DelegateGetIPDone(GetIPDone);
            proxyIP.EventGetIPing += new ProxyIP.DelegateGetIPing(GetIPing);
            proxyIP.EventGetIPInfo += ProxyIP_EventGetIPInfo;
            proxyIP.GetIP_xicidaili();
            proxyIP.GetIP_zdaye();
        }


        private void btnGetIP_xxgzs_Click(object sender, EventArgs e)
        {
            txtTest.Clear();
            ProxyIP proxyIP = new ProxyIP();
            proxyIP.IsCheck = chkCheck.Checked;
            proxyIP.IsHTTPS = chkHTTPS.Checked;
            proxyIP.CheckTimeout = Convert.ToInt32(numCheckTimeout.Value);
            proxyIP.EventGetIPDone += new ProxyIP.DelegateGetIPDone(GetIPDone);
            proxyIP.EventGetIPing += new ProxyIP.DelegateGetIPing(GetIPing);
            proxyIP.EventGetIPInfo += ProxyIP_EventGetIPInfo;
            proxyIP.GetIP_xxgzs();
        }

        private void btnGetIP_xicidaili_Click(object sender, EventArgs e)
        {
            txtTest.Clear();
            ProxyIP proxyIP = new ProxyIP();
            proxyIP.IsCheck = chkCheck.Checked;
            proxyIP.IsHTTPS = chkHTTPS.Checked;
            proxyIP.CheckTimeout = Convert.ToInt32(numCheckTimeout.Value);
            proxyIP.EventGetIPDone += new ProxyIP.DelegateGetIPDone(GetIPDone);
            proxyIP.EventGetIPing += new ProxyIP.DelegateGetIPing(GetIPing);
            proxyIP.EventGetIPInfo += ProxyIP_EventGetIPInfo;
            proxyIP.GetIP_xicidaili();
        }

        private void btnGetIP_zdaye_Click(object sender, EventArgs e)
        {
            txtTest.Clear();
            ProxyIP proxyIP = new ProxyIP();
            proxyIP.IsCheck = chkCheck.Checked;
            proxyIP.IsHTTPS = chkHTTPS.Checked;
            proxyIP.CheckTimeout = Convert.ToInt32(numCheckTimeout.Value);
            proxyIP.EventGetIPDone += new ProxyIP.DelegateGetIPDone(GetIPDone);
            proxyIP.EventGetIPing += new ProxyIP.DelegateGetIPing(GetIPing);
            proxyIP.EventGetIPInfo += ProxyIP_EventGetIPInfo;
            proxyIP.GetIP_zdaye();
        }

        private void GetIPDone(string[] arrData)
        {
            this.Invoke(new Action(() =>
            {
                Console.WriteLine(arrData);
                MessageBox.Show("获取IP完成，共得到" + arrData.Length + "个IP地址。", "成功");
            }));
        }

        private void GetIPing(string data)
        {
            this.Invoke(new Action(() =>
            {
                txtTest.AppendText(data + "\r\n");
            }));
        }

        private void ProxyIP_EventGetIPInfo(string msg, string status, DateTime startTime, DateTime endTime, double lenTime, string error)
        {
            this.Invoke(new Action(() =>
            {
                DT_Info.Rows.Add(msg, status, startTime.ToString("HH:mm:ss.fff"), endTime.ToString("HH:mm:ss.fff"), lenTime, error);
            }));
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //ProxyIP proxyIP = new ProxyIP();
            //txtTest.Text = proxyIP.Test();
            foreach (DataGridViewRow itemRow in dataInfo.Rows)
            {
                if (itemRow.Cells[1].Value != null && itemRow.Cells[1].Value.ToString() == "OK")
                {
                    string dataIP = itemRow.Cells[0].Value.ToString();
                    string[] arrIP = dataIP.Split(':');
                    if (arrIP.Length == 2)
                    {
                        ProxyIP proxyIP = new ProxyIP();
                        proxyIP.IsHTTPS = chkHTTPS.Checked;
                        proxyIP.EventGetIPing += new ProxyIP.DelegateGetIPing(GetIPing);
                        proxyIP.xxIP(arrIP[0], arrIP[1], chkHTTPS.Checked);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DT_Info.Rows.Clear();
        }

        private void dataInfo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dataView = (DataGridView)sender;
            string dataIP = dataView.SelectedCells[0].Value.ToString();
            Console.WriteLine(dataIP);
            string[] arrIP = dataIP.Split(':');
            if (arrIP.Length == 2)
            {
                ProxyIP proxyIP = new ProxyIP();
                proxyIP.IsHTTPS = chkHTTPS.Checked;
                proxyIP.EventGetIPing += new ProxyIP.DelegateGetIPing(GetIPing);
                proxyIP.xxIP(arrIP[0], arrIP[1]);
                MessageBox.Show("验证" + dataIP + "中...");
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            ProxyIP proxyIP = new ProxyIP();
            proxyIP.IsHTTPS = chkHTTPS.Checked;
            proxyIP.EventGetIPing += new ProxyIP.DelegateGetIPing(GetIPing);
            proxyIP.xxIP();
        }

        private void chkTimer_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            numTimer.Enabled = !checkBox.Checked;
            timRun.Enabled = checkBox.Checked;
            cntTimer = 0;
        }

        private int cntTimer = 0;
        private void timRun_Tick(object sender, EventArgs e)
        {
            if (++cntTimer >= numTimer.Value)
            {
                RunProcess();
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            chkTimer.Checked = true;
            RunProcess();
        }

        private void RunProcess()
        {
            cntTimer = 0;
            txtTest.Clear();
            DT_Info.Clear();
            ProxyIP proxyIP = new ProxyIP();
            proxyIP.IsCheck = chkCheck.Checked;
            proxyIP.IsHTTPS = chkHTTPS.Checked;
            proxyIP.CheckTimeout = Convert.ToInt32(numCheckTimeout.Value);
            proxyIP.EventGetIPDone += new ProxyIP.DelegateGetIPDone(RunDone);
            proxyIP.EventGetIPing += new ProxyIP.DelegateGetIPing(GetIPing);
            proxyIP.EventGetIPInfo += ProxyIP_EventGetIPInfo;
            proxyIP.xxIP();
            proxyIP.GetIP_zdaye();
        }

        private void RunDone(string[] arrData)
        {
            if (!chkTimer.Checked) return;
            foreach (string dataIP in arrData)
            {
                string[] arrIP = dataIP.Split(':');
                if (arrIP.Length == 2)
                {
                    ProxyIP proxyIP = new ProxyIP();
                    proxyIP.IsHTTPS = false;
                    proxyIP.EventGetIPing += new ProxyIP.DelegateGetIPing(GetIPing);
                    proxyIP.xxIP(arrIP[0], arrIP[1], false);
                    ProxyIP proxyIPs = new ProxyIP();
                    proxyIPs.IsHTTPS = true;
                    proxyIPs.EventGetIPing += new ProxyIP.DelegateGetIPing(GetIPing);
                    proxyIPs.xxIP(arrIP[0], arrIP[1], true);
                }
            }
        }

    }
}
