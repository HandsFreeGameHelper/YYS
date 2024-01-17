using System.Diagnostics.CodeAnalysis;

namespace ScreenCaptureApp.Utils;

public static class Guard
{
  [return: NotNull]
  public static T GetNotNull<T>(T? value, string propertyName)
  {
    if (value == null)
    {
      throw new InvalidOperationException(propertyName);
    }

    return value;
  }
}
