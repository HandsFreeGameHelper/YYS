using static ScreenCaptureApp.Utils.Contains;
using static ScreenCaptureApp.Utils.SystemRuntimes;

namespace ScreenCaptureApp.Utils;

public static class ImageTools
{
  public static bool IsElementPresent(Bitmap sourceImage, Bitmap elementImage, Point position)
  {
    if (position.X < 0 || position.Y < 0 || position.X + elementImage.Width > sourceImage.Width || position.Y + elementImage.Height > sourceImage.Height)
    {
      return false;
    }

    Rectangle elementRect = new Rectangle(position, elementImage.Size);
    Bitmap sourceRegion = sourceImage.Clone(elementRect, sourceImage.PixelFormat);

    if (AreBitmapsEqual(sourceRegion, elementImage))
    {
      return true;
    }

    return false;
  }

  private static bool AreBitmapsEqual(Bitmap bmp1, Bitmap bmp2)
  {
    if (bmp1.Size != bmp2.Size)
    {
      return false;
    }

    for (int i = 0; i < bmp1.Width; i++)
    {
      for (int j = 0; j < bmp1.Height; j++)
      {
        if (!AreColorsWithinThreshold(bmp1.GetPixel(i, j), bmp2.GetPixel(i, j), 0.34))
        {
          return false;
        }
      }
    }

    return true;
  }
  private static bool AreColorsWithinThreshold(Color color1, Color color2, double threshold)
  {
    // 计算每个颜色分量的差异
    int deltaR = Math.Abs(color1.R - color2.R);
    int deltaG = Math.Abs(color1.G - color2.G);
    int deltaB = Math.Abs(color1.B - color2.B);

    // 计算总体颜色差异
    double totalDifference = (deltaR + deltaG + deltaB) / 3.0 / 255.0;

    // 判断是否在阈值范围内
    return totalDifference <= threshold;
  }

  public static Image? ReMoveImage(this Image? image)
  {
    if (image != null)
    {
      image.Dispose();
    }
    return null;
  }

  public static bool RestImages(this Bitmap sourceImage, string? restType, string? restModel)
  {
    try
    {
      if (!EMPTY.Equals(restType) && !EMPTY.Equals(restModel))
      {
        var size = ImagesConfig.START.Equals(restModel) ? new Size(ImagesConfig.RegionStartXSize, ImagesConfig.RegionStartYSize) : new Size(ImagesConfig.RegionEndXSize, ImagesConfig.RegionEndYSize);
        Point position = ImagesConfig.START.Equals(restModel) ? new Point(ImagesConfig.RegionStartX, ImagesConfig.RegionStartY) : new Point(ImagesConfig.RegionEndX, ImagesConfig.RegionEndY);
        Rectangle elementRect = new Rectangle(position, size);
        Bitmap sourceRegion = sourceImage.Clone(elementRect, sourceImage.PixelFormat);
        var type =
          ImagesConfig.YUHUN.Equals(restType) ? EnergyValue.YUHUN :
          ImagesConfig.JUEXIN.Equals(restType) ? EnergyValue.JUEXING :
          ImagesConfig.YULIN.Equals(restType) ? EnergyValue.YULIN :
          EMPTY;
        var path =
          ImagesConfig.END.Equals(restModel) ? $@"./Resource/end.png" :
          $@"./Resource/start_{type}.png";
        sourceRegion.Save(path, System.Drawing.Imaging.ImageFormat.Png);
        return true;
      }
      else
      {
        return false;
      }
    }
    catch
    {
      return false;
    }
  }
}
