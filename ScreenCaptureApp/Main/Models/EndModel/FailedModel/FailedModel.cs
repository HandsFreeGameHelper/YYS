using NLog;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Main.Models.EndModel.FailedModel;

public static class FailedModel
{
  public static bool ChallengeFailed(this Random random, string type, RECT windowRect, Bitmap scaledBmp)
  {
    Point elementPosition_failed = scaledBmp.GetElementPoint(ImagesConfig.FAILEDSizeMarginLeftRate, ImagesConfig.FAILEDSizeMarginTopRate);
    var failedClickPoint = random.GetRandomPoint(
      elementPosition_failed,
      windowRect,
      (int)(scaledBmp.Width * ImagesConfig.FAILEDSizeWidthRate),
      (int)(scaledBmp.Height * ImagesConfig.FAILEDSizeHeightRate));
    if (ModelBase.ExcuteEnvent(random, EventImagePath.Failed, scaledBmp, elementPosition_failed, failedClickPoint, windowRect))
    {
      ModelBase.logger.Logs(LogLevel.Info, @"该轮挑战失败");
      return true;
    };

    return false;
  }
}
