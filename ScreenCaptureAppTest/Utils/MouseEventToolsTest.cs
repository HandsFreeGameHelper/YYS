using NUnit.Framework;
using ScreenCaptureApp.Utils;
using System.Drawing;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureAppTest.Utils;

public class MouseEventToolsTest
{
  [Test]
  public void MoveAndClickTest()
  {
    var random = new Random();
    var windowRect = new RECT() 
    {
      Right = 2000,
      Left = 460,
      Top = 1000,
      Bottom = 1520
    };
    var eventPoint = new Point(1864,1084);
    var randomPointCount = random.Next(5,10);

    for (int i = 0; i < 20; i++) 
    {
      random.MoveAndClick(eventPoint,windowRect,randomPointCount);
    }
  }
}
