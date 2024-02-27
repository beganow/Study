using System;
using System.IO;

namespace Lec04LibN
{
    public partial class Logger : ILogger
    {
        private static Logger instance;
        public string action;
        public int number = 1;
        public string title = "";

        private Logger()
        { }

        public static ILogger create()
        {
            if (instance == null)
                instance = new Logger();
            return instance;
        }


        private string LogFileName = string.Format(@"{0}/LOG{1}.txt", Directory.GetCurrentDirectory(), DateTime.Now.ToString("yyyyMMdd-HH-mm-ss"));

        public void log(string message = "")
        {
            if (number == 1)
                File.AppendAllText(LogFileName, number.ToString() + "-" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "-" + "INIT" + "\n");
            else
                File.AppendAllText(LogFileName, number.ToString() + "-" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "-" + "INFO" + " " + title + " " + message + "\n");
            number++;
        }
        public void start(string title)
        {
            action = "STRT";
            this.title += title + ":";
            File.AppendAllText(LogFileName, number.ToString() + "-" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "-" + action + " " + this.title + "\n");
            number++;
        }
        public void stop()
        {
            action = "STOP";
            title = title.Remove(title.Length - 2, 2);
            File.AppendAllText(LogFileName, number.ToString() + "-" + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "-" + action + " " + title + "\n");
            number++;
        }
    }
}

