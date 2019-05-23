using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private List<string> ListProxyIP = new List<string>();
        private ConcurrentQueue<string> QueueGetIP = new ConcurrentQueue<string>();
        private ConcurrentQueue<string> QueueCheckIP = new ConcurrentQueue<string>();
        private Stopwatch Watch = new Stopwatch();
        private static bool IsRun = false;
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
            IsHTTPS = false;
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

        /// <summary>
        /// 获取IP过程产生的日志消息
        /// </summary>
        /// <param name="msg"></param>
        public delegate void DelegateGetIPInfo(string msg, string status, DateTime startTime, DateTime endTime, double lenTime, string error);
        public event DelegateGetIPInfo EventGetIPInfo;

        #endregion

        #region 代理获取函数
        /// <summary>
        /// 获取xxgzs代理IP
        /// </summary>
        public void GetIP_xxgzs()
        {
            IsRun = true;
            Task taskMain = new Task(() => {
                Watch = new Stopwatch();
                Watch.Start();
                HttpHelper Http = new HttpHelper();
                HttpItem Item = new HttpItem()
                {
                    URL = "http://nas.xxvpn.top:8899/api/v1/proxies?limit=100&https=true",
                    Method = "get",
                };
                HttpResult result = Http.GetHtml(Item);
                MatchCollection matches = Regex.Matches(result.Html, @"(\d{1,3}\.){3}\d{1,3}\D+\d{1,5}");
                foreach (Match match in matches)
                {
                    QueueGetIP.Enqueue(Regex.Replace(match.Value, @"\""\D+", ":"));
                }
                Console.WriteLine("xxgzs获取到" + matches.Count + "个IP地址，开始校验...");
                TaskRunCheckIP();
                if (!IsRun) return;
                Watch.Stop();
                Console.WriteLine("耗时：" + Watch.Elapsed.TotalSeconds);

                EventGetIPDone?.Invoke(ListProxyIP.ToArray());
            });
            taskMain.Start();
        }

        /// <summary>
        /// 获取xicidaili代理IP
        /// </summary>
        public void GetIP_xicidaili()
        {
            IsRun = true;
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
                MatchCollection matches = Regex.Matches(result.Html, @"(\d{1,3}\.){3}\d{1,3}\D+\d{1,5}");
                foreach (Match match in matches)
                {
                    QueueGetIP.Enqueue(Regex.Replace(match.Value, @"</td>\s*<td>", ":"));
                }
                Console.WriteLine("xicidaili获取到" + matches.Count + "个IP地址，开始校验...");
                TaskRunCheckIP();
                if (!IsRun) return;
                Watch.Stop();
                Console.WriteLine("耗时：" + Watch.Elapsed.TotalSeconds);

                EventGetIPDone?.Invoke(ListProxyIP.ToArray());
            });
            taskMain.Start();
        }

        /// <summary>
        /// 获取zdaye代理IP
        /// </summary>
        public void GetIP_zdaye()
        {
            IsRun = true;
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
                MatchCollection matchesURL = Regex.Matches(result.Html, @"/dayProxy/ip/\d+\.html");
                List<string> ListUrl = new List<string>();
                foreach (Match match in matchesURL)
                {
                    ListUrl.Add(@"http://ip.zdaye.com" + match.Value);
                }
                ListUrl = ListUrl.Distinct().ToList(); //URL去重
                List<string> ListIP = new List<string>(); //记录获取的全部IP用于去重
                foreach (string itemUrl in ListUrl)
                {
                    Console.WriteLine("开始爬取" + itemUrl);
                    item.URL = itemUrl;
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
                        if (!ListIP.Contains(match.Value))
                        {
                            QueueGetIP.Enqueue(match.Value);
                            ListIP.Add(match.Value);
                        }
                    }
                    Console.WriteLine("zdaye获取到" + QueueGetIP.Count + "个IP地址，开始校验...");
                    TaskRunCheckIP();
                    if (!IsRun) return;
                }
                Watch.Stop();
                Console.WriteLine("耗时：" + Watch.Elapsed.TotalSeconds);
                EventGetIPDone?.Invoke(ListProxyIP.ToArray());
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
                    if (!IsRun) return;
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
                        ListProxyIP.Add(result);
                        EventGetIPing?.Invoke(result);
                    }
                }
            }

            //List去重
            ListProxyIP = ListProxyIP.Distinct().ToList();
        }

        /// <summary>
        /// 从QueueGetIP中获取IP检验
        /// </summary>
        public void CheckIP()
        {
            while (QueueGetIP.IsEmpty == false)
            {
                if (!IsRun) return;
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
        public void CheckIP(string dataIP, bool isHttps = false)
        {
            DateTime startTime = DateTime.Now;
            Stopwatch watchCheckIP = new Stopwatch();
            watchCheckIP.Start();
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://pv.sohu.com/cityjson?ie=utf-8", //HTTP网站 http://ip-api.com/json/?lang=zh-CN
                Method = "get",
                ProxyIp = dataIP,                   //IP地址:端口
                Timeout = CheckTimeout,             //超时毫秒数
                ReadWriteTimeout = CheckTimeout,    //超时毫秒数
            };
            if (isHttps)
            {
                item.URL = "https://pv.sohu.com/cityjson?ie=utf-8"; //HTTPS网站
            }
            HttpResult checkResult = http.GetHtml(item);
            watchCheckIP.Stop();
            if (!IsRun) return;
            if (checkResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MatchCollection matchs = Regex.Matches(checkResult.Html, @"(\d{1,3}\.){3}\d{1,3}");
                if (matchs.Count > 0)
                {
                    if (dataIP.IndexOf(matchs[0].Value) == 0) //matchs[0].Value不包含端口号
                    {
                        if (IsHTTPS && isHttps == false)
                        {
                            CheckIP(dataIP, true);
                        }
                        else
                        {
                            ListProxyIP.Add(dataIP);
                            QueueCheckIP.Enqueue(dataIP);
                            EventGetIPing?.Invoke(dataIP);
                            EventGetIPInfo?.Invoke(dataIP, "OK", startTime, DateTime.Now, watchCheckIP.Elapsed.TotalSeconds,"");
                        }
                        return;
                    }
                }
            }
            EventGetIPInfo?.Invoke(dataIP, "NG", startTime, DateTime.Now, watchCheckIP.Elapsed.TotalSeconds, checkResult.StatusDescription);
        }

        //private void CallWithTimeout(Action action, int timeoutMilliseconds)
        //{
        //    Thread threadToKill = null;
        //    Action wrappedAction = () =>
        //    {
        //        threadToKill = Thread.CurrentThread;
        //        action();
        //    };
        //    IAsyncResult result = wrappedAction.BeginInvoke(null, null);
        //    if (result.AsyncWaitHandle.WaitOne(timeoutMilliseconds))
        //    {
        //        wrappedAction.EndInvoke(result);
        //    }
        //    else
        //    {
        //        threadToKill.Abort();
        //        //throw new TimeoutException();
        //    }
        //}
        #endregion

        #region 校验IP地址（公共函数）
        public void xxIP()
        {
            IsRun = true;
            Task.Factory.StartNew(() =>
            {
                try
                {
                    get_xxIP_list();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            });
        }

        private void get_xxIP_list(int page = 0, int num = 100)
        {
            int page_all = 0;
            int ip_count = 0;
            do
            {
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = @"https://ide.xiaoxin.pro/xxIP/index.php/Index/Api/check?type=get&page=" + page.ToString() + @"&num=" + num.ToString(),
                    Method = "get",
                };
                HttpResult checkResult = http.GetHtml(item);
                if (!IsRun) return;
                EventGetIPing?.Invoke(checkResult.Html);
                JObject json = JObject.Parse(checkResult.Html);
                //Console.WriteLine(json);
                page = Convert.ToInt32(json["page"]);
                page_all = Convert.ToInt32(json["page_all"]);
                ip_count = Convert.ToInt32(json["count"]);
                //Console.WriteLine("Json: page=" + ip_page + ",page_all=" + ip_page_all + ",count=" + ip_count);
                foreach (JProperty ip_data in json["data"])
                {
                    string ip_data_id = ip_data.Name.ToString();
                    string ip_data_name = (new JObject(ip_data))[ip_data_id].ToString();
                    string[] arrIP = ip_data_name.Split(':');
                    if (arrIP.Length == 2)
                    {
                        if (!IsRun) return;
                        xxIP(arrIP[0], arrIP[1], false);
                        xxIP(arrIP[0], arrIP[1], true);
                    }
                }
            } while (++page <= page_all);
        }

        public void xxIP(string ip, string port, bool isHttps = false)
        {
            IsRun = true;
            Task.Factory.StartNew(() =>
            {
                string now_ip = GetNowIP();
                string url = @"ide.xiaoxin.pro/xxIP/index.php/Index/Api/ip?";
                url += @"proxy_ip=" + ip + @"&proxy_port=" + port + @"&real_ip=" + now_ip;
                if (isHttps)
                {
                    url = @"https://" + url;
                }
                else
                {
                    url = @"http://" + url;
                }
                DateTime startTime = DateTime.Now;
                Stopwatch watchCheckIP = new Stopwatch();
                watchCheckIP.Start();
                HttpHelper http = new HttpHelper();
                HttpItem item = new HttpItem()
                {
                    URL = url,                          //HTTP网站 http://ip-api.com/json/?lang=zh-CN
                    Method = "get",
                    ProxyIp = ip + ":" + port,          //IP地址:端口
                    Timeout = CheckTimeout,             //超时毫秒数
                    ReadWriteTimeout = CheckTimeout,    //超时毫秒数
                };
                HttpResult checkResult = http.GetHtml(item);
                watchCheckIP.Stop();
                if (!IsRun) return;
                if (checkResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    EventGetIPing?.Invoke(checkResult.Html);
                }
                else
                {
                    EventGetIPing?.Invoke("Error " + checkResult.StatusCode + ":" + checkResult.StatusDescription);
                    item.ProxyIp = null;
                    checkResult = http.GetHtml(item);
                    //EventGetIPing?.Invoke(item.URL + "\r\n" + checkResult.Html);
                    return;
                }
            });
        }

        public string GetNowIP()
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "https://ide.xiaoxin.pro/xxIP/index.php/Index/Api/ip",//HTTP网站 http://ip-api.com/json/?lang=zh-CN
                Method = "get",
                Timeout = CheckTimeout,             //超时毫秒数
                ReadWriteTimeout = CheckTimeout,    //超时毫秒数
            };
            HttpResult checkResult = http.GetHtml(item);
            if (!IsRun) return"";
            if (checkResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Match match = Regex.Match(checkResult.Html, @"(\d{1,3}\.){3}\d{1,3}");
                return match.Value;
            }
            else
            {
                return "";
            }
        }
        #endregion

        /// <summary>
        /// 停止运行
        /// </summary>
        public static void Stop()
        {
            IsRun = false;
        }

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
