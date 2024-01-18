using NLog;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Main;

public static class ChallengeFactory
{
  private static Logger logger = LoggerHelper.DefualtLogger;
  private static List<IntPtr> needLogs = new List<IntPtr>();
  private static object MoveLock = new object();

  public static bool StartChallenge(this Random random, string type, RECT windowRect, Bitmap scaledBmp, string energyValue, bool isTeam, IntPtr intPtr)
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
          windowRect.Bottom - (int)(widthAndHeight.Item2 * ImagesConfig.StartPointYBottomTeamRate) - (int)(widthAndHeight.Item2 * 30 * 1.0 / RegionWidth)) :
        random.GetRandomPoint(
          windowRect.Right - (int)(widthAndHeight.Item1 * ImagesConfig.StartPointXLeftRate),
          windowRect.Right - (int)(widthAndHeight.Item1 * ImagesConfig.StartPointXRightRate),
          windowRect.Bottom - (int)(widthAndHeight.Item2 * ImagesConfig.StartPointYTopRate),
          windowRect.Bottom - (int)(widthAndHeight.Item2 * ImagesConfig.StartPointYBottomRate));
      var team = isTeam ? "_team" : "";
      if (ExcuteEnvent(random, $@"./Resource/Start/start_{energyValue}{team}.png", scaledBmp, elementPosition_start, startPosition, windowRect, 3))
      {
        logger.Logs(LogLevel.Info, @"该轮挑战开始");
        return true;
      };
      return false;
    }
    else if (ChallengeType.ACTIVITIES.Equals(type))
    {
      return random.ActitveGoldenNightTrip20240110(energyValue, windowRect, scaledBmp);
    }
    else if (ChallengeType.TUPO.Equals(type))
    {
      return random.TuPoChallenge(energyValue, windowRect, scaledBmp, intPtr);
    }
    return false;
  }

  public static bool EndChallenge(this Random random, string type, RECT windowRect, Bitmap scaledBmp)
  {
    Point elementPosition_end = scaledBmp.GetElementPoint(ImagesConfig.EndSizeMarginLeftRate, ImagesConfig.EndSizeMarginTopRate);
    Point elementPosition_failed = scaledBmp.GetElementPoint(ImagesConfig.FAILEDSizeMarginLeftRate, ImagesConfig.FAILEDSizeMarginTopRate); 
    Point elementPosition_victory = scaledBmp.GetElementPoint(ImagesConfig.VictorySizeMarginLeftRate, ImagesConfig.VictorySizeMarginTopRate);
    var endClickPoint = random.GetRandomPoint(
       scaledBmp.GetElementPoint(ImagesConfig.EndClickSizeMarginLeftRate, ImagesConfig.EndClickSizeMarginTopRate),
       windowRect,
       scaledBmp.Multiply(ImagesConfig.EndClickSizeWidthRate, true),
       scaledBmp.Multiply(ImagesConfig.EndClickSizeHeightRate, false)
      );
    var failedClickPoint = random.GetRandomPoint(
      elementPosition_failed,
      windowRect,
      (int)(scaledBmp.Width * ImagesConfig.FAILEDSizeWidthRate),
      (int)(scaledBmp.Height * ImagesConfig.FAILEDSizeHeightRate));
    var victoryClickPoint = random.GetRandomPoint(
      elementPosition_failed,
      windowRect,
      (int)(scaledBmp.Width * ImagesConfig.VictorySizeWidthRate),
      (int)(scaledBmp.Height * ImagesConfig.VictorySizeHeightRate));

    if (ExcuteEnvent(random, EventImagePath.Victory, scaledBmp, elementPosition_victory, victoryClickPoint, windowRect))
    {
      logger.Logs(LogLevel.Info, @"挑战成功，跳转结算画面");
    };

    if (ExcuteEnvent(random, EventImagePath.End, scaledBmp, elementPosition_end, endClickPoint, windowRect)
      || ExcuteEnvent(random, EventImagePath.Failed, scaledBmp, elementPosition_failed, failedClickPoint, windowRect))
    {
      logger.Logs(LogLevel.Info, @"该轮挑战结束");
      return true;
    };

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
          logger.Logs(LogLevel.Info, @"挑战次数为0，等待恢复");
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
    if (ImageTools.IsElementPresent(scaledBmp, eventBmp, elementAndEventPosition.Key, true))
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

  private static bool ExcuteEnvent(this Random random, Bitmap openTuPoEventBmp, Bitmap attackEventBmp, Bitmap scaledBmp, List<(Point, KeyValuePair<Point, Point>)> elementAndEventPosition, RECT windowRect, int startY, IntPtr intPtr, int clickTimes = 5)
  {
    for (int i = 0; i < elementAndEventPosition.Count; i++)
    {
      var isOpened = false;
      if (random.ExcuteEnvent(openTuPoEventBmp, scaledBmp, elementAndEventPosition[i].Item2, windowRect, clickTimes))
      {
        isOpened = true;
        logger.Logs(LogLevel.Info, @"点开挑战界面");
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
            logger.Logs(LogLevel.Info, @"点击进攻");
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
        return random.ExcuteEnvent(openTuPoEventBmp, attackEventBmp, scaledBmp, elementAndEventPosition, windowRect, startScanY, intPtr, 1);
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
          EMPTY :

     type.Equals(ChallengeType.TUPO) ?
          challengeSelection.Equals(ChallengeSelection.GEREN) ?
          TuPo.GEREN :
          challengeSelection.Equals(ChallengeSelection.YINYANGLIAO) ?
          TuPo.YINYANGLIAO :
          EMPTY :

     type.Equals(ChallengeType.ACTIVITIES) ?
          challengeSelection.Equals(ChallengeSelection.GOLDENNIGHTTIRP_1) ?
          GoldenNightTrip.HUODONGSHI :
           challengeSelection.Equals(ChallengeSelection.GOLDENNIGHTTIRP_2) ?
          GoldenNightTrip.ZHANSHUTING :
           challengeSelection.Equals(ChallengeSelection.GOLDENNIGHTTIRP_3) ?
          GoldenNightTrip.CHUANYUANSHI :
           challengeSelection.Equals(ChallengeSelection.GOLDENNIGHTTIRP_4) ?
          GoldenNightTrip.HUANGJINGE:
          EMPTY :

     EMPTY;
    return true;
  }

  /// <summary>
  /// 黄金夜航-藏金阁楼
  /// </summary>
  /// <param name="random"></param>
  /// <param name="type"></param>
  /// <param name="windowRect"></param>
  /// <param name="scaledBmp"></param>
  /// <param name="intPtr"></param>
  /// <returns></returns>
  public static bool ActitveGoldenNightTrip20240110(this Random random, string type, RECT windowRect, Bitmap scaledBmp)
  {
    var pointRateAndPath =
      GoldenNightTrip.HUODONGSHI.Equals(type) ? (GoldenNightTrip.HuoDongShiMarginTopRate, EventImagePath.GoldenNightTripImagePath.HuodongshiPath) :
      GoldenNightTrip.ZHANSHUTING.Equals(type) ? (GoldenNightTrip.ZhanShuTingMarginTopRate, EventImagePath.GoldenNightTripImagePath.ZhanshutingPath) :
      GoldenNightTrip.CHUANYUANSHI.Equals(type) ? (GoldenNightTrip.ChuanYuanShiMarginTopRate, EventImagePath.GoldenNightTripImagePath.ChuanyuanshiPath) :
      GoldenNightTrip.HUANGJINGE.Equals(type) ? (GoldenNightTrip.HuangJinGeMarginTopRate, EventImagePath.GoldenNightTripImagePath.HuangjingePath) :
      (0, "");

    var selectionWidth = scaledBmp.Multiply(GoldenNightTrip.SelectionSizeWidthRate, true);
    var selectionHeight = scaledBmp.Multiply(GoldenNightTrip.SelectionSizeHeightRate, false);
    var selectionElementPoint = scaledBmp.GetElementPoint(GoldenNightTrip.SelectionMarginLefttRate, pointRateAndPath.Item1);

    var selectionEventPoint = random.GetRandomPoint(
      selectionElementPoint,
      windowRect,
      selectionWidth,
      selectionHeight);

    var challengeWidth = scaledBmp.Multiply(GoldenNightTrip.ChallengeSizeWidthRate, true);
    var challengeHeight = scaledBmp.Multiply(GoldenNightTrip.ChallengeSizeHeightRate, false);
    var challengeElementPoint = scaledBmp.GetElementPoint(GoldenNightTrip.ChallengeMarginLeftRate, GoldenNightTrip.ChallengeMarginTopRate);

    var challengeEventPoint = random.GetRandomPoint(
        challengeElementPoint,
        windowRect,
        challengeWidth,
        challengeHeight
      );

    if (random.ExcuteEnvent(pointRateAndPath.Item2, scaledBmp, selectionElementPoint, selectionEventPoint, windowRect, 2))
    {
      logger.Logs(LogLevel.Info, $@"{type} 未选中，重新选中");
      return false;
    }

    if (random.ExcuteEnvent(EventImagePath.GoldenNightTripImagePath.ChallengePath, scaledBmp, challengeElementPoint, challengeEventPoint, windowRect))
    {
      logger.Logs(LogLevel.Info, $@"{type} 该轮挑战开始");
      return true;
    }
    return false;
  }
}
