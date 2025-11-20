using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace PdfForm
{
    class Program
    {
        static private Regex re = new Regex(@"^\#([^_]*)(_+)$");
        static void Main(string[] args)
        {
            Aspose.Pdf.License license = new Aspose.Pdf.License();
            // Set license
            license.SetLicense("Aspose.Total.Product.Family 20181215.lic");
            Document pdfDocument = new Document(args[0]);

            // Create TextAbsorber object to find all the phrases matching the regular expression
            TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber(@"\#[^_]*_+"); // Like #4____________

            // Set text search option to specify regular expression usage
            TextSearchOptions textSearchOptions = new TextSearchOptions(true);
            textFragmentAbsorber.TextSearchOptions = textSearchOptions;

            // Accept the absorber for a single page
            pdfDocument.Pages[1].Accept(textFragmentAbsorber);

            var textFragmentCollection = textFragmentAbsorber.TextFragments.ToArray();
            int FragmentCompare(TextFragment elem1, TextFragment elem2)
            {
                if (elem1.BaselinePosition.YIndent > elem2.BaselinePosition.YIndent)
                    return -1;
                else
                    if (elem1.BaselinePosition.YIndent == elem2.BaselinePosition.YIndent)
                    {
                        if (elem1.Position.XIndent < elem2.Position.XIndent)
                            return -1;
                        else
                            if (elem1.Position.XIndent > elem2.Position.XIndent)
                            return 1;
                        else
                            return 0;
                    }
                else
                    return 1;
            }
            Array.Sort(textFragmentCollection, FragmentCompare);
            foreach(var textfragment in textFragmentCollection)
            {
                //Console.WriteLine(textfragment.Text);
                //textfragment.Text = FieldValue(textfragment.Text);
            }
            pdfDocument.Save(@"IULExampleFilled.pdf");
        }
        static string FieldValue(string mask)
        {
            int length = mask.Length;
            Match m;
            m = re.Match(mask);
            switch (m.Groups[1].Value)
            {
                case "1":
                    return "Matilde Setola";
                case "2":
                    return "7654321";
                case "3":
                    return "09/09/1950";
                case "4":
                    return "12/11/2018";
                case "01":
                    return "Female, 30 years old, smoker, Standard";
                case "02":
                    return "Option 1 - Include";
                case "5":
                    return "55,000";
                case "6":
                    return "86";
                case "7":
                    return "13/05/1990";
                case "8":
                    return "Paid Cash";
                case "11":
                    return "345.67";
                case "12":
                    return "1,234.56";
                case "13":
                    return "5,678.90";
                case "14":
                    return "35";
                default:
                    break;

            }
            return "";
        }
        static string PadRight(string val, int length)
        {
            string str = val;
            for (int x = val.Length; x < length; x++)
                str += " ";
            return str;
        }
    }
}
