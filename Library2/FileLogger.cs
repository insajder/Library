using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Library2
{
    class FileLogger
    {
        private static void Log(string level, int id, string message)
        {
            var source = "File Logger";
            var dateLog = DateTime.Now;
            var noteLog = $"{dateLog} {level} {id} {message} {source}\n";
            var path = @"C:\Users\Public\FileLogger.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(noteLog);
            }
        }

        public static void Debug(string message)
        {
            Log("[Debug]", 1, message);
        }
        public static void Info(string message)
        {
            Log("[Info]", 2, message);
        }
        public static void Warn(string message)
        {
            Log("[Warn]", 3, message);
        }
        public static void Error(string message)
        {
            Log("[Error]", 4, message);
        }
        public static void Fatal(string message)
        {
            Log("[Fatal]", 5, message);
        }
    }
}
