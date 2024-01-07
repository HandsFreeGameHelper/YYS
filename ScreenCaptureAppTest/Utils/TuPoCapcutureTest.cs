using NUnit.Framework;
using ScreenCaptureApp.Utils;
using System.Drawing;
using static ScreenCaptureApp.Utils.Contains;

namespace ScreenCaptureAppTest.Utils;

internal class TuPoCapcutureTest
{
  [Test]
  public void Test1()
  {
    WindowsFilter.GetWindows();
    var targetHWnds = WindowsFilter.WindowHandles;
    ImageTools.RestImages(targetHWnds.First().GetBitmap(), TuPo.NOCHANCE, TuPo.NOCHANCE, false);
  }
  [Test]
  public void Test2() 
  {
    try
    {
      var bmp1 = new Bitmap($@"./Resource/tupo_untupo_yinyangliao1.png");
      var bmp2 = new Bitmap($@"./Resource/tupo_untupo_yinyangliao2.png");
      var bmp3 = new Bitmap($@"./Resource/tupo_untupo_geren1.png");
      var bmp4 = new Bitmap($@"./Resource/tupo_untupo_geren2.png");
      var bmp5 = new Bitmap($@"./Resource/tupo_untupo_geren3.png");
      var bmp6 = new Bitmap($@"./Resource/tupo_attack_yinyangliao1.png");
      var bmp7 = new Bitmap($@"./Resource/tupo_attack_yinyangliao2.png");
      var bmp8 = new Bitmap($@"./Resource/tupo_attack_geren1.png");
      var bmp9 = new Bitmap($@"./Resource/tupo_attack_geren2.png");
      var bmp10 = new Bitmap($@"./Resource/tupo_attack_geren3.png");
   
      var res1 =  ImageTools.AreBitmapsEqual(bmp1, bmp2);
      var res2 =  ImageTools.AreBitmapsEqual(bmp1, bmp3);
      var res3 =  ImageTools.AreBitmapsEqual(bmp2, bmp3);
      var res4 =  ImageTools.AreBitmapsEqual(bmp1, bmp4);
      var res5 =  ImageTools.AreBitmapsEqual(bmp2, bmp4);
      var res6 =  ImageTools.AreBitmapsEqual(bmp3, bmp4);
      var res7 =  ImageTools.AreBitmapsEqual(bmp1, bmp5);
      var res8 =  ImageTools.AreBitmapsEqual(bmp2, bmp5);
      var res9 =  ImageTools.AreBitmapsEqual(bmp3, bmp5);
      var res10 =  ImageTools.AreBitmapsEqual(bmp4, bmp5);
      var res11 =  ImageTools.AreBitmapsEqual(bmp6, bmp7);
      var res12 =  ImageTools.AreBitmapsEqual(bmp6, bmp8);
      var res13 =  ImageTools.AreBitmapsEqual(bmp7, bmp8);
      var res14 =  ImageTools.AreBitmapsEqual(bmp6, bmp9);
      var res15 =  ImageTools.AreBitmapsEqual(bmp7, bmp9);
      var res16 =  ImageTools.AreBitmapsEqual(bmp8, bmp9);
      var res17 =  ImageTools.AreBitmapsEqual(bmp6, bmp10);
      var res18 =  ImageTools.AreBitmapsEqual(bmp7, bmp10);
      var res19 =  ImageTools.AreBitmapsEqual(bmp8, bmp10);
      var res20 =  ImageTools.AreBitmapsEqual(bmp9, bmp10);
    }
    catch { }
  }
}
