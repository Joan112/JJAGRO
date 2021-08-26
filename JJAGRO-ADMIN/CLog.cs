using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJAGRO_ADMIN
{
    class CLog
    {
        public static void XLog(string sMensaje)
        {
            string folderPath = @"C:\JJAGRO\LOG";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string txtLog = "JJAGRO-" + DateTime.Now.Day.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Year.ToString();
            using (StreamWriter Writer = new StreamWriter(string.Format("C:\\JJAGRO\\LOG\\{0}.txt", txtLog), true))
            {
                //Writer.WriteLine(sMensaje);
                Writer.WriteLine("[" + DateTime.Now.ToString("h:mm:ss") + "] >> " + sMensaje);
            }
        }
    }
}
