using ScreenCaptureApp.Main.Utils;

namespace ScreenCaptureApp.Utils;

public static class ReflectionTools
{
  public static List<T> SetStaticValues<T>(this List<T> ls, Type type)
  {
    type.GetFields().ToList()
    .ForEach(x =>
    {
      var attributes = x.GetCustomAttributes(typeof(SetStaticValueIgnoreAttribute), false).ToList();
      if (attributes.Any())
      {
        return;
      }
      var pro = type.GetField(x.Name)?.GetValue(null);
      if (pro != null)
      {
        ls.Add((T)pro);
      }
    });
    return ls;
  }
}
