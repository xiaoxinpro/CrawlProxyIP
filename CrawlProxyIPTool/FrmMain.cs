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
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnGetIP_Click(object sender, EventArgs e)
        {
            txtTest.Clear();
            ProxyIP proxyIP = new ProxyIP();
            proxyIP.EventGetIPDone += new ProxyIP.DelegateGetIPDone(GetIPDone);
            proxyIP.EventGetIPing += new ProxyIP.DelegateGetIPing(GetIPing);
            proxyIP.GetIP_xicidaili();
        }

        private void btnGetIP_zdaye_Click(object sender, EventArgs e)
        {
            txtTest.Clear();
            ProxyIP proxyIP = new ProxyIP();
            proxyIP.EventGetIPDone += new ProxyIP.DelegateGetIPDone(GetIPDone);
            proxyIP.EventGetIPing += new ProxyIP.DelegateGetIPing(GetIPing);
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

        private void btnTest_Click(object sender, EventArgs e)
        {
            ProxyIP proxyIP = new ProxyIP();
            txtTest.Text = proxyIP.Test();
        }

    }
}
