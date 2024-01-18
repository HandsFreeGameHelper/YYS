using NUnit.Framework;
using ScreenCaptureApp.Main.Models.StartModel.TuPoModel;
using ScreenCaptureApp.Utils;
using static ScreenCaptureApp.Utils.Contains;

namespace ScreenCaptureAppTest.Utils;

internal class ChallengeFactoryTest
{
  [Test]
  public void TuPoChallengeTest()
  {
    var random = new Random();
    WindowsFilter.GetWindows();
    var targetHWnds = WindowsFilter.WindowHandles;
    SystemRuntimes.RECT windowRect;
    SystemRuntimes.GetWindowRect(targetHWnds.First(), out windowRect);
    var bmp = targetHWnds.First().GetBitmap();
    random.TuPoChallenge(TuPo.YINYANGLIAO, windowRect, bmp, targetHWnds.First());
  }
}
