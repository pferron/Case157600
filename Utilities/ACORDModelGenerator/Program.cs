using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WOW.Illustration.Utilities.ACORDModelGenerator
{
    class Program
    {

        /// SQL Script to generate the enum values
        /// 
        /// SELECT '        /// <summary>' + [Text] + '</summary>' + CHAR(13) + CHAR(10)
        ///  + CASE WHEN [Definition] > '' THEN '        /// <remarks>' + [Definition] + '</remarks>' + CHAR(13) + CHAR(10) ELSE '' END
        ///  + '        [XmlEnumAttribute("' + cast(Tc as varchar(20)) + '")]' + CHAR(13) + CHAR(10)
        ///  + '        ' + Code + ' = ' + cast(Tc as varchar(20)) + ',' + CHAR(13) + CHAR(10) + CHAR(13) + CHAR(10)
        ///     as Test
        /// FROM [LifeSuiteWow].[dbo].[AcordLookup]
        /// where AcordLookupTypeId = (SELECT AcordLookupTypeId FROM [LifeSuiteWow].[dbo].[AcordLookupType]
        ///     where Code like 'TRANS_SUBTYPE_CODES%')
        /// order by tc



        private const string ProjectPath = @"..\..\..\WOW.Illustration.Model\";
        private const string OriginalInputFile = @"C:\Temp\ACORD Message Model\Model\B2BOneViewAWD_B2BOneViewTXLife_FormXMLSchema.cs";
        //private const string OriginalInputFile = @"C:\Temp\ACORD Message Model\Model\Test.cs";

        static void Main()
        {
            // Safety measure to prevent this code from being accidentally executed.
            if (DateTime.Now > new DateTime(2014, 8, 1)) return;

            ExecuteXsd();

            var input = File.ReadAllText(OriginalInputFile) + "\r\n";

            CreateClassList(input);

            input = MakeAutomaticallyImplementedProperties(input);

            input = RemoveFields(input);

            input = SetUpForUsings(input);

            input = MoveOpeningBrace(input);

            input = FixXsdErrors(input);

            File.WriteAllText(@"C:\Temp\ACORD Message Model\Model\Inter.cs", input);
            BurstClasses(input);

        }

        private static string FixXsdErrors(string input)
        {
            input = input.Replace("DistributionChannelInfo_Type[][] CarrierAppointment", "DistributionChannelInfo_Type[] CarrierAppointment");
            input = input.Replace("Payment_Type[][] FinancialActivity", "Payment_Type[] FinancialActivity");
            input = input.Replace("Expression[][] ValidValue", "Expression[] ValidValue");
            input = input.Replace("object[][] pages", "object[] pages"); //updates in two places
            return input;
        }

        private static void ExecuteXsd()
        {
            //C:\Temp\ACORD Message Model>xsd.exe B2BOneViewAWD.xsd B2BOneViewTXLife.xsd FormXMLSchema.xsd /classes /nologo /order /out:"C:\Temp\ACORD Message Model\Model"
        }

        private static void BurstClasses(string input)
        {
            string LPESBaseNamespace = "XmlTypeAttribute\\((\\w+=\"?\\w+\"?, )*Namespace=\"http://www.fiservinsurance.com/LPES/Base/OneView";
            string LPESFormNamespace = "XmlTypeAttribute\\((\\w+=\"?\\w+\"?, )*Namespace=\"http://www.fiservinsurance.com/LPES/Form";
            string ACORDNamespace = "XmlTypeAttribute\\((\\w+=\"?\\w+\"?, )*Namespace=\"http://ACORD.org/Standards/Life/2";
            string ACORDFolder = @"ACORD";
            string LPESBaseFolder = @"LPES\Base";
            string LPESFormFolder = @"LPES\Form";

            string ClassTextPattern = @"/// <remarks/>\r\n(.*\r\n){3,7}{(?>[^{}]+|{(?<DEPTH>)|}(?<-DEPTH>))*(?(DEPTH)(?!))}\r\n";
            string ClassNamePattern = @"(?:public partial class )(\w*)(?:\r\n)|(?:public enum )(\w*)(?:\r\n)";

            string ACORDClassHeader = "using System;\r\nusing System.CodeDom.Compiler;\r\nusing System.ComponentModel;\r\nusing System.Diagnostics;\r\nusing System.Xml.Schema;\r\nusing System.Xml.Serialization;\r\n\r\nnamespace WOW.Illustration.Model.ACORD\r\n{\r\n";
            string LPESBaseClassHeader = "using WOW.Illustration.Model.ACORD;\r\nusing System;\r\nusing System.CodeDom.Compiler;\r\nusing System.ComponentModel;\r\nusing System.Diagnostics;\r\nusing System.Xml.Schema;\r\nusing System.Xml.Serialization;\r\n\r\nnamespace WOW.Illustration.Model.LPES.Base\r\n{\r\n";
            string LPESFormClassHeader = "using WOW.Illustration.Model.ACORD;\r\nusing System;\r\nusing System.CodeDom.Compiler;\r\nusing System.ComponentModel;\r\nusing System.Diagnostics;\r\nusing System.Xml.Schema;\r\nusing System.Xml.Serialization;\r\n\r\nnamespace WOW.Illustration.Model.LPES.Form\r\n{\r\n";
            string ClassFooter = "}\r\n";

            var path = Path.Combine(ProjectPath, ACORDFolder);
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);

            path = Path.Combine(ProjectPath, LPESBaseFolder);
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);

            path = Path.Combine(ProjectPath, LPESFormFolder);
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);

            var classTextRegEx = new Regex(ClassTextPattern);
            var matches = classTextRegEx.Matches(input);

            var classNameRegEx = new Regex(ClassNamePattern);
            foreach (Match match in matches)
            {
                var classText = match.Value;
                var classNameMatch = classNameRegEx.Match(classText);
                var className = classNameMatch.Groups[1].Value;
                if (className.Length == 0)
                {
                    className = classNameMatch.Groups[2].Value;
                }

                var regExLPESBase = new Regex(LPESBaseNamespace);
                var regExLPESForm = new Regex(LPESFormNamespace);
                var regExACORD = new Regex(ACORDNamespace);

                if (regExLPESBase.IsMatch(classText))
                {
                    //Check LPES first, in case it also contains a reference to ACORD.
                    path = Path.Combine(ProjectPath, LPESBaseFolder, className + ".cs");
                    classText = LPESBaseClassHeader + classText + ClassFooter;
                }
                else if (regExLPESForm.IsMatch(classText))
                {
                    //Check LPES first, in case it also contains a reference to ACORD.
                    path = Path.Combine(ProjectPath, LPESFormFolder, className + ".cs");
                    classText = LPESFormClassHeader + classText + ClassFooter;
                }
                else if (regExACORD.IsMatch(classText))
                {
                    path = Path.Combine(ProjectPath, ACORDFolder, className + ".cs");
                    classText = ACORDClassHeader + classText + ClassFooter;
                }
                else
                {
                    // Unknown namespace, just save it in the base directory.
                    path = Path.Combine(ProjectPath, className + ".cs");
                    classText = ACORDClassHeader + classText + ClassFooter;
                }

                File.WriteAllText(path, classText);
            }
        }

        private static void CreateClassList(string input)
        {
            var regEx = new Regex("public (partial class|enum).*");
            MatchCollection matches = regEx.Matches(input);
            var list = new List<string>();

            foreach (var match in matches)
            {
                list.Add(match.ToString());
            }
            list.Sort();
            File.WriteAllText(@"C:\Temp\ACORD Message Model\Model\ClassList.txt", string.Join("\n", list.ToArray()));
        }

        private static string MakeAutomaticallyImplementedProperties(string input)
        {
            string pattern = @" {\r\n\s*get {\r\n\s*return this.\w+;\r\n\s*}\r\n\s*set {\r\n\s*this.\w+ = value;\r\n\s*}\r\n\s*}";
            string replacement = @" { get; set; }";

            var output = ReplaceString(input, pattern, replacement);

            return output;
        }

        private static string MoveOpeningBrace(string input)
        {
            string pattern = @" {\r\n\s*\r\n";
            string replacement = "\r\n{\r\n";

            var output = ReplaceString(input, pattern, replacement);

            pattern = @" {\r\n}\r\n";
            replacement = "\r\n{\r\n}\r\n";
            output = ReplaceString(output, pattern, replacement);

            return output;
        }

        private static string RemoveFields(string input)
        {
            string pattern = @"    \r\n    private \w+(\.\w+)*(\[\])* \w+;\r\n";
            string replacement = string.Empty;

            var output = ReplaceString(input, pattern, replacement);

            return output;
        }

        private static string SetUpForUsings(string input)
        {
            string pattern = @"\[System.CodeDom.Compiler.";
            string replacement = @"[";

            var output = ReplaceString(input, pattern, replacement);

            pattern = @"\[System.Xml.Serialization.";
            replacement = @"[";

            output = ReplaceString(output, pattern, replacement);

            pattern = @"\[System.ComponentModel.";
            replacement = @"[";

            output = ReplaceString(output, pattern, replacement);

            pattern = @"\[System.Diagnostics.";
            replacement = @"[";

            output = ReplaceString(output, pattern, replacement);

            // Perform last to ensure it's not picked up prematurely above.
            pattern = @"\[System.";
            replacement = @"[";

            output = ReplaceString(output, pattern, replacement);

            return output;
        }

        private static string ReplaceString(string input, string pattern, string replacement)
        {
            var regEx = new Regex(pattern);

            var output = regEx.Replace(input, replacement);

            return output;
        }
    }
}
