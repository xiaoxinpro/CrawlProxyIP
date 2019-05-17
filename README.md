# CrawlProxyIP

## 概述

基于C#抓取代理IP地址的类库，目前集成了`xicidaili`与`zdaye`中的免费代理，支持多线程代理IP验证功能，支持单条验证成功回调，支持全部验证完一次性回调。

## 下载

库文件：[CrawlProxyIP.dll](https://github.com/xiaoxinpro/CrawlProxyIP/raw/master/CrawlProxyIP/bin/Debug/CrawlProxyIP.dll)

测试工具：[CrawlProxyIPTool.exe](https://github.com/xiaoxinpro/CrawlProxyIP/raw/master/CrawlProxyIPTool/bin/Debug/CrawlProxyIPTool.exe)

## 快速上手

### 1、引用DLL文件

将“CrawlProxyIP.dll”文件引入到项目中，添加命名空间`using CrawlProxyIP;`。

### 2、初始代理IP类

首先New一个ProxyIP，然后根据项目需要使用`EventGetIPDone`全部验证完一次性回调，或者 `EventGetIPing`单条验证成功回调，两事件可同时使用也可以单独使用。

```
ProxyIP proxyIP = new ProxyIP();
proxyIP.EventGetIPDone += new ProxyIP.DelegateGetIPDone(GetIPDone);
proxyIP.EventGetIPing += new ProxyIP.DelegateGetIPing(GetIPing);
```

### 3、添加事件回调函数

根据“初始代理IP类”中添加的回调选择添加回调函数。

```
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
```

### 4、启动获取代理IP

目前CrawlProxyIP支持`xicidaili`与`zdaye`代理源，分别使用

```
proxyIP.GetIP_xicidaili();
```
或

```
proxyIP.GetIP_xicidaili();
```
启动获取代理IP，可同时启动。

