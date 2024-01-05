using System.Text;

namespace ScreenCaptureApp.Utils;

public static class WindowsFilter
{
  public static List<IntPtr> WindowHandles = new List<IntPtr>();

  public static void GetWindows()
  {
    SystemRuntimes.EnumWindows(EnumWindowsCallback, IntPtr.Zero);
  }

  private static bool EnumWindowsCallback(IntPtr hWnd, IntPtr lParam)
  {
    string targetWindowTitle = "阴阳师-网易游戏"; 

    if (GetWindowTitleByHandle(hWnd) == targetWindowTitle)
    {
      WindowHandles.Add(hWnd);
    }
    return true;
  }

  private static string GetWindowTitleByHandle(IntPtr hWnd)
  {
    const int nChars = 256;
    StringBuilder title = new StringBuilder(nChars);
    if (SystemRuntimes.GetWindowText(hWnd, title, nChars) > 0)
    {
      return title.ToString();
    }
    return string.Empty;
  }
}
