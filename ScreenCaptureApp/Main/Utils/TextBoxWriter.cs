using System.Text;

namespace ScreenCaptureApp.Utils;

public class TextBoxWriter : System.IO.TextWriter
{
  RichTextBox rtBox;
  delegate void VoidAction();

  public TextBoxWriter(RichTextBox box)
  {
    Control.CheckForIllegalCrossThreadCalls = false;
    rtBox = box;
  }
  public override void WriteLine(string? value)
  {
    VoidAction action = delegate
    {
      try
      {
        string[] strLines = rtBox.Text.Split('\n');
        if (strLines.Length > 1000)
        {
          rtBox.Clear();
        }
        if (!string.IsNullOrEmpty(value))
        {
          rtBox.AppendText(string.Format("\r\n[{0:HH:mm:ss}]{1}\r\n", DateTime.Now, value));
          rtBox.ForeColor = Color.FromArgb(51, 255, 102);
        }
      }
      catch { }
    };
    if (rtBox.IsHandleCreated)
    {
      try
      {
        rtBox.BeginInvoke(action);
      }
      catch { }
    }

  }
  public override Encoding Encoding
  {
    get { return System.Text.Encoding.UTF8; }
  }

}
