using System;
using System.Net;
namespace ScreenCaptureApp.Utils
{
  public static class NetTools
  {
    public static string GetLocalIPv6Address()
    {
      // 获取本机的主机名
      string hostName = Dns.GetHostName();

      // 根据主机名获取IP地址列表
      IPAddress[] addresses = Dns.GetHostAddresses(hostName);

      // 选择IPv6地址（如果有多个IPv6地址，可以根据需求进行选择）
      var ipv6Address = addresses.FirstOrDefault(address => address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6 && !address.ToString().StartsWith("fe80::"));

      // 返回IPv6地址的字符串表示
      return ipv6Address?.ToString() ?? "未找到IPv6地址";
    }
  }
}
