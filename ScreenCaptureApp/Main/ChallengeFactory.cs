using ScreenCaptureApp.Utils;
using System.IO;
using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Main;

public static class ChallengeFactory
{
  private static object MoveLock = new object();
  public static bool Challenge(this Random random, string type, RECT windowRect, Bitmap scaledBmp, string energyValue, bool isTeam, IntPtr intPtr)
  {
    var widthAndHeight = windowRect.GetWidthAndHeight();
    if (ChallengeType.NOMAL.Equals(type))
    {
      Point elementPosition_start = isTeam ?
      new Point((int)(scaledBmp.Width * ImagesConfig.StartXRateTeam), (int)(scaledBmp.Height * ImagesConfig.StartYRateTeam)) :
      new Point((int)(scaledBmp.Width * ImagesConfig.StartXRate), (int)(scaledBmp.Height * ImagesConfig.StartYRate));
      var startPosition = isTeam ?
        random.GetRandomPoint(
          windowRect.Right - (int)(widthAndHeight.Item1 * ImagesConfig.StartPointXLeftTeamRate),
          windowRect.Right - (int)(widthAndHeight.Item1 * ImagesConfig.StartPointXRightTeamRate),
          windowRect.Bottom - (int)(widthAndHeight.Item2 * ImagesConfig.StartPointYTopTeamRate),
          windowRect.Bottom - (int)(widthAndHeight.Item2 * ImagesConfig.StartPointYBottomTeamRate)) :
        random.GetRandomPoint(
          windowRect.Right - (int)(widthAndHeight.Item1 * ImagesConfig.StartPointXLeftRate),
          windowRect.Right - (int)(widthAndHeight.Item1 * ImagesConfig.StartPointXRightRate),
          windowRect.Bottom - (int)(widthAndHeight.Item2 * ImagesConfig.StartPointYTopRate),
          windowRect.Bottom - (int)(widthAndHeight.Item2 * ImagesConfig.StartPointYBottomRate));
      var team = isTeam ? "_team" : "";
      if (ExcuteEnvent(random, $@"./Resource/Start/start_{energyValue}{team}.png", scaledBmp, elementPosition_start, startPosition, windowRect))
      {
        Console.WriteLine(@"该轮挑战开始");
        return true;
      };
      return false;
    }
    else if (ChallengeType.ACTIVITIES.Equals(type))
    {
      return false;
    }
    else if (ChallengeType.TUPO.Equals(type))
    {
      return random.TuPoChallenge(energyValue, windowRect,scaledBmp , intPtr);
    }
    return false;
  }
  public static bool Challenge(this Random random, string type, RECT windowRect, Bitmap scaledBmp)
  {
    var widthAndHeight = windowRect.GetWidthAndHeight();
    if (ChallengeType.NOMAL.Equals(type) || ChallengeType.TUPO.Equals(type))
    {
      Point elementPosition_end = new Point((int)(scaledBmp.Width * ImagesConfig.EndXRate), (int)(scaledBmp.Height * ImagesConfig.EndYRate));
      Point elementPosition_shibai = new Point((int)(scaledBmp.Width * ImagesConfig.SHIBAISizeMarginLeftRate), (int)(scaledBmp.Height * ImagesConfig.SHIBAISizeMarginTopRate));
      var endclickPoint = random.GetRandomPoint(
          windowRect.Right - (int)(widthAndHeight.Item1 * ImagesConfig.EndPointXLeftRate),
          windowRect.Right - (int)(widthAndHeight.Item1 * ImagesConfig.EndPointXRightRate),
          windowRect.Bottom - (int)(widthAndHeight.Item2 * ImagesConfig.EndPointYTopRate),
          windowRect.Bottom - (int)(widthAndHeight.Item2 * ImagesConfig.EndPointYBottomRate));
      var shibaiclickPoint = random.GetRandomPoint(
        elementPosition_shibai,
        windowRect,
        (int)(scaledBmp.Width * ImagesConfig.SHIBAISizeWidthRate),
        (int)(scaledBmp.Height * ImagesConfig.SHIBAISizeHeightRate));
      if (ExcuteEnvent(random, EventImagePath.End, scaledBmp, elementPosition_end, endclickPoint, windowRect)
        || ExcuteEnvent(random, EventImagePath.Failed, scaledBmp, elementPosition_shibai, shibaiclickPoint, windowRect))
      {
        Console.WriteLine(@"该轮挑战结束");
        return true;
      };
      return false;
    }
    else if (ChallengeType.ACTIVITIES.Equals(type))
    {
      return false;
    }
    return false;
  }

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
      (int)(scaledBmp.Height * TuPo.TuPoPanelMarginTopGeRenRate) - 20 : (int)(scaledBmp.Height * TuPo.TuPoPanelMarginTopYinYangLiaoRate) - 20;
    var endScanY =
      TuPo.GEREN.Equals(type) ?
      scaledBmp.Height : (int)(scaledBmp.Height * TuPo.YinYangLiaoEndYRate);

