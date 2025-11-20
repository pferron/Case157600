
using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using WOW.MyWoodmenIllustrationClient.Properties;

namespace WOW.MyWoodmenIllustrationClient.Model
{
    /// <summary>
    /// This class represents the data contained in a FIP file.
    /// </summary>
    internal class FipFile
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FipFile));

        /// <summary>
        /// Factory method for deserializing a FIP file content.
        /// </summary>
        /// <param name="content">The sections and name/value pairs containing the state of the FIP.</param>
        /// <returns>A populated FIP File object.</returns>
        internal static FipFile Deserialize(string content)
        {
            string newContent;
            newContent = string.Empty;
            if (content.Contains("\r\n"))
            {
                // contains carriage return line feed
                newContent = content;
            }
            else
            {
                newContent = content.Replace("\r", "\r\n");
            }
            if (newContent == null)
            {
                if (log.IsErrorEnabled) log.Error("LoadFromString - The passed content was null.");
                throw new ArgumentNullException("content", "Content cannot be null.");
            }

            var lines = newContent.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            if (log.IsDebugEnabled) log.DebugFormat(CultureInfo.InvariantCulture, "LoadFromString - Lines parsed: {0}", lines.Length);

            var fipFile = new FipFile();

            FipSection section = null;

            foreach (var line in lines)
            {
                var cleanLine = line.Trim();
                if (cleanLine.StartsWith("[", StringComparison.Ordinal))
                {
                    var name = cleanLine.Trim("[]".ToCharArray());
                    section = new FipSection(name);

                    fipFile.Sections.Add(section);
                }
                else
                {
                    // Only allow two parts to ensure we handle any embedded commas in the values.
                    var parts = new List<string>(cleanLine.Split(new string[] { "," }, 2, StringSplitOptions.None));

                    var tuple = new Tuple<string, string>(parts[0].Trim(), parts[1].Trim());
                    section.Items.Add(tuple);
                }
            }

            if (log.IsDebugEnabled) log.DebugFormat(CultureInfo.InvariantCulture, "LoadFromString - Sections parsed: {0}", fipFile.Sections.Count);

            return fipFile;
        }

        /// <summary>
        /// Hidden constructor used to initialize an object.
        /// </summary>
        private FipFile()
        {
            Sections = new List<FipSection>();
        }

        /// <summary>
        /// A list of zero or more FIP Sections.
        /// </summary>
        internal List<FipSection> Sections { get; private set; }

        /// <summary>
        /// Gets a serialized byte-array representation of this FIP file.
        /// </summary>
        /// <returns>An array of zero or more bytes.</returns>
        internal byte[] ToBytes()
        {
            var stringValue = ToString();
            return Encoding.UTF8.GetBytes(stringValue);
        }

        /// <summary>
        /// Gets a seralizied string representation of this FIP file.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var section in Sections)
            {
                sb.Append(section.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Updates the batch section with new output location.
        /// </summary>
        /// <param name="fileName">The name that should be used for the output file.</param>
        internal void UpdateOutputLocation(string fileName)
        {
            var batchSectionFound = false;

            if (log.IsDebugEnabled) log.DebugFormat(CultureInfo.InvariantCulture, "UpdateOutputLocation - FileName: {0}", fileName);
            if (fileName == null)
            {
                if (log.IsErrorEnabled) log.Error("UpdateOutputLocation - The passed file name was null.");
                throw new ArgumentNullException("fileName", "FileName cannot be null.");
            }

            foreach (var section in Sections)
            {
                if (section.Name.Equals(Settings.Default.BatchSectionMarker))
                {
                    //Clear out the old values and replace with the new.
                    section.Items.Clear();

                    var tuple = new Tuple<string, string>("output", "1");
                    section.Items.Add(tuple);

                    tuple = new Tuple<string, string>("outputName", fileName);
                    section.Items.Add(tuple);

                    tuple = new Tuple<string, string>("outputPath", Settings.Default.FipRequestFolder);
                    section.Items.Add(tuple);

                    tuple = new Tuple<string, string>("outputValues", "0"); //Changed from "1" because we don't need the values for this integration.
                    section.Items.Add(tuple);

                    tuple = new Tuple<string, string>("saveData", "0");
                    section.Items.Add(tuple);

                    batchSectionFound = true;
                    break;
                }
            }

            if (log.IsDebugEnabled) log.DebugFormat(CultureInfo.InvariantCulture, "UpdateOutputLocation - BatchSectionFound: {0}", batchSectionFound);
        }
    }
}
