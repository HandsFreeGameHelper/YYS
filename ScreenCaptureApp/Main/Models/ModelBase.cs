using NLog;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Main.Models;

public static class ModelBase
{
  public static Logger logger = LoggerHelper.DefualtLogger;

  private static object MoveLock = new object();

  public static bool ExcuteEnvent(this Random random, Bitmap eventBmp, Bitmap scaledBmp, KeyValuePair<Point, Point> elementAndEventPosition, RECT windowRect, int clickTimes = 5)
  {
    // 在这里进行图像识别和鼠标操作
    if (ImageTools.IsElementPresent(scaledBmp, eventBmp, elementAndEventPosition.Key, true))
    {
      //scaledBmp.Save("scaledBmp.png", System.Drawing.Imaging.ImageFormat.Png);
      //eventBmp.Save("eventBmp.png", System.Drawing.Imaging.ImageFormat.Png);
      lock (MoveLock)
      {
        random.MoveAndClick(elementAndEventPosition.Value, windowRect, clickTimes, 10);
        return true;
      }
    }
    return false;
  }

  public static bool ExcuteEnvent(this Random random, string path, Bitmap scaledBmp, Point elementPosition, Point eventPosition, RECT windowRect, int clickTimes = 5)
  {
    using (Bitmap eventBmp = new Bitmap(path))
    {
      // 在这里进行图像识别和鼠标操作
      if (ImageTools.IsElementPresent(scaledBmp, eventBmp, elementPosition))
      {
        lock (MoveLock)
        {
          random.MoveAndClick(eventPosition, windowRect, clickTimes, random.Next(5, 10));
          return true;
        }
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
    outPut =
     type.Equals(ChallengeType.NORMAL) ?
          challengeSelection.Equals(ChallengeSelection.JUEXING_ANY) ?
          EnergyValue.JUEXINGG :
          challengeSelection.Equals(ChallengeSelection.BAQI_1_10) ||
          challengeSelection.Equals(ChallengeSelection.BAQI_11) ||
          challengeSelection.Equals(ChallengeSelection.BAQI_12) ||
          challengeSelection.Equals(ChallengeSelection.YEYUANHUO_TAN) ||
          challengeSelection.Equals(ChallengeSelection.YEYUANHUO_CHEN) ||
          challengeSelection.Equals(ChallengeSelection.YEYUANHUO_CHI) ||
          challengeSelection.Equals(ChallengeSelection.BEIMIHU_1) ||
          challengeSelection.Equals(ChallengeSelection.BEIMIHU_2) ||
          challengeSelection.Equals(ChallengeSelection.BEIMIHU_3) ||
          challengeSelection.Equals(ChallengeSelection.YONGSHENG_1) ||
          challengeSelection.Equals(ChallengeSelection.YONGSHENG_2) ||
          challengeSelection.Equals(ChallengeSelection.YONGSHENG_3_4) ?
          EnergyValue.YUHUN :
          challengeSelection.Equals(ChallengeSelection.YULIN_ANY) ?
          EnergyValue.YULIN :
          EMPTY :

     type.Equals(ChallengeType.TUPO) ?
          challengeSelection.Equals(ChallengeSelection.GEREN) ?
          TuPo.GEREN :
          challengeSelection.Equals(ChallengeSelection.YINYANGLIAO) ?
          TuPo.YINYANGLIAO :
          EMPTY :

     type.Equals(ChallengeType.ACTIVITIES) ?
          challengeSelection.Equals(ChallengeSelection.GOLDENNIGHTTIRP_1) ?
          GoldenNightTrip.HUODONGSHI :
           challengeSelection.Equals(ChallengeSelection.GOLDENNIGHTTIRP_2) ?
          GoldenNightTrip.ZHANSHUTING :
           challengeSelection.Equals(ChallengeSelection.GOLDENNIGHTTIRP_3) ?
          GoldenNightTrip.CHUANYUANSHI :
           challengeSelection.Equals(ChallengeSelection.GOLDENNIGHTTIRP_4) ?
          GoldenNightTrip.HUANGJINGE :
          EMPTY :

     EMPTY;
    return true;
  }
}
