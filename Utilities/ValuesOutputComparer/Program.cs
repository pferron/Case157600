using System;
using System.Windows.Forms;

namespace WOW.Illustration.Utilities.ValuesOutputComparer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            //var files = System.IO.Directory.GetFiles(@"D:\AppData\Illusfiles\Split Fip Files 2\", "*.orig");
            //foreach (var file in files)
            //{
            //    var oldFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(file), System.IO.Path.GetFileNameWithoutExtension(file));
            //    if (System.IO.File.Exists(oldFile))
            //    {
            //        System.IO.File.Delete(oldFile);
            //    }
            //    System.IO.File.Move(file, oldFile);
            //}


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
