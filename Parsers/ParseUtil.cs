using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UnityDPtools
{
    public static class ParseUtil
    {
        public static List<string> GetPropertyTable<T>(T[] table)
        {
            var lines = new List<string>(table.Length + 1);
            var properties = table[0].GetType().GetProperties();

            // make header
            {
                var sb = new StringBuilder();
                foreach (var p in properties)
                    sb.Append(p.Name).Append('\t');
                lines.Add(sb.ToString().TrimEnd('\t'));
            }

            foreach (var e in table)
            {
                var sb = new StringBuilder();
                foreach (var p in properties)
                    sb.Append(GetFormattedString(p.GetValue(e))).Append('\t');
                lines.Add(sb.ToString().TrimEnd('\t'));
            }

            return lines;
        }

        private static string GetFormattedString(object obj)
        {
            if (obj == null)
                return string.Empty;
            if (obj is ulong u)
                return u.ToString("X16");
            if (obj is IEnumerable x and not string)
                return string.Join("|", JoinEnumerator(x.GetEnumerator()).Select(GetFormattedString));
            return obj.ToString();
        }

        private static IEnumerable<object> JoinEnumerator(IEnumerator x)
        {
            while (x.MoveNext())
                yield return x.Current;
        }

        public static void Parse<T>(string path, T[] table)
        {
            var lines = GetPropertyTable(table);
            File.WriteAllLines(path, lines);
        }
    }
}