    var elementAndEventPosition = new List<(Point, KeyValuePair<Point, Point>)>();
    var elements = new List<(Point, Point)>();
    using (Bitmap noChance = new Bitmap(EventImagePath.NoChance))
    {
      var noChancePosition = new Point((int)(scaledBmp.Width * TuPo.NoChanceMarginLeftRate), (int)(scaledBmp.Height * TuPo.NoChanceMarginTopRate));
      if (ImageTools.IsElementPresent(scaledBmp, noChance, noChancePosition))
      {
        Console.WriteLine("挑战次数为0，等待恢复");
        return false;
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
        if (ImageTools.IsElementPresent(scaledBmp,yinyangliaoSelected, yinyangliaoSelectedPosition)
          || ImageTools.IsElementPresent(scaledBmp, gerenSelected, gerenSelectedPosition))
        {
          Point mousePosition = Cursor.Position;
          MouseEventTools.MoveTo(
            mousePosition,
            new Point(windowRect.Left + (int)(scaledBmp.Width * TuPo.ResetMarginLeftRate), windowRect.Top + (int)(scaledBmp.Height * TuPo.ResetMarginTopRate)),
            2);
          Thread.Sleep(1000);
          MouseEventTools.ScrollWheelDown();
        }
      }
    }
    return false;
  }
  private static bool ExcuteEnvent(this Random random, string path, Bitmap scaledBmp, Point elementPosition, Point eventPosition, RECT windowRect, int clickTimes = 5)
  {
    using (Bitmap eventBmp = new Bitmap(path))
    {
      // 在这里进行图像识别和鼠标操作
      if (ImageTools.IsElementPresent(scaledBmp, eventBmp, elementPosition))
      {
        lock (MoveLock)
        {
          random.MoveAndClick(eventPosition, windowRect, clickTimes, random.Next(5, 10));
          return true;
        }
      }
      return false;
    }
  }
  private static bool ExcuteEnvent(this Random random, Bitmap eventBmp, Bitmap scaledBmp, KeyValuePair<Point, Point> elementAndEventPosition, RECT windowRect, int clickTimes = 5)
  {
    // 在这里进行图像识别和鼠标操作
    if (ImageTools.IsElementPresent(scaledBmp, eventBmp, elementAndEventPosition.Key,true))
    {
      //scaledBmp.Save("scaledBmp.png", System.Drawing.Imaging.ImageFormat.Png);
      //eventBmp.Save("eventBmp.png", System.Drawing.Imaging.ImageFormat.Png);
      lock (MoveLock)
      {
        random.MoveAndClick(elementAndEventPosition.Value, windowRect, clickTimes, 10);
        return true;
      }
    }
    return false;
  }
  private static bool ExcuteEnvent(this Random random, Bitmap openTuPoEventBmp, Bitmap attackEventBmp, Bitmap scaledBmp, List<(Point, KeyValuePair<Point, Point>)> elementAndEventPosition, RECT windowRect, int startY,IntPtr intPtr, int clickTimes = 5)
  {
    for (int i = 0; i < elementAndEventPosition.Count; i++)
    {
      var isOpened = false;
      if (random.ExcuteEnvent(openTuPoEventBmp, scaledBmp, elementAndEventPosition[i].Item2, windowRect, clickTimes))
      {
        isOpened = true;
        Console.WriteLine(@"点开挑战界面");
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
            Console.WriteLine(@"点击进攻");
            return true;
          }
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
        return random.ExcuteEnvent(openTuPoEventBmp, attackEventBmp, scaledBmp, elementAndEventPosition, windowRect, startScanY,intPtr, 1);
      }
    }
  }
  public static bool TryJudgeChallengeModel(string? type, string? challengeSelection, out string outPut)
  {
    outPut = EMPTY;
    if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(challengeSelection))
    {
      return false;
    }
    outPut = 
     type.Equals(ChallengeType.NOMAL) ?
          challengeSelection.Equals(ChallengeSelection.JUEXIN_ANY) ?
          EnergyValue.JUEXING :
          challengeSelection.Equals(ChallengeSelection.BAQI_1_10) ||
          challengeSelection.Equals(ChallengeSelection.BAQI_11) ||
          challengeSelection.Equals(ChallengeSelection.BAQI_12) ||
          challengeSelection.Equals(ChallengeSelection.YEYUANHUO_TAN) ||
          challengeSelection.Equals(ChallengeSelection.YEYUANHUO_CHEN) ||
          challengeSelection.Equals(ChallengeSelection.YEYUANHUO_CHI) ||
          challengeSelection.Equals(ChallengeSelection.BEIMIHU_1) ||
          challengeSelection.Equals(ChallengeSelection.BEIMIHU_2) ||
          challengeSelection.Equals(ChallengeSelection.BEIMIHU_3) ||
          challengeSelection.Equals(ChallengeSelection.YONGSHEN_1) ||
          challengeSelection.Equals(ChallengeSelection.YONGSHEN_2) ||
          challengeSelection.Equals(ChallengeSelection.YONGSHEN_3_4) ?
          EnergyValue.YUHUN :
          challengeSelection.Equals(ChallengeSelection.YULIN_ANY) ?
          EnergyValue.YULIN :
          EMPTY: 
           
     type.Equals(ChallengeType.TUPO) ?
          challengeSelection.Equals(ChallengeSelection.GEREN) ?
          TuPo.GEREN :
          challengeSelection.Equals(ChallengeSelection.YINYANGLIAO) ?
          TuPo.YINYANGLIAO :
          EMPTY:
     EMPTY;
    return true;
  }
}
