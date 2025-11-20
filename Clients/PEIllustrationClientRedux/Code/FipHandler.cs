using log4net;
using System;
using System.Collections.Generic;
using System.IO;

namespace WOW.PEIllustrationClient.Code
{
    internal static class FipHandler
    {
        private readonly static ILog logger = LogManager.GetLogger(typeof(FipHandler));

        internal static List<string> LoadFipRequests(string sourceFipFilePath)
        {
            if (String.IsNullOrEmpty(sourceFipFilePath))
            {
                if (logger.IsErrorEnabled) { logger.Error("LoadFipRequests: File path string cannot be null or empty."); }
                throw new ArgumentException("File path string cannot be null or empty.", "sourceFipFilePath");
            }

            if (!File.Exists(sourceFipFilePath))
            {
                if (logger.IsErrorEnabled) { logger.ErrorFormat("LoadFipRequests: File '{0}' not found.", sourceFipFilePath); }
                throw new FileNotFoundException("Source FIP file was not found.", sourceFipFilePath);
            }

            try
            {
                var fipStrings = new List<string>();

                string content = File.ReadAllText(sourceFipFilePath);

                // Check to see if there's multiple illustration requests in the file
                if (content.LastIndexOf("[Illustration]") > 0)
                {
                    // if so, pass file to split method
                    fipStrings.AddRange(SplitFipFile(content));
                }
                else
                {
                    fipStrings.Add(content);
                }

                return fipStrings;
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.Error(String.Format("An error occurred reading data from source file. File: {0}", sourceFipFilePath), ex); }
                throw;
            }
        }

        private static IEnumerable<string> SplitFipFile(string content)
        {
            if (String.IsNullOrEmpty(content))
            {
                if (logger.IsErrorEnabled) { logger.Error("SplitFipFile: FIP content cannot be null or empty."); }
                throw new ArgumentException("FIP content cannot be null or empty.", "content");
            }

            try
            {
                // List for extracted fip requests
                var fipList = new List<string>();

                // Split citeria
                string[] splitOn = new string[] { "[Illustration]", "[ILLUSTRATION]", "[illustration]" };

                // Split on [Illustration] node
                var fipRequests = content.Split(splitOn, StringSplitOptions.RemoveEmptyEntries);

                foreach (var fipRequest in fipRequests)
                {
                    // Re-append [Illustration] node and add to list
                    fipList.Add("[Illustration]" + fipRequest);
                }

                return fipList;
            }
            catch (Exception ex)
            {
                if (logger.IsErrorEnabled) { logger.Error(String.Format("An error occurred while splitting the FIP content string. Content: {0}", content), ex); }
                throw;
            }
        }
    }
}

