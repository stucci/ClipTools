using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

class ClipTrans {
    static string clipboardText = "";

    [STAThread] static void Main() {
        string query;

        clipboardText = Clipboard.GetText();
        clipboardText = clipboardText.Trim();
        clipboardText = Regex.Replace(clipboardText, "\\s+", "%20");

        if (Regex.IsMatch(clipboardText, @"\w{3}")) {
            query = "hl=en#auto/ja/";
        } else {
            query = "hl=ja#auto/en/";
        }
        string url = "https://translate.google.co.jp/?" + query + clipboardText;
        Process.Start(@"chrome", url);
        //        Console.WriteLine( url );
        //        Console.ReadLine();
    }
}
