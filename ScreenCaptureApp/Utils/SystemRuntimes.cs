using System.Runtime.InteropServices;
using System.Text;

namespace ScreenCaptureApp.Utils;

public static class SystemRuntimes
{
  //移动鼠标 
  public static int MOUSEEVENTF_MOVE = 0x0001;
  //模拟鼠标左键按下 
  public static int MOUSEEVENTF_LEFTDOWN = 0x0002;
  //模拟鼠标左键抬起 
  public static int MOUSEEVENTF_LEFTUP = 0x0004;
  //模拟鼠标右键按下 
  public static int MOUSEEVENTF_RIGHTDOWN = 0x0008;
  //模拟鼠标右键抬起 
  public static int MOUSEEVENTF_RIGHTUP = 0x0010;
  //模拟鼠标中键按下 
  public static int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
  //模拟鼠标中键抬起 
  public static int MOUSEEVENTF_MIDDLEUP = 0x0040;
  //标示是否采用绝对坐标 
  public static int MOUSEEVENTF_ABSOLUTE = 0x8000;
  //模拟鼠标中间滚动
  public static int MOUSEEVENTF_WHEEL = 0x0800;
  //模拟按键按下
  public static int KEYEVENTF_KEYDOWN = 0;
  //模拟按键弹起
  public static int KEYEVENTF_KEYUP = 2;

  [StructLayout(LayoutKind.Sequential)]
  public struct RECT
  {
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
  }

  [DllImport("user32.dll")]
  [return: MarshalAs(UnmanagedType.Bool)]
  public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

  public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

  [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
  public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

  [DllImport("user32.dll")]
  public static extern IntPtr GetDC(IntPtr hwnd);
  [DllImport("user32.dll")]
  public static extern int ReleaseDC(IntPtr hwnd, IntPtr dc);
  [DllImport("user32.dll")]
  public static extern IntPtr FindWindow(string? lpClassName, string lpWindowName);
  [DllImport("user32.dll")]
  [return: MarshalAs(UnmanagedType.Bool)]
  public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

  [DllImport("User32.dll", CharSet = CharSet.Auto)]
  public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
  #region MouseKeyBoardEvent
  [DllImport("user32")]
  public static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
  [DllImport("user32.dll")]
  public static extern bool SetCursorPos(int X, int Y);
  [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
  public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
  [DllImport("kernel32.dll")]
  public static extern int GlobalAlloc(int wFlags, int dwBytes);
  [DllImport("kernel32.dll")]
  public static extern int GlobalLock(int hMem);
  [DllImport("kernel32.dll")]
  public static extern int RtlMoveMemory(int muBiaoAdd, string scoreData, int size);
  [DllImport("kernel32.dll")]
  public static extern int GlobalUnlock(int hMem);
  [DllImport("user32")]
  public static extern int EmptyClipboard();
  [DllImport("user32")]
  public static extern int OpenClipboard(int jianJiIntPrt);
  [DllImport("user32")]
  public static extern int SetClipboardData(int wFormat, int hMem);
  [DllImport("user32")]
  public static extern int CloseClipboard();
  #endregion
}
