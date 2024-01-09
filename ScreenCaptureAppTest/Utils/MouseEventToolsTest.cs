using NUnit.Framework;
using ScreenCaptureApp.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;
using static ScreenCaptureApp.Utils.Contains;
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
  [Test]
  public void ScrollWheelDown() 
  {
    var random = new Random();
    WindowsFilter.GetWindows();
    var targetHWnds = WindowsFilter.WindowHandles;
    SystemRuntimes.RECT windowRect;
    SystemRuntimes.GetWindowRect(targetHWnds.First(), out windowRect);
    //random.MoveAndClick(new Point(windowRect.Left + TuPo.ResetMarginLeft, windowRect.Top + TuPo.ResetMarginTop), windowRect, 2);
    Point mousePosition = Cursor.Position;
    MouseEventTools.MoveTo(mousePosition, new Point(windowRect.Left + TuPo.ResetMarginLeft, windowRect.Top + TuPo.ResetMarginTop), 2);
    Thread.Sleep(1000);
    MouseEventTools.ScrollWheelDown();
  }
}
