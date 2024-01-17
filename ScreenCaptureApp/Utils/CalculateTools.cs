using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Utils;

public static class CalculateTools
{
  public static int Add(this int x, int y, bool add)
  {
    return add ? x + y : x - y;
  }

  public static int GetInRangeNum(this int currentNum, bool dir, int borderNum)
  {
    return currentNum.IsInRange(dir, borderNum) ? currentNum : borderNum;
  }

  public static bool IsInRange(this int currentNum, bool dir, int borderNum)
  {
    return dir ? currentNum < borderNum : currentNum > borderNum;
  }
  public static bool IsInRange(this Point currentPoint, RECT windowRect, Point eventPoint, out (bool, bool) xOrY)
  {
    xOrY.Item1 = Math.Abs(currentPoint.X - eventPoint.X) >= 10;
    xOrY.Item2 = Math.Abs(currentPoint.Y - eventPoint.Y) >= 10;

    return currentPoint.X >= windowRect.Left &&
           currentPoint.X <= windowRect.Right &&
           currentPoint.Y >= windowRect.Top &&
           currentPoint.Y <= windowRect.Bottom &&
           Math.Abs(currentPoint.X - eventPoint.X) < 10 &&
           Math.Abs(currentPoint.Y - eventPoint.Y) < 10;
  }

  public static Point GetRandomPoint(this Random random, int start_x = -1, int end_x = -1, int start_y = -1, int end_y = -1)
  {
    return new Point(start_x == -1 || end_x == -1 ?
                      random.Next(0, 2560) :
                     start_x > end_x ?
                      random.Next(end_x, start_x) :
                      random.Next(start_x, end_x),
                     start_y == -1 || end_y == -1 ?
                      random.Next(0, 1440) :
                     start_y > end_y ?
                      random.Next(end_y, start_y) :
                      random.Next(start_y, end_y)); ;
  }

  public static Point GetRandomPoint(this Random random, Point point, RECT windowRect, int width, int height)
  {
    var temp = windowRect.GetWidthAndHeight();
    return random.GetRandomPoint(
          windowRect.Left + point.X + (int)(temp.Item1 * 15 * 1.0 / RegionWidth),
          windowRect.Left + point.X + width,
          windowRect.Top + point.Y + (int)(temp.Item2 * 60 * 1.0 / RegionHeight),
          windowRect.Top + point.Y + height + (int)(temp.Item2 * 20 * 1.0 / RegionHeight));
  }

  public static (int, int) GetWidthAndHeight(this RECT windowRect)
  {
    (int, int) res = new();
    res.Item1 = windowRect.Right - windowRect.Left;
    res.Item2 = windowRect.Bottom - windowRect.Top;
    return res;
  }

  public static int Multiply(this Bitmap scaledBmp, double rate ,bool isXOrWidth)
  {
    return isXOrWidth ? (int)(scaledBmp.Width * rate) : (int)(scaledBmp.Height * rate);
  }

  public static Point GetElementPoint(this Bitmap scaledBmp, double ratex, double ratey) 
  {
    return new Point(scaledBmp.Multiply(ratex, true), scaledBmp.Multiply(ratey, false));
  }
}
