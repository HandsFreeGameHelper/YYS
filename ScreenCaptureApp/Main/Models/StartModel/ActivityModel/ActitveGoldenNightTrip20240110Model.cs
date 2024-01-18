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
      ModelBase.logger.Logs(LogLevel.Info, $@"{type} 未选中，重新选中");
      return false;
    }

    if (random.ExcuteEnvent(EventImagePath.GoldenNightTripImagePath.ChallengePath, scaledBmp, challengeElementPoint, challengeEventPoint, windowRect))
    {
      ModelBase.logger.Logs(LogLevel.Info, $@"{type} 该轮挑战开始");
      return true;
    }
    return false;
  }
}
