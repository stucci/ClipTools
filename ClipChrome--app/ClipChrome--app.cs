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
            // || Regex.IsMatch(clipboardText, @"^\\")) {
            url = "\"--app=" + clipboardText + "\"";
        } else {
            // clipboardText = Regex.Replace( clipboardText, "\\s+", "+" );
            // url = "https://www.google.co.jp/search?q=" + clipboardText;
            return;
        }
        Process.Start(@"chrome", url);
        // Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", url);
//        Console.WriteLine( url );
//        Console.ReadLine();
    }
}
