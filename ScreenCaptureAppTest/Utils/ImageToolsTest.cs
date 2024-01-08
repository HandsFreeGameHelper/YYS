using NUnit.Framework;
using ScreenCaptureApp.Utils;
using System.Windows.Forms;

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
}
