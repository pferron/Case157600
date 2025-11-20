using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HubIllustrationServiceTest
{
    public class FipSimpleParser
    {
        static Regex reSec = new Regex(@"(\[([^\]]+)\])?([^\[]+)");
        static Regex reField = new Regex(@"([^\r\n]+)(\r\n)?");
        static Regex reKeyval = new Regex(@"([^,]+),([^\r\n]*)");
        static Regex reImoirtId = new Regex(@"");
        static Regex reMoney = new Regex(@"^\$?\d\d?\d?(,\d\d\d)*(\.\d+)?$");

        private Dictionary<string,List<string[]>> sections;
        public FipSimpleParser(string fip)
        {
            sections = Parse(fip);
        }

        string ValueOf(Dictionary<string, string> rider, string key)
        {
            if (rider.ContainsKey(key))
            {
                var ret = rider[key];
                decimal val;
                DateTime dt;
                if (decimal.TryParse(ret, out val))
                    return val.ToString();
                else
                    if (ret.StartsWith("$") && decimal.TryParse(ret.Substring(1), out val))
                    return val.ToString();
                else
                    if (DateTime.TryParse(ret, out dt))
                        return dt.ToShortDateString();
                    else
                        return ret;
            }
            else
                return "null";
        }
        private Dictionary<string, List<string[]>> Parse(string fiptext)
        {
            sections = new Dictionary<string, List<string[]>>(StringComparer.OrdinalIgnoreCase);
            var m = reSec.Match(fiptext);
            m = m.NextMatch();
            m = m.NextMatch();
            string section = null, sectiontext, name, value;
            while (m.Success)
            {
                section = m.Groups[2].Value;
                var list = new List<string[]>();
                sectiontext = m.Groups[3].Value;
                var m1 = reField.Match(sectiontext);
                while (m1.Success)
                {
                    var m2 = reKeyval.Match(m1.Groups[1].Value);
                    name = m2.Groups[1].Value;
                    value = m2.Groups[2].Value;
                    m1 = m1.NextMatch();
                    list.Add(new string[] { name.Trim(), value.Trim() });
                }
                if (list.Count > 0)
                    sections.Add(section, list);
                m = m.NextMatch();
            }
            return sections;
        }
        public Dictionary<string, string> MergeSections(List<string> listOfSections)
        {
            var section = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (string name in listOfSections)
                if (sections.ContainsKey(name))
                    foreach (var kv in sections[name])
                        section.Add(kv[0], kv[1]);
            return section;
        }
        public List<Dictionary<string, string>> SectionMultiples(string section)
        {
            var ret = new List<Dictionary<string, string>>();
            var rider = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            if (sections.ContainsKey(section))
            {
                foreach (var couple in sections[section])
                {
                    if (rider.ContainsKey(couple[0]))
                    {
                        ret.Add(rider);
                        rider = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    }
                    rider.Add(couple[0], couple[1]);
                }
                ret.Add(rider);
            }
            return ret;
        }

    }
}
