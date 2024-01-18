using NUnit.Framework;
using static ScreenCaptureApp.Utils.Contains;

namespace ScreenCaptureAppTest.Utils;

internal class OtherTests
{
  [Test]
  public void Test1()
  {
    var tChallengeType = typeof(ChallengeType);

    var fields = tChallengeType.GetFields().ToList();

    fields.ForEach(x =>
    {
      var pro = tChallengeType.GetField(x.Name)?.GetValue(null);
    });
  }
}
