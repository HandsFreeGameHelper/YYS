using NLog;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Main.Models.EndModel.VictoryModel;

public static class VictoryModel
{
  public static bool ChallengeVictory(this Random random, string type, RECT windowRect, Bitmap scaledBmp)
  {
    scaledBmp.GetElementAndEventPoint(
      random,
      windowRect,
      ImagesConfig.VictorySizeWidthRate,
      ImagesConfig.VictorySizeHeightRate,
      ImagesConfig.VictorySizeMarginLeftRate,
      ImagesConfig.VictorySizeMarginTopRate,
      out var victoryElementAndEventPoint);

    if (ModelBase.ExcuteEnvent(random, EventImagePath.Victory, scaledBmp, victoryElementAndEventPoint.Item1, victoryElementAndEventPoint.Item2, windowRect))
    {
      ModelBase.logger.Logs(LogLevel.Info, @"该轮挑战胜利");
      return true;
    };

    return false;
  }
}
