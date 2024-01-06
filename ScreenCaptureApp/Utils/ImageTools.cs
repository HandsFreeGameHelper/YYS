using static ScreenCaptureApp.Utils.Contains;

namespace ScreenCaptureApp.Utils;

public static class ImageTools
{
  public static int BoxCount = -1;
  public static bool IsElementPresent(Bitmap sourceImage, Bitmap elementImage, Point position, bool isTupo = false)
  {
    if (position.X < 0 || position.Y < 0 || position.X + elementImage.Width > sourceImage.Width || position.Y + elementImage.Height > sourceImage.Height)
    {
      return false;
    }

    Rectangle elementRect = new Rectangle(position, elementImage.Size);
    Bitmap sourceRegion = sourceImage.Clone(elementRect, sourceImage.PixelFormat);

    //sourceRegion.Save($@"./Test/sourceRegion_{position.X}_{position.Y}.png", System.Drawing.Imaging.ImageFormat.Png);
    if (AreBitmapsEqual(sourceRegion, elementImage, isTupo))
    {
      //sourceRegion.Save("sourceRegion.png", System.Drawing.Imaging.ImageFormat.Png);
      return true;
    }
    return false;
  }

  public static bool AreBitmapsEqual(Bitmap bmp1, Bitmap bmp2,bool isTupo = false)
  {
    if (bmp1.Size != bmp2.Size)
    {
      return false;
    }
    var rate = isTupo ? 0.1 : 0.3;
    for (int i = 0; i < bmp1.Width; i++)
    {
      for (int j = 0; j < bmp1.Height; j++)
      {
        if (!AreColorsWithinThreshold(bmp1.GetPixel(i, j), bmp2.GetPixel(i, j), rate))
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

  public static bool RestImages(this Bitmap sourceImage, string? restType, string? restModel, bool isTeam)
  {
    try
    {
      if (!EMPTY.Equals(restType) && !EMPTY.Equals(restModel))
      {
        var size =
          ImagesConfig.START.Equals(restModel) ?
            isTeam ?
            new Size((int)(sourceImage.Width * ImagesConfig.StartXSizeRateTeam), (int)(sourceImage.Height * ImagesConfig.StartYSizeRate)) :
            new Size((int)(sourceImage.Width * ImagesConfig.StartXSizeRate), (int)(sourceImage.Height * ImagesConfig.StartYSizeRate)) :
          TuPo.TUPO.Equals(restModel) ?
          new Size((int)(sourceImage.Width * TuPo.TuPoPanelSizeWidthRate), (int)(sourceImage.Height * TuPo.TuPoPanelSizeHeightRate)) :
          TuPo.GEREN.Equals(restModel) || TuPo.YINYANGLIAO.Equals(restModel) ?
          new Size((int)(sourceImage.Width * TuPo.TuPoSectionSizeWidthRate), (int)(sourceImage.Height * TuPo.TuPoSectionSizeHeightRate)) :
          TuPo.ATTACK.Equals(restModel) ?
          new Size((int)(sourceImage.Width * TuPo.AttackSizeWidthRate), (int)(sourceImage.Height * TuPo.AttackSizeHeightRate)) :
          TuPo.REFRESH.Equals(restModel) ?
          new Size((int)(sourceImage.Width * TuPo.RefreshSizeWidthRate), (int)(sourceImage.Height * TuPo.RefreshSizeHeightRate)) :
          ImagesConfig.SHIBAI.Equals(restModel) ?
          new Size((int)(sourceImage.Width * ImagesConfig.SHIBAISizeWidthRate), (int)(sourceImage.Height * ImagesConfig.SHIBAISizeHeightRate)) :
          new Size((int)(sourceImage.Width * ImagesConfig.EndXSizeRate), (int)(sourceImage.Height * ImagesConfig.EndYSizeRate));
        Point position =
          ImagesConfig.START.Equals(restModel) ?
            isTeam ?
            new Point((int)(sourceImage.Width * ImagesConfig.StartXRateTeam), (int)(sourceImage.Height * ImagesConfig.StartYRateTeam)) :
            new Point((int)(sourceImage.Width * ImagesConfig.StartXRate), (int)(sourceImage.Height * ImagesConfig.StartYRate)) :
          TuPo.TUPO.Equals(restModel) ?
          new Point((int)(sourceImage.Width * TuPo.TuPoPanelMarginLeftYinYangLiao1Rate), (int)(sourceImage.Height * TuPo.TuPoPanelMarginTopYinYangLiaoRate)) :
          TuPo.GEREN.Equals(restModel) ?
          new Point((int)(sourceImage.Width * TuPo.TuPoSectionMarginLeftRate), (int)(sourceImage.Height * TuPo.TuPoGeRenMarginTopRate)) :
          TuPo.YINYANGLIAO.Equals(restModel) ?
          new Point((int)(sourceImage.Width * TuPo.TuPoSectionMarginLeftRate), (int)(sourceImage.Height * TuPo.TuPoYinYangLiaoMarginTopRate)) :
          TuPo.ATTACK.Equals(restModel) ?
          new Point((int)(sourceImage.Width * TuPo.AttackMarginLeftGeRenRate3), (int)(sourceImage.Height * TuPo.AttackMarginTopGeRenRate)) :
          TuPo.REFRESH.Equals(restModel) ?
          new Point((int)(sourceImage.Width * TuPo.RefreshMarginLeftRate), (int)(sourceImage.Height * TuPo.RefreshMarginTopRate)) :
          ImagesConfig.SHIBAI.Equals(restModel) ?
          new Point((int)(sourceImage.Width * ImagesConfig.SHIBAISizeMarginLeftRate), (int)(sourceImage.Height * ImagesConfig.SHIBAISizeMarginTopRate)) :
          new Point((int)(sourceImage.Width * ImagesConfig.EndXRate), (int)(sourceImage.Height * ImagesConfig.EndYRate));
        Rectangle elementRect = new Rectangle(position, size);
        Bitmap sourceRegion = sourceImage.Clone(elementRect, sourceImage.PixelFormat);
        var type =
          ImagesConfig.YUHUN.Equals(restType) ? EnergyValue.YUHUN :
          ImagesConfig.JUEXIN.Equals(restType) ? EnergyValue.JUEXING :
          ImagesConfig.YULIN.Equals(restType) ? EnergyValue.YULIN :
          TuPo.GEREN_SELECTED.Equals(restType) ? TuPo.GEREN_SELECTED_TYPE :
          TuPo.GEREN_UNSELECTED.Equals(restType) ? TuPo.GEREN_UNSELECTED_TYPE :
          TuPo.YINYANGLIAO_SELECTED.Equals(restType) ? TuPo.YINYANGLIAO_SELECTED_TYPE :
          TuPo.YINYANGLIAO_UNSELECTED.Equals(restType) ? TuPo.YINYANGLIAO_UNSELECTED_TYPE :
          TuPo.UNTUPO.Equals(restType) ? TuPo.UNTUPO_TYPE :
          TuPo.TUPOED.Equals(restType) ? TuPo.TUPOED_TYPE :
          TuPo.TUPOFAILED.Equals(restType) ? TuPo.TUPOFAILED_TYPE :
          TuPo.ATTACK.Equals(restType) ? TuPo.ATTACK_TYPE :
          TuPo.REFRESH.Equals(restType) ? TuPo.REFRESH_TYPE :
          EMPTY;
        var team = isTeam ? "_team" : "";
        var path =
          ImagesConfig.END.Equals(restModel) ? $@"./Resource/End/end.png" :
          ImagesConfig.SHIBAI.Equals(restModel) ? $@"./Resource/End/failed.png" :
          ImagesConfig.START.Equals(restModel) ? $@"./Resource/Start/start_{type}{team}.png" :
        $@"./Resource/tupo_{type}.png";

        sourceRegion.Save(path, System.Drawing.Imaging.ImageFormat.Png);

        if (TuPo.GEREN_SELECTED.Equals(restType))
        {
          return  RestImages(sourceImage, TuPo.YINYANGLIAO_UNSELECTED, TuPo.YINYANGLIAO, false);
        }
        else if (TuPo.YINYANGLIAO_SELECTED.Equals(restType))
        {
          return  RestImages(sourceImage, TuPo.GEREN_UNSELECTED, TuPo.GEREN, false);
        }
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

  public static PictureBox Next(this List<PictureBox> pictureBoxes)
  {
    var pictureBoxesCount = pictureBoxes.Count;
    BoxCount += 1;
    if (BoxCount + 1 > pictureBoxesCount)
    {
      throw new ArgumentOutOfRangeException();
    }
    return pictureBoxes[BoxCount];
  }

  public static Bitmap GetBitmap(this IntPtr intPtr)
  {
    SystemRuntimes.RECT windowRect;
    SystemRuntimes.GetWindowRect(intPtr, out windowRect);

    var widthAndHeight = windowRect.GetWidthAndHeight();
    IntPtr hdcWindow = SystemRuntimes.GetDC(intPtr);
    IntPtr hdcMemDC = WindowsRuntimes.CreateCompatibleDC(hdcWindow);
    IntPtr hBitmap = WindowsRuntimes.CreateCompatibleBitmap(hdcWindow, widthAndHeight.Item1, widthAndHeight.Item2);
    IntPtr hOld = WindowsRuntimes.SelectObject(hdcMemDC, hBitmap);

    WindowsRuntimes.BitBlt(hdcMemDC, 0, 0, widthAndHeight.Item1, widthAndHeight.Item2, hdcWindow, 0, 0, 13369376); // 13369376 is SRCCOPY constant

    Bitmap bmp = Bitmap.FromHbitmap(hBitmap);
    WindowsRuntimes.SelectObject(hdcMemDC, hOld);
    WindowsRuntimes.DeleteObject(hBitmap);
    WindowsRuntimes.DeleteDC(hdcMemDC);
    SystemRuntimes.ReleaseDC(intPtr, hdcWindow);
    return bmp;

  }
}
