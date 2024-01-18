using NLog;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Main.Models.StartModel.TuPoModel;

public static class TuPoModel
{
  private static List<IntPtr> needLogs = new List<IntPtr>();

  public static bool TuPoChallenge(this Random random, string type, RECT windowRect, Bitmap scaledBmp, IntPtr intPtr)
  {
    var tuPoPanelSizeWidth = (int)(scaledBmp.Width * TuPo.TuPoPanelSizeWidthRate);
    var tuPoPanelSizeHeight = (int)(scaledBmp.Height * TuPo.TuPoPanelSizeHeightRate);

    var yinYnagLiao1Point = new Point((int)(scaledBmp.Width * TuPo.TuPoPanelMarginLeftYinYangLiao1Rate), 0);
    var attackYinYnagLiao1Point = new Point((int)(scaledBmp.Width * TuPo.AttackMarginLeftYinYangLiaoRate1), 0);
    var yinYnagLiao2Point = new Point((int)(scaledBmp.Width * TuPo.TuPoPanelMarginLeftYinYangLiao2Rate), 0);
    var attackYinYnagLiao2Point = new Point((int)(scaledBmp.Width * TuPo.AttackMarginLeftYinYangLiaoRate2), 0);

    var geRen1Point = new Point((int)(scaledBmp.Width * TuPo.TuPoPanelMarginLeftGeRen1Rate), 0);
    var attackGeRen1Point = new Point((int)(scaledBmp.Width * TuPo.AttackMarginLeftGeRenRate1), 0);
    var geRen2Point = new Point((int)(scaledBmp.Width * TuPo.TuPoPanelMarginLeftGeRen2Rate), 0);
    var attackGeRen2Point = new Point((int)(scaledBmp.Width * TuPo.AttackMarginLeftGeRenRate2), 0);
    var geRen3Point = new Point((int)(scaledBmp.Width * TuPo.TuPoPanelMarginLeftGeRen3Rate), 0);
    var attackGeRen3Point = new Point((int)(scaledBmp.Width * TuPo.AttackMarginLeftGeRenRate3), 0);

    var startScanY =
      TuPo.GEREN.Equals(type) ?
      (int)(scaledBmp.Height * TuPo.TuPoPanelMarginTopGeRenRate) - (int)(scaledBmp.Height * 1.0 * 20 / RegionHeight) : (int)(scaledBmp.Height * TuPo.TuPoPanelMarginTopYinYangLiaoRate) - (int)(scaledBmp.Height * 1.0 * 20 / RegionHeight);
    var endScanY =
      TuPo.GEREN.Equals(type) ?
      scaledBmp.Height : (int)(scaledBmp.Height * TuPo.YinYangLiaoEndYRate);

    var elementAndEventPosition = new List<(Point, KeyValuePair<Point, Point>)>();
    var elements = new List<(Point, Point)>();
    using (Bitmap noChance = new Bitmap(EventImagePath.NoChance))
    {
      var noChancePosition = new Point((int)(scaledBmp.Width * TuPo.NoChanceMarginLeftRate), (int)(scaledBmp.Height * TuPo.NoChanceMarginTopRate));
      var needLogItem = needLogs.Where(x => x == intPtr).FirstOrDefault();
      if (ImageTools.IsElementPresent(scaledBmp, noChance, noChancePosition))
      {
        if (needLogItem == IntPtr.Zero)
        {
          needLogs.Add(intPtr);
          ModelBase.logger.Logs(LogLevel.Info, @"挑战次数为0，等待恢复");
        }
        return false;
      }
      if (needLogItem != IntPtr.Zero)
      {
        needLogs.Remove(intPtr);
      }
    }
    for (int i = startScanY; i < endScanY; i++)
    {
      elements.Clear();
      elementAndEventPosition.Clear();

      if (TuPo.YINYANGLIAO.Equals(type))
      {
        elements.Add(new(attackYinYnagLiao1Point, yinYnagLiao1Point));
        elements.Add(new(attackYinYnagLiao2Point, yinYnagLiao2Point));
      }
      else
      {
        elements.Add(new(attackGeRen1Point, geRen1Point));
        elements.Add(new(attackGeRen2Point, geRen2Point));
        elements.Add(new(attackGeRen3Point, geRen3Point));
      }
      if (random.ExcuteTuPoEnvent(
                 EventImagePath.TuPo_UnTuPo,
                 EventImagePath.TuPo_Attack,
                 elements,
                 elementAndEventPosition,
                 scaledBmp,
                 windowRect,
                 i,
                 startScanY,
                 tuPoPanelSizeWidth,
                 tuPoPanelSizeHeight,
                 intPtr))
      {
        return true;
      }
    }
    using (Bitmap yinyangliaoSelected = new Bitmap(EventImagePath.TuPo_YinYangLiaoSelectedPath))
    {
      using (Bitmap gerenSelected = new Bitmap(EventImagePath.TuPo_GeRenSelectedPath))
      {
        var yinyangliaoSelectedPosition = new Point((int)(scaledBmp.Width * TuPo.TuPoSectionMarginLeftRate), (int)(scaledBmp.Height * TuPo.TuPoYinYangLiaoMarginTopRate));
        var gerenSelectedPosition = new Point((int)(scaledBmp.Width * TuPo.TuPoSectionMarginLeftRate), (int)(scaledBmp.Height * TuPo.TuPoGeRenMarginTopRate));
        if (ImageTools.IsElementPresent(scaledBmp, yinyangliaoSelected, yinyangliaoSelectedPosition)
          || ImageTools.IsElementPresent(scaledBmp, gerenSelected, gerenSelectedPosition))
        {
          Point mousePosition = Cursor.Position;
          mousePosition.MoveTo(
            new Point(windowRect.Left + (int)(scaledBmp.Width * TuPo.ResetMarginLeftRate), windowRect.Top + (int)(scaledBmp.Height * TuPo.ResetMarginTopRate)),
            2);
          Thread.Sleep(1000);
          MouseEventTools.ScrollWheelDown();
        }
      }
    }
    return false;
  }

