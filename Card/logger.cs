using System;
using System.IO;

namespace Card
{
    public static class logger
    {
        public static void Log(String Info)
        {
            StreamWriter logfile = new StreamWriter("C:\\mlog.txt", true, System.Text.UnicodeEncoding.Unicode);
            logfile.WriteLine(DateTime.Now.ToString() + Info);
            logfile.Flush();
            logfile.Close();
        }
    }
}
