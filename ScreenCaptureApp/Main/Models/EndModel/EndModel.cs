using NLog;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Main.Models.EndModel;

public static class EndModel
{
  public static bool ChallengeEnd(this Random random, string type, RECT windowRect, Bitmap scaledBmp)
  {
    Point elementPosition_end = scaledBmp.GetElementPoint(ImagesConfig.EndSizeMarginLeftRate, ImagesConfig.EndSizeMarginTopRate);
    var endClickPoint = random.GetRandomPoint(
       scaledBmp.GetElementPoint(ImagesConfig.EndClickSizeMarginLeftRate, ImagesConfig.EndClickSizeMarginTopRate),
       windowRect,
       scaledBmp.Multiply(ImagesConfig.EndClickSizeWidthRate, true),
       scaledBmp.Multiply(ImagesConfig.EndClickSizeHeightRate, false)
      );


    if (VictoryModel.VictoryModel.ChallengeVictory(random, type, windowRect, scaledBmp))
    {
      ModelBase.logger.Logs(LogLevel.Info, @"挑战成功，跳转结算画面");
    };

    if (ModelBase.ExcuteEnvent(random, EventImagePath.End, scaledBmp, elementPosition_end, endClickPoint, windowRect)
      || FailedModel.FailedModel.ChallengeFailed(random, type, windowRect, scaledBmp))
    {
      ModelBase.logger.Logs(LogLevel.Info, @"该轮挑战结束");
      return true;
    };

    return false;
  }

}
