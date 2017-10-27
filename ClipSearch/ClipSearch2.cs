using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

class ClipSearch2
{
    static string clipboardText = "";
    static string[] words;

    [STAThread]
    static void Main()
    {
        string urls;
        clipboardText = Clipboard.GetText();
        clipboardText = clipboardText.Trim();

        words = Regex.Split(clipboardText, @"\s+");
        for (int i = 0; i < words.Length; i++ ) {
            words[i] = "https://www.google.co.jp/search?q=" + words[i];
        }
        urls = string.Join(" ", words);

        Process.Start(@"chrome", urls);
//        Console.WriteLine( url );
//        Console.ReadLine();
    }
}
