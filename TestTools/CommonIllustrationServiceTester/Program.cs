using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonIllustrationServiceTester
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Activate embedded license

            var path = Path.Combine(Application.StartupPath, "Aspose.lic");

            Aspose.Pdf.License pdfLicense = new Aspose.Pdf.License();
            pdfLicense.Embedded = false;
            pdfLicense.SetLicense(path);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CISTestForm());
        }
    }
}
