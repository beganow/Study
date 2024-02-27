using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                OPBDiskInfo.GetDrives();
                OPBLog.WriteToLog("OPBDiskInfo.getDrives()");
                Console.WriteLine("#######################################");

                OPBFileInfo.GetFile("D:\\Лаба Пацей\\lab12\\OPBlogfile.txt");
                OPBLog.WriteToLog("OPBFileInfo.getFile()", "OPBlogfile", "D:\\Лаба Пацей\\lab12\\OPBlogfile.txt");
                Console.WriteLine("#######################################");

                OPBDirInfo.GetDir("D:\\Лаба Пацей\\lab12");
                OPBLog.WriteToLog("OPBDirInfo.GetDir()", "", "D:\\Лаба Пацей\\lab12\\OPBlogfile.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
