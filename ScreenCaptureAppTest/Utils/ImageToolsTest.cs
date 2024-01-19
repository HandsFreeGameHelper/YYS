using NUnit.Framework;
using ScreenCaptureApp.Utils;
using System.Drawing;
using System.Windows.Forms;
using static ScreenCaptureApp.Utils.Contains;

namespace ScreenCaptureAppTest.Utils;

internal class ImageToolsTest
{
  [Test]
  public void NextTest()
  {
    var picBoxs = new List<PictureBox>()
    {
      new PictureBox()
      {
        Name="1_1"
      },
      new PictureBox()
      {
        Name = "1_2"
      }
    };
    var picBoxs2 = new List<PictureBox>()
    {
      new PictureBox()
      {
        Name = "2_1"
      },
      new PictureBox()
      {
        Name = "2_2"
      },
      new PictureBox()
      {
        Name = "2_3"
      },
    };

    try
    {
      var r1 = picBoxs.Next().Name;
      var r2 = picBoxs2.Next().Name;
      var r3 = picBoxs.Next().Name;
      var r4 = picBoxs.TryGetNext().Name;
      var r5 = picBoxs2.Next().Name;
      var r6 = picBoxs2.Next().Name;
      var r7 = picBoxs.TryGetNext().Name;
      var r8 = picBoxs2.TryGetNext().Name;
      var r9 = picBoxs.Next().Name;
    }
    catch { }
  }

  [Test]
  public void TestSnape2()
  {
    WindowsFilter.GetWindows();
    var targetHWnds = WindowsFilter.WindowHandles;
    var scaledBmp = targetHWnds.First().GetBitmap();

    var type = GoldenNightTrip.HUANGJINGE;
    var pointRateAndPath =
      GoldenNightTrip.HUODONGSHI.Equals(type) ? (GoldenNightTrip.HuoDongShiMarginTopRate, EventImagePath.GoldenNightTripImagePath.HuodongshiPath) :
      GoldenNightTrip.ZHANSHUTING.Equals(type) ? (GoldenNightTrip.ZhanShuTingMarginTopRate, EventImagePath.GoldenNightTripImagePath.ZhanshutingPath) :
      GoldenNightTrip.CHUANYUANSHI.Equals(type) ? (GoldenNightTrip.ChuanYuanShiMarginTopRate, EventImagePath.GoldenNightTripImagePath.ChuanyuanshiPath) :
      GoldenNightTrip.HUANGJINGE.Equals(type) ? (GoldenNightTrip.HuangJinGeMarginTopRate, EventImagePath.GoldenNightTripImagePath.HuangjingePath) :
      (0, "");

    var selectionWidth = scaledBmp.Multiply(GoldenNightTrip.SelectionSizeWidthRate, true);
    var selectionHeight = scaledBmp.Multiply(GoldenNightTrip.SelectionSizeHeightRate, false);
    var selectionElementPoint = scaledBmp.GetElementPoint(GoldenNightTrip.SelectionMarginLefttRate, pointRateAndPath.Item1);
    var size = new Size(selectionWidth, selectionHeight);

    var challengeWidth = scaledBmp.Multiply(GoldenNightTrip.ChallengeSizeWidthRate, true);
    var challengeHeight = scaledBmp.Multiply(GoldenNightTrip.ChallengeSizeHeightRate, false);
    var challengeElementPoint = scaledBmp.GetElementPoint(GoldenNightTrip.ChallengeMarginLeftRate, GoldenNightTrip.ChallengeMarginTopRate);

    var size2 = new Size(challengeWidth, challengeHeight);

    var endWidth = scaledBmp.Multiply(ImagesConfig.EndSizeWidthRate, true);
    var endHeight = scaledBmp.Multiply(ImagesConfig.EndSizeHeightRate, false);
    var endElementPoint = scaledBmp.GetElementPoint(ImagesConfig.EndSizeMarginLeftRate, ImagesConfig.EndSizeMarginTopRate);
    var size3 = new Size(endWidth, endHeight);

    var startWidth = scaledBmp.Multiply(ImagesConfig.StartSizeWidthRate, true);
    var startHeight = scaledBmp.Multiply(ImagesConfig.StartSizeHeightRate, false);
    var startElementPoint = scaledBmp.GetElementPoint(ImagesConfig.StartSizeMarginLeftRate, ImagesConfig.StartSizeMarginTopRate);
    var size4 = new Size(startWidth, startHeight);

    var teamStartWidth = scaledBmp.Multiply(ImagesConfig.TeamStartSizeWidthRate, true);
    var teamStartHeight = scaledBmp.Multiply(ImagesConfig.TeamStartSizeHeightRate, false);
    var teamStartElementPoint = scaledBmp.GetElementPoint(ImagesConfig.TeamStartSizeMarginLeftRate, ImagesConfig.TeamStartSizeMarginTopRate);
    var size5 = new Size(teamStartWidth, teamStartHeight);

    var path = $@".\Resource\Test\start_team.png";
    Rectangle elementRect = new Rectangle(teamStartElementPoint, size5);

    Bitmap sourceRegion = scaledBmp.Clone(elementRect, scaledBmp.PixelFormat);

    sourceRegion.Save(path, System.Drawing.Imaging.ImageFormat.Png);


  }
}
