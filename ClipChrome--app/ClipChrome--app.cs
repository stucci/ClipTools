using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

class ClipSearch
{
    static string clipboardText = "";

    [STAThread]
    static void Main()
    {
        string url;
        clipboardText = Clipboard.GetText();
        clipboardText = clipboardText.Trim();

        if (Regex.IsMatch(clipboardText, @"^https?://[-_.!~*'()a-zA-Z0-9;/?:@&=+$,%#]+$")) {
            url = "\"--app=" + clipboardText + "\"";
        } else {
            return;
        }
        Process.Start(@"chrome", url);
//        Console.WriteLine( url );
//        Console.ReadLine();
    }
}
