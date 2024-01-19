using NLog;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Main.Models.EndModel.FailedModel;

public static class FailedModel
{
  public static bool ChallengeFailed(this Random random, string type, RECT windowRect, Bitmap scaledBmp)
  {
    scaledBmp.GetElementAndEventPoint(
      random,
      windowRect,
      ImagesConfig.FAILEDSizeWidthRate,
      ImagesConfig.FAILEDSizeHeightRate,
      ImagesConfig.FAILEDSizeMarginLeftRate,
      ImagesConfig.FAILEDSizeMarginTopRate,
      out var failedElementAndEventPoint);

    if (ModelBase.ExcuteEnvent(random, EventImagePath.Failed, scaledBmp, failedElementAndEventPoint.Item1, failedElementAndEventPoint.Item2, windowRect))
    {
      ModelBase.logger.Logs(LogLevel.Info, @"该轮挑战失败");
      return true;
    };

    return false;
  }
}
