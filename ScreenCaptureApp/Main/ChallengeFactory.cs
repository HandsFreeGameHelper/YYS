using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Main;

public static class ChallengeFactory
{

  public static bool Challenge(this Random random, string? type, RECT windowRect, Bitmap scaledBmp, string? energyValue)
  {
    var widthAndHeight = windowRect.GetWidthAndHeight();
    if (ChallengeType.NOMAL.Equals(type))
    {
      Point elementPosition_start = new Point(ImagesConfig.RegionStartX, ImagesConfig.RegionStartY);
      var startPosition = random.GetRandomPoint(
          windowRect.Right - (int)(widthAndHeight.Item1 * ImagesConfig.StartPointXLeftRate), 
          windowRect.Right - (int)(widthAndHeight.Item1 * ImagesConfig.StartPointXRightRate), 
          windowRect.Bottom - (int)(widthAndHeight.Item2 * ImagesConfig.StartPointYTopRate), 
          windowRect.Bottom - (int)(widthAndHeight.Item2 * ImagesConfig.StartPointYBottomRate));
      if (ExcuteEnvent(random, $@"./Resource/Start/start_{energyValue}.png", scaledBmp, elementPosition_start, startPosition, windowRect))
      {
        Console.WriteLine(@"该轮挑战开始");
        return true;
      };
      return false;
    }
    else if (ChallengeType.ACTIVITIES.Equals(type))
    {
      return false;
    }
    return false;
  }
  public static bool Challenge(this Random random, string? type, RECT windowRect, Bitmap scaledBmp)
  {
    var widthAndHeight = windowRect.GetWidthAndHeight();
    if (ChallengeType.NOMAL.Equals(type))
    {
      Point elementPosition_end = new Point(ImagesConfig.RegionEndX, ImagesConfig.RegionEndY);
      var endclickPoint = random.GetRandomPoint(
          windowRect.Right - (int)(widthAndHeight.Item1 * ImagesConfig.EndPointXLeftRate), 
          windowRect.Right - (int)(widthAndHeight.Item1 * ImagesConfig.EndPointXRightRate), 
          windowRect.Bottom - (int)(widthAndHeight.Item2 * ImagesConfig.EndPointYTopRate), 
          windowRect.Bottom - (int)(widthAndHeight.Item2 * ImagesConfig.EndPointYBottomRate));
      if (ExcuteEnvent(random, $@"./Resource/End/end.png", scaledBmp, elementPosition_end, endclickPoint, windowRect))
      {
        Console.WriteLine(@"该轮挑战结束");
        return true;
      };
      return false;
    }
    else if (ChallengeType.ACTIVITIES.Equals(type))
    {
      return false;
    }
    return false;
  }

  private static bool ExcuteEnvent(this Random random, string path, Bitmap scaledBmp, Point elementPosition, Point eventPosition, RECT windowRect)
  {
    using (Bitmap eventBmp = new Bitmap(path))
    {
      // 在这里进行图像识别和鼠标操作
      if (ImageTools.IsElementPresent(scaledBmp, eventBmp, elementPosition))
      {
        random.MoveAndClick(eventPosition, windowRect, random.Next(5, 10));
        return true;
      }
      return false;
    }
  }

  public static bool TryJudgeChallengeModel(string? type, string? challengeSelection, out string outPut)
  {
    outPut = EMPTY;
    if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(challengeSelection))
    {
      return false;
    }
    outPut = type.Equals(ChallengeType.NOMAL) ?
                challengeSelection.Equals(ChallengeSelection.JUEXIN_ANY) ?
                EnergyValue.JUEXING :
                challengeSelection.Equals(ChallengeSelection.BAQI_1_10) ||
                challengeSelection.Equals(ChallengeSelection.BAQI_11) ||
                challengeSelection.Equals(ChallengeSelection.BAQI_12) ||
                challengeSelection.Equals(ChallengeSelection.YEYUANHUO_TAN) ||
                challengeSelection.Equals(ChallengeSelection.YEYUANHUO_CHEN) ||
                challengeSelection.Equals(ChallengeSelection.YEYUANHUO_CHI) ||
                challengeSelection.Equals(ChallengeSelection.BEIMIHU_1) ||
                challengeSelection.Equals(ChallengeSelection.BEIMIHU_2) ||
                challengeSelection.Equals(ChallengeSelection.BEIMIHU_3) ||
                challengeSelection.Equals(ChallengeSelection.YONGSHEN_1) ||
                challengeSelection.Equals(ChallengeSelection.YONGSHEN_2) ||
                challengeSelection.Equals(ChallengeSelection.YONGSHEN_3_4) ?
                EnergyValue.YUHUN :
                challengeSelection.Equals(ChallengeSelection.YULIN_ANY) ?
                EnergyValue.YULIN :
                EMPTY
             : EMPTY;
    return true;
  }
}
