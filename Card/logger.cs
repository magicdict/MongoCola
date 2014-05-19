using System;
using System.IO;

namespace Card
{
    public static class logger
    {
        public static StreamWriter logfile = new StreamWriter("C:\\mlog.txt", true, System.Text.UnicodeEncoding.Unicode);
        public static void Log(String Info)
        {
            logfile.WriteLine(DateTime.Now.ToString() + Info);
            logfile.Flush();
        }
    }
}
