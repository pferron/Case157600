using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace WOW.MyWoodmenIllustrationClient.Model
{
    /// <summary>
    /// This class represents a section of the FIP file.
    /// </summary>
    internal class FipSection
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FipSection));

        /// <summary>
        /// Creates an instance of this class using the specified section name.
        /// </summary>
        /// <param name="name">The name to use for this section.</param>
        internal FipSection(string name)
        {
            if (name == null)
            {
                if (log.IsErrorEnabled) log.Error("FipSection(constructor) - The passed section name was null.");
                throw new ArgumentNullException("name", "Section Name cannot be null.");
            }

            Name = name;
            Items = new List<Tuple<string, string>>();
        }

        /// <summary>
        /// The name of the section.
        /// </summary>
        internal string Name { get; private set; }

        /// <summary>
        /// This list of name/value pairs that represent the section of the FIP.
        /// </summary>
        internal List<Tuple<string, string>> Items { get; private set; }

        /// <summary>
        /// Gets a string representation of this section.
        /// </summary>
        /// <returns>The serialized state of the section.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("[");
            sb.Append(Name);
            sb.AppendLine("]");

            foreach (var tuple in Items)
            {
                sb.Append(tuple.Item1);
                sb.Append(", ");
                sb.AppendLine(tuple.Item2);
            }
            return sb.ToString();
        }
    }
}
