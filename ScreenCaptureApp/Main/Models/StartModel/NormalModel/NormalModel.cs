using NLog;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Main.Models.StartModel.NormalModel;

public static class NormalModel
{
  public static bool NormalChallenge(this Random random, string type, RECT windowRect, Bitmap scaledBmp, string energyValue, bool isTeam)
  {
    var widthAndHeight = windowRect.GetWidthAndHeight();
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
    if (random.ExcuteEnvent($@"./Resource/Start/start_{energyValue}{team}.png", scaledBmp, elementPosition_start, startPosition, windowRect, 3))
    {
      ModelBase.logger.Logs(LogLevel.Info, @"该轮挑战开始");
      return true;
    };
    return false;
  }
}
