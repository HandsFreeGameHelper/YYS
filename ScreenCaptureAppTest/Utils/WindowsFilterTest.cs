using NUnit.Framework;
using ScreenCaptureApp.Utils;

namespace ScreenCaptureAppTest.Utils;

internal class WindowsFilterTest
{
  [Test]
  public void GetWindowsTest()
  {
    WindowsFilter.GetWindows();
    var res = WindowsFilter.WindowHandles;
  }
}
