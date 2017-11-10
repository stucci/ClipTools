using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

class ClipStart
{
    static string clipboardText = "";

    [STAThread]
    static void Main()
    {
        string str;
        clipboardText = Clipboard.GetText();
        clipboardText = clipboardText.Trim();

        // create Process object
        System.Diagnostics.Process p = new System.Diagnostics.Process();

        // get path of cmd.exe
        p.StartInfo.FileName = System.Environment.GetEnvironmentVariable("ComSpec");
        // enable to read outpu
        // p.StartInfo.UseShellExecute = false;
        // p.StartInfo.RedirectStandardOutput = true;
        // p.StartInfo.RedirectStandardInput = false;
        // not to display window
        p.StartInfo.CreateNoWindow = true;
        // set arguments
        str = "\"" + clipboardText + "\"";
        p.StartInfo.Arguments = @"/c start """" " + str;
        // start
        p.Start();

        // Console.WriteLine(p.StartInfo.Arguments);
        // Console.ReadLine();
    }
}
