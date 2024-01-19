using NLog;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Main.Models.StartModel.ActivityModel;

public static class ActitveGoldenNightTrip20240110Model
{
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

    scaledBmp.GetElementAndEventPoint(
      random,
      windowRect, 
      GoldenNightTrip.SelectionSizeWidthRate, 
      GoldenNightTrip.SelectionSizeHeightRate, 
      GoldenNightTrip.SelectionMarginLefttRate, 
      pointRateAndPath.Item1, 
      out var selectionElementAndEventPoint);

    scaledBmp.GetElementAndEventPoint(
     random,
     windowRect,
     GoldenNightTrip.ChallengeSizeWidthRate,
     GoldenNightTrip.ChallengeSizeHeightRate,
     GoldenNightTrip.ChallengeMarginLeftRate,
     GoldenNightTrip.ChallengeMarginTopRate,
     out var challengeElementAndEventPoint);

    if (random.ExcuteEnvent(pointRateAndPath.Item2, scaledBmp, selectionElementAndEventPoint.Item1, selectionElementAndEventPoint.Item2, windowRect, 2))
    {
      ModelBase.logger.Logs(LogLevel.Info, $@"{type} 未选中，重新选中");
      return false;
    }

    if (random.ExcuteEnvent(EventImagePath.GoldenNightTripImagePath.ChallengePath, scaledBmp, challengeElementAndEventPoint.Item1, challengeElementAndEventPoint.Item2, windowRect))
    {
      ModelBase.logger.Logs(LogLevel.Info, $@"{type} 该轮挑战开始");
      return true;
    }
    return false;
  }
}
