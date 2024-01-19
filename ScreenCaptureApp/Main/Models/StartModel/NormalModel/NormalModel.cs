using NLog;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Main.Models.StartModel.NormalModel;

public static class NormalModel
{
  public static bool NormalChallenge(this Random random, string type, RECT windowRect, Bitmap scaledBmp, string energyValue, bool isTeam)
  {
    scaledBmp.GetElementAndEventPoint(
      random,
      windowRect,
      isTeam ? ImagesConfig.TeamStartSizeWidthRate : ImagesConfig.StartSizeWidthRate,
      isTeam ?  ImagesConfig.TeamStartSizeHeightRate : ImagesConfig.StartSizeHeightRate,
      isTeam ? ImagesConfig.TeamStartSizeMarginLeftRate : ImagesConfig.StartSizeMarginLeftRate,
      isTeam ? ImagesConfig.TeamStartSizeMarginTopRate : ImagesConfig.StartSizeMarginTopRate,
      out var endElementAndEventPoint);

    var rePath = $@"./Resource/Start/start";
    var path = isTeam ? energyValue.Contains(ChallengeSelection.YONGSHENG) ? $@"{rePath}_team_yongsheng.png" : $@"{rePath}_team.png" : $@"./Resource/Start/start_{energyValue}.png";
    if (random.ExcuteEnvent(path, scaledBmp, endElementAndEventPoint.Item1, endElementAndEventPoint.Item2, windowRect, 3))
    {
      ModelBase.logger.Logs(LogLevel.Info, @"该轮挑战开始");
      return true;
    };
    return false;
  }
}
