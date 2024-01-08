using System;
using NUnit.Framework;
using ScreenCaptureApp.Utils;

namespace ScreenCaptureAppTest.Utils;

internal class NetToolsTest
{
  [Test]
  public void Test1() 
  {
    var ip = NetTools.GetLocalIPv6Address();
  }
}
