using NLog;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Main.Models.EndModel;

public static class EndModel
{
  public static bool ChallengeEnd(this Random random, string type, RECT windowRect, Bitmap scaledBmp)
  {
    scaledBmp.GetElementAndEventPoint(
      random,
      windowRect,
      ImagesConfig.EndClickSizeWidthRate,
      ImagesConfig.EndClickSizeHeightRate,
      ImagesConfig.EndSizeMarginLeftRate,
      ImagesConfig.EndSizeMarginTopRate,
      out var endElementAndEventPoint,
      ImagesConfig.EndClickSizeMarginLeftRate,
      ImagesConfig.EndClickSizeMarginTopRate);

    if (VictoryModel.VictoryModel.ChallengeVictory(random, type, windowRect, scaledBmp))
    {
      ModelBase.logger.Logs(LogLevel.Info, @"跳转结算画面");
    };

    if (ModelBase.ExcuteEnvent(random, EventImagePath.End, scaledBmp, endElementAndEventPoint.Item1, endElementAndEventPoint.Item2, windowRect)
      || FailedModel.FailedModel.ChallengeFailed(random, type, windowRect, scaledBmp))
    {
      ModelBase.logger.Logs(LogLevel.Info, @"该轮挑战结束");
      return true;
    };
    return false;
  }

}
