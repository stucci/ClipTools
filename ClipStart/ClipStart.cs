using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

class ClipStart
{
    static string clipboardText = "";

    [STAThread]
    static void Main()
    {
        string target;
        clipboardText = Clipboard.GetText();
        clipboardText = clipboardText.Trim();

        // create Process object
        System.Diagnostics.Process p = new System.Diagnostics.Process();
        // get path of cmd.exe
        p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
        // not to display window
        p.StartInfo.CreateNoWindow = true;

        // set string
        target = Regex.Replace( clipboardText, "<|>", "" );
        if (!File.Exists(target) && !Directory.Exists(target)) {
            target = Regex.Match( target, @"^.*\\" ).Value;
        }
        target = "\"" + target+ "\"";
        // for debug
        // Console.WriteLine(target);
        p.StartInfo.Arguments = @"/c start """" " + target;
        p.Start();
        // Console.ReadLine();
    }
}
