using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
