using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.IO;

namespace MyWoodmenIllustrationClient.Tests
{
    internal static class SharedUtilities
    {
        public const int FipSample1ProcessedStringLength = 3630;
        public const int FipSample1ProcessedByteLenth = FipSample1ProcessedStringLength * 2;

        private static PrivateObject AppDefaultSettings;

        private static PrivateObject GetDefaultSettings()
        {
            if (AppDefaultSettings == null)
            {
                var AppDefaultSettingsType = new PrivateType("MyWoodmenIllustrationClient", "WOW.MyWoodmenIllustrationClient.Properties.Settings");
                var args = new object[] { };
                AppDefaultSettings = new PrivateObject(AppDefaultSettingsType.GetStaticProperty("Default", args));
            }
            return AppDefaultSettings;
        }

        internal static string GetBadDB2Connection()
        {
            return GetDefaultDB2Connection() + "ZZZ";
        }

        internal static string GetDefaultDB2Connection()
        {
            object[] args = null;
            return (string)GetDefaultSettings().GetProperty("DB2Connection", args);
        }

        internal static string GetFipSample1()
        {
            var file = @"..\..\TestFiles\Sample1.fip";
            return File.ReadAllText(file);
        }

        internal static string GetPdfSample1()
        {
            var file = @"..\..\TestFiles\Sample1.pdf";
            var byteContent = File.ReadAllBytes(file);
            return Convert.ToBase64String(byteContent);
        }

        internal static byte[] GetPdfSample2()
        {
            var file = @"..\..\TestFiles\Sample1.pdf";
            var byteContent = File.ReadAllBytes(file);
            return byteContent;
        }

        internal static string GetCurrentDB2Timestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd-HH.mm.ss.ffffff", CultureInfo.InvariantCulture);
        }
    }
}
