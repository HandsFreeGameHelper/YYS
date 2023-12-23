namespace ScreenCaptureApp.Utils;

public static class CalculateTools
{
  public static int Add(this int x, int y, bool add)
  {
    return add ? x + y : x - y;
  }

  public static int GetInRangeNum(this int currentNum, bool dir, int borderNum)
  {
    return dir ? currentNum < borderNum ? borderNum : currentNum : currentNum > borderNum ? borderNum : currentNum;
  }

  public static bool  IsInRange(this int currentNum, bool dir, int borderNum)
  {
    return dir ? currentNum < borderNum : currentNum > borderNum;
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
}
