using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace lab12
{
    class OPBLog
    {
        static public StreamWriter logfile;

        static OPBLog()
        {
            using (logfile = new StreamWriter("D:\\Лаба Пацей\\lab12\\OPBlogfile.txt", true))
                logfile.WriteLine("#################################################");
        }
        static public void WriteToLog(string action, string fileName = "", string path = "")
        {
            using (logfile = new StreamWriter("D:\\Лаба Пацей\\lab12\\OPBlogfile.txt", true))
            {
                DateTime time = new DateTime();
                time = DateTime.Now;

                logfile.WriteLine($"Действие: {action}");

                if (fileName.Length != 0)
                    logfile.WriteLine($"Имя файла: {fileName}");

                if (path.Length != 0)
                    logfile.WriteLine($"Путь: {path}");

                logfile.WriteLine($"Время: {time.ToLocalTime()}");

            }
        }
    }
}
