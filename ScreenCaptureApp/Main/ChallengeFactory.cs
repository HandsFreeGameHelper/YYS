using ScreenCaptureApp.Main.Models.EndModel;
using ScreenCaptureApp.Main.Models.StartModel.ActivityModel;
using ScreenCaptureApp.Main.Models.StartModel.NormalModel;
using ScreenCaptureApp.Main.Models.StartModel.TuPoModel;
using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Main;

public static class ChallengeFactory
{

  public static bool StartChallenge(this Random random, string type, RECT windowRect, Bitmap scaledBmp, string energyValue, bool isTeam, IntPtr intPtr)
  {
    if (ChallengeType.NORMAL.Equals(type))
    {
      return random.NormalChallenge(type, windowRect, scaledBmp, energyValue, isTeam);
    }
    else if (ChallengeType.ACTIVITIES.Equals(type))
    {
      return random.ActitveGoldenNightTrip20240110(energyValue, windowRect, scaledBmp);
    }
    else if (ChallengeType.TUPO.Equals(type))
    {
      return random.TuPoChallenge(energyValue, windowRect, scaledBmp, intPtr);
    }
    return false;
  }
  public static bool EndChallenge(this Random random, string type, RECT windowRect, Bitmap scaledBmp)
  {
    return random.ChallengeEnd(type, windowRect, scaledBmp);
  }

}
