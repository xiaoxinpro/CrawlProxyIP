using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CrawlProxyIP
{
    public class ProxyIP
    {
        private ConcurrentQueue<string> QueueGetIP = new ConcurrentQueue<string>();
        private ConcurrentQueue<string> QueueCheckIP = new ConcurrentQueue<string>();
        private Stopwatch Watch = new Stopwatch();
        #region 全局变量
        public string strTest;
        #endregion

        #region 属性
        /// <summary>
        /// 获取到IP是否校验后输出。
        /// </summary>
        public bool IsCheck { get; set; }

        /// <summary>
        /// 获取到的IP是否检测HTTPS，需要开启IsCheck才有效。
        /// </summary>
        public bool IsHTTPS { get; set; }

        /// <summary>
        /// 单个IP校验超时时间（毫秒），建议不要小于2000。
        /// </summary>
        public int CheckTimeout { get; set; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public ProxyIP()
        {
            IsCheck = true;
            IsHTTPS = true;
            CheckTimeout = 5000;
        }
        #endregion

        #region 获取结果委托事件
        /// <summary>
        /// 获取IP过程中返回结果
        /// </summary>
        /// <param name="DataIP"></param>
        public delegate void DelegateGetIPing(string DataIP);
        public event DelegateGetIPing EventGetIPing;

        /// <summary>
        /// 获取IP完成返回全部结果
        /// </summary>
        /// <param name="arrDataIP"></param>
        public delegate void DelegateGetIPDone(string[] arrDataIP);
        public event DelegateGetIPDone EventGetIPDone;
        #endregion

        #region 代理获取函数
        /// <summary>
        /// 获取xicidaili代理IP
        /// </summary>
        public void GetIP_xicidaili()
        {
            Task taskMain = new Task(()=> {
                Watch = new Stopwatch();
                Watch.Start();
                HttpHelper Http = new HttpHelper();
                HttpItem Item = new HttpItem()
                {
                    URL = "https://www.xicidaili.com/wn/",
                    Method = "get",
                };
                HttpResult result = Http.GetHtml(Item);
                strTest = result.Html;
                MatchCollection matches = Regex.Matches(result.Html, @"(\d{1,3}\.){3}\d{1,3}</td>\s*<td>\d{1,5}");
                foreach (Match match in matches)
                {
                    QueueGetIP.Enqueue(Regex.Replace(match.Value, @"</td>\s*<td>", ":"));
                }
                Console.WriteLine("xicidaili获取到" + QueueGetIP.Count + "个IP地址，开始校验...");
                TaskRunCheckIP();
            
                Watch.Stop();
                Console.WriteLine("耗时：" + Watch.Elapsed.TotalSeconds);

                EventGetIPDone?.Invoke(QueueCheckIP.ToArray());
            });
            taskMain.Start();
        }

        /// <summary>
        /// 获取zdaye代理IP
        /// </summary>
        public void GetIP_zdaye()
        {
            Watch = new Stopwatch();
            Watch.Start();
            Task.Factory.StartNew(() =>
            {
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = "http://ip.zdaye.com/dayProxy.html",
                    Method = "get",
                    Timeout = 5000,
                };
                HttpResult result = http.GetHtml(item);
                Match matchURL = Regex.Match(result.Html, @"/dayProxy/ip/\d+\.html");
                Console.WriteLine(@"http://ip.zdaye.com" + matchURL.Value);
                item.URL = @"http://ip.zdaye.com" + matchURL.Value;
                item.Host = @"ip.zdaye.com";
                item.Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                item.Referer = @"http://ip.zdaye.com/dayProxy.html";
                item.CookieCollection = result.CookieCollection;
                item.Cookie = result.Cookie;
                item.Encoding = Encoding.UTF8;
                result = http.GetHtml(item);
                MatchCollection matches = Regex.Matches(result.Html, @"(\d{1,3}\.){3}\d{1,3}\:\d{1,5}");
                foreach (Match match in matches)
                {
                    QueueGetIP.Enqueue(match.Value);
                }
                Console.WriteLine("zdaye获取到" + QueueGetIP.Count + "个IP地址，开始校验...");
                TaskRunCheckIP();
                Watch.Stop();
                Console.WriteLine("耗时：" + Watch.Elapsed.TotalSeconds);
                EventGetIPDone?.Invoke(QueueCheckIP.ToArray());
            });
        }

        #endregion

        #region 校验IP地址(任务内函数)
        /// <summary>
        /// 启动检验IP任务群
        /// </summary>
        private void TaskRunCheckIP()
        {
            if (IsCheck)
            {
                /*方案一、创建大量任务(速度更快)*/
                var tasks = new Task[QueueGetIP.Count];
                for (int i = 0; i < tasks.Length; i++)
                {
                    tasks[i] = Task.Factory.StartNew(() => CheckIP());
                }
                Task.WaitAll(tasks);

                /*方案二、创建线程池Parallel*/
                //Parallel.ForEach<string>(QueueGetIP.ToArray(), (dataIP) => CheckIP(dataIP));
            }
            else
            {
                while (QueueGetIP.IsEmpty == false)
                {
                    if(QueueGetIP.TryDequeue(out string result))
                    {
                        EventGetIPing?.Invoke(result);
                    }
                }
            }
        }

        /// <summary>
        /// 从QueueGetIP中获取IP检验
        /// </summary>
        public void CheckIP()
        {
            while (QueueGetIP.IsEmpty == false)
            {
                if (QueueGetIP.TryDequeue(out string dataIP))
                {
                    CheckIP(dataIP);
                }
            }
        }

        /// <summary>
        /// 检验指定IP地址
        /// </summary>
        /// <param name="dataIP">IP地址:端口</param>
        public void CheckIP(string dataIP)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://pv.sohu.com/cityjson?ie=utf-8", //HTTP网站 http://ip-api.com/json/?lang=zh-CN
                Method = "get",
                ProxyIp = dataIP,   //IP地址:端口
                Timeout = CheckTimeout,     //超时毫秒数
            };
            if (IsHTTPS)
            {
                item.URL = "https://pv.sohu.com/cityjson?ie=utf-8"; //HTTPS网站
            }
            HttpResult checkResult = http.GetHtml(item);
            if (checkResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MatchCollection matchs = Regex.Matches(checkResult.Html, @"(\d{1,3}\.){3}\d{1,3}");
                if (matchs.Count > 0)
                {
                    if (dataIP.IndexOf(matchs[0].Value) == 0) //matchs[0].Value不包含端口号
                    {
                        QueueCheckIP.Enqueue(dataIP);
                        EventGetIPing?.Invoke(dataIP);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 测试函数
        /// </summary>
        public string Test()
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://ip.zdaye.com/dayProxy.html",
                Method = "get",
                Timeout = 5000,
            };
            HttpResult checkResult = http.GetHtml(item);
            Match match = Regex.Match(checkResult.Html, @"/dayProxy/ip/\d+\.html");
            Console.WriteLine(@"http://ip.zdaye.com" + match.Value);
            item.URL = @"http://ip.zdaye.com" + match.Value;
            item.Host = @"ip.zdaye.com";
            item.Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            item.Referer = @"http://ip.zdaye.com/dayProxy.html";
            item.CookieCollection = checkResult.CookieCollection;
            item.Cookie = checkResult.Cookie;
            item.Encoding = Encoding.UTF8;
            checkResult = http.GetHtml(item);

            //MatchCollection matchs = Regex.Matches(strTest, @"(\d{1,3}\.){3}\d{1,3}");
            //if (matchs.Count > 0)
            //{
            //    return matchs[0].Value;
            //}
            strTest = checkResult.Html;
            return strTest;
        }
    }

}
