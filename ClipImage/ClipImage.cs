using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;

class ClipImage
{
    [STAThread]
    static void Main()
    {
        //Alt + PrtScn
        //SendKeys.SendWait("%{PRTSC}");
        //Get data
        IDataObject data = Clipboard.GetDataObject();
        //Check
        if (data.GetDataPresent(DataFormats.Bitmap)) {
            Bitmap bmp = (Bitmap)data.GetData(DataFormats.Bitmap);
            //Date
            DateTime now = DateTime.Now;
            string name = now.ToString("yyyyMMdd-HHmmss");
            string picturesPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            //Save as *.png
            bmp.Save(picturesPath + @"\" + name + ".png", ImageFormat.Png);
            //End
            bmp.Dispose();
        }
        // Console.WriteLine();
        // Console.ReadLine();
    }
}