  private static bool ExcuteTuPoEnvent(
  this Random random,
  string untupoPath,
  string attackPath,
  List<(Point, Point)> elements,
  List<(Point, KeyValuePair<Point, Point>)> elementAndEventPosition,
  Bitmap scaledBmp,
  RECT windowRect,
  int y,
  int startScanY,
  int tuPoPanelSizeWidth,
  int tuPoPanelSizeHeight,
  IntPtr intPtr
  )
  {
    using (Bitmap openTuPoEventBmp = new Bitmap(untupoPath))
    {
      using (Bitmap attackEventBmp = new Bitmap(attackPath))
      {
        elements.ForEach(x =>
        {
          var yinYnagLiaoPoint = x.Item2;
          yinYnagLiaoPoint.Y = y;
          Thread.Sleep(1);
          var yinYnagLiaoEventPoint = random.GetRandomPoint(
              yinYnagLiaoPoint,
              windowRect,
              tuPoPanelSizeWidth,
              tuPoPanelSizeHeight);
          elementAndEventPosition.Add(new(x.Item1, new(yinYnagLiaoPoint, yinYnagLiaoEventPoint)));
        });
        return random.ExcuteEnvent(openTuPoEventBmp, attackEventBmp, scaledBmp, elementAndEventPosition, windowRect, startScanY, intPtr, 1);
      }
    }
  }

  private static bool ExcuteEnvent(this Random random, Bitmap openTuPoEventBmp, Bitmap attackEventBmp, Bitmap scaledBmp, List<(Point, KeyValuePair<Point, Point>)> elementAndEventPosition, RECT windowRect, int startY, IntPtr intPtr, int clickTimes = 5)
  {
    for (int i = 0; i < elementAndEventPosition.Count; i++)
    {
      var isOpened = false;
      if (random.ExcuteEnvent(openTuPoEventBmp, scaledBmp, elementAndEventPosition[i].Item2, windowRect, clickTimes))
      {
        isOpened = true;
        ModelBase.logger.Logs(LogLevel.Info, @"点开挑战界面");
        Thread.Sleep(1500);
        scaledBmp = intPtr.GetBitmap();
      }
      if (isOpened)
      {
        for (int k = startY; k < scaledBmp.Height; k++)
        {
          var attackPoint = elementAndEventPosition[i].Item1;
          attackPoint.Y = k;
          var attackYinYnagLiaoEventPoint = random.GetRandomPoint(
            attackPoint,
            windowRect,
            (int)(scaledBmp.Width * TuPo.AttackSizeWidthRate),
            (int)(scaledBmp.Height * TuPo.AttackSizeHeightRate));
          if (random.ExcuteEnvent(attackEventBmp, scaledBmp, new(attackPoint, attackYinYnagLiaoEventPoint), windowRect, clickTimes))
          {
            ModelBase.logger.Logs(LogLevel.Info, @"点击进攻");
            return true;
          }
        }
      }
    }
    return false;
  }

}
