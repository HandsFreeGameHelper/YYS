using NLog;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Main.Models.EndModel.VictoryModel;

public static class VictoryModel
{
  public static bool ChallengeVictory(this Random random, string type, RECT windowRect, Bitmap scaledBmp)
  {
    Point elementPosition_victory = scaledBmp.GetElementPoint(ImagesConfig.VictorySizeMarginLeftRate, ImagesConfig.VictorySizeMarginTopRate);

    var victoryClickPoint = random.GetRandomPoint(
      elementPosition_victory,
      windowRect,
      (int)(scaledBmp.Width * ImagesConfig.VictorySizeWidthRate),
      (int)(scaledBmp.Height * ImagesConfig.VictorySizeHeightRate));
    if (ModelBase.ExcuteEnvent(random, EventImagePath.Victory, scaledBmp, elementPosition_victory, victoryClickPoint, windowRect))
    {
      ModelBase.logger.Logs(LogLevel.Info, @"该轮挑战胜利");
      return true;
    };

    return false;
  }
}
