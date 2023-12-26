using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Utils;

public static class MouseEventTools
{
  private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
  private const uint MOUSEEVENTF_LEFTUP = 0x0004;

  public static void MoveAndClick(this Random random, Point eventPoint, RECT windowRect, int randomPointCount = 3)
  {
    Point mousePosition = Cursor.Position;
    for (int i = 0; i < randomPointCount; i++)
    {
      var p = random.GetRandomPoint(windowRect.Left + 200, windowRect.Right - 200, windowRect.Top + 205, windowRect.Bottom - 200);
      random.SmoothlyMove(mousePosition, p);
      Thread.Sleep(10);
    }
    random.SmoothlyMove(mousePosition, eventPoint);
    Thread.Sleep(random.Next(100, 150));
    PressAndHoldMouseLeftButton(random.Next(100, 150));
    Thread.Sleep(50);
    PressAndHoldMouseLeftButton(random.Next(100, 150));
    Thread.Sleep(random.Next(100, 150));
    Console.WriteLine(@"鼠标双击");
  }

  public static void SmoothlyMove(this Random random, Point start, Point end)
  {
    var isRight = end.X - start.X >= 0;
    var isDown = end.Y - start.Y >= 0;
    var lx = Math.Abs(end.X - start.X);
    var ly = Math.Abs(end.Y - start.Y);
    var times = Math.Min(lx, ly);
    for (int i = 0; i < times; i++)
    {
      var tempx = start.X.Add(random.Next(10, 60), isRight);
      var tempy = start.Y.Add(random.Next(10, 40), isDown);
      start.X = tempx.GetInRangeNum(isRight, end.X);
      start.Y = tempy.GetInRangeNum(isDown, end.Y);
      SystemRuntimes.SetCursorPos(start.X, start.Y);
      Thread.Sleep(random.Next(1, 50));
      if (!start.X.IsInRange(isRight, end.X) || !start.Y.IsInRange(isDown, end.Y))
      {
        start.X = end.X;
        start.Y = end.Y;
        break;
      }
    }
    Thread.Sleep(random.Next(1, 25));
    SystemRuntimes.SetCursorPos(start.X, start.Y);
    Thread.Sleep(random.Next(1, 25));
  }

  private static void PressAndHoldMouseLeftButton(int delayMilliseconds)
  {
    // 模拟鼠标按下
    SystemRuntimes.mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);

    // 延迟一段时间（按住鼠标左键的时间）
    Thread.Sleep(delayMilliseconds);

    // 模拟鼠标松开
    SystemRuntimes.mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
  }
}
