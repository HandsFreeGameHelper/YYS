using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Utils;

public static class MouseEventTools
{
  public static void MoveAndClick(this Random random, Point eventPoint, RECT windowRect, int randomPointCount = 3)
  {
    Point mousePosition = Control.MousePosition;
    for (int i = 0; i < randomPointCount; i++)
    {
      var p = random.GetRandomPoint(windowRect.Left + 200, windowRect.Right - 200, windowRect.Top + 205, windowRect.Bottom - 200);
      mousePosition = mousePosition.MoveTo(p, random.NextDouble());
      Thread.Sleep(10);
    }
    mousePosition.MoveTo(eventPoint, random.NextDouble());
    Thread.Sleep(random.Next(100, 150));
    PressAndHoldMouseLeftButton(random.Next(10, 50));
    Thread.Sleep(50);
    PressAndHoldMouseLeftButton(random.Next(10, 50));
    Thread.Sleep(random.Next(100, 150));
    Console.WriteLine(@"鼠标双击");
  }

  /// <summary>
  /// 鼠标移动到设置的坐标
  /// </summary>
  /// <param name="x">坐标x</param>
  /// <param name="y">坐标y</param>
  /// <param name="duration">移动的速度，默认0为瞬间移动过去</param>
  public static Point MoveTo(this Point point, Point end, double duration = 0.0)
  {
    if (duration >= 0.1)
    {
      int xDis = point.X - end.X;
      int yDis = point.Y - end.Y;

      int absX = Math.Abs(xDis / 50);
      int absY = Math.Abs(yDis / 50);

      int num_steps = absX > absY ? absX : absY;
      if (num_steps == 0) num_steps = 1;
      double sleep_amount = duration / num_steps;


      double stepx = xDis / num_steps;
      double stepy = yDis / num_steps;

      for (int i = 1; i <= num_steps; i++)
      {
        SetCursorPosFun((int)(point.X - stepx * i), (int)(point.Y - stepy * i));
        Thread.Sleep((int)(sleep_amount * 1000));
      }
    }
    else
    {
      SetCursorPosFun(end.X, end.Y, 0);
    }
    return end;
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
      SetCursorPos(start.X, start.Y);
      Thread.Sleep(random.Next(1, 50));
      if (!start.X.IsInRange(isRight, end.X) || !start.Y.IsInRange(isDown, end.Y))
      {
        start.X = end.X;
        start.Y = end.Y;
        break;
      }
    }
    Thread.Sleep(random.Next(1, 25));
    SetCursorPos(start.X, start.Y);
    Thread.Sleep(random.Next(1, 25));
  }

  private static void PressAndHoldMouseLeftButton(int delayMilliseconds)
  {
    // 模拟鼠标按下
    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);

    // 延迟一段时间（按住鼠标左键的时间）
    Thread.Sleep(delayMilliseconds);

    // 模拟鼠标松开
    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
  }

  /// <summary>
  /// 把鼠标移到当前坐标
  /// </summary>
  /// <param name="X">X坐标</param>
  /// <param name="Y">Y坐标</param>
  public static void SetCursorPosFun(int X, int Y)
  {
    SetCursorPos(X, Y);
  }
  /// <summary>
  /// 把鼠标移到当前坐标
  /// </summary>
  /// <param name="X">X坐标</param>
  /// <param name="Y">Y坐标</param>
  public static void SetCursorPosFun(int X, int Y, int flag)
  {
    if (flag == 0)
    {
      SetCursorPos(X, Y);

    }
    else
    {
      MouseMoveFun(X, Y);
    }

  }
  /// <summary>
  /// 把鼠标移到相对坐标
  /// </summary>
  /// <param name="X">X坐标</param>
  /// <param name="Y">Y坐标</param>
  public static void SetCursorFun(int X, int Y)
  {
    mouse_event(MOUSEEVENTF_MOVE, X, Y, 0, 0);
  }

  /// <summary>
  /// 鼠标移动坐标
  /// </summary>
  /// <param name="_x">移动的X</param>
  /// <param name="_y">移动的Y</param>
  public static void MouseMoveFun(int _x, int _y)
  {
    mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, _x * 65535 / Screen.PrimaryScreen.Bounds.Width, _y * 65535 / Screen.PrimaryScreen.Bounds.Height, 0, 0);

  }
}
