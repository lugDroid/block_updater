using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyBlocks
{
    public static class Globals
    {
        public static bool verbose;
        public static TextBox log;

        public static void Log(string text)
        {
            log.AppendText(text);
            log.AppendText(Environment.NewLine);
        }

        public static void LogVerbose(string text)
        {
            if (verbose)
            {
                Log(text);
            }
        }

        public static IEnumerable<T> OrderByAlphaNumeric<T>(this IEnumerable<T> source, Func<T, string> selector)
        {
            int max = source.SelectMany(i => Regex.Matches(selector(i), @"\d+").Cast<Match>().Select(m => (int?)m.Value.Length)).Max() ?? 0;
            return source.OrderBy(i => Regex.Replace(selector(i), @"\d+", m => m.Value.PadLeft(max, '0')));
        }
    }
}
