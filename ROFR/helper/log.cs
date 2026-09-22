using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace ROFR.helper
{
    public class Log
    {
        public object Logcreate(dynamic strMsg, string mappath, string employeeid)
        {
            try
            {

                string strPath = mappath + "\\" + DateTime.Now.ToString("MMddyyyy") + "\\" + employeeid;
                if (!Directory.Exists(strPath))
                    Directory.CreateDirectory(strPath);
                string path = strPath + "\\" + "Log" + DateTime.Now.ToString("yyyyMMddhhmmssmmm") + serNumber().ToString();
                StreamWriter swLog = new StreamWriter(path + ".txt", true);
                swLog.WriteLine(strMsg);
                swLog.Close();
                swLog.Dispose();
                return "Success";
            }
            catch
            {
                return "Fail";
            }
        }

        public int serNumber()
        {
            Random r = new Random();
            int random_num = r.Next(0, 99999);
            return random_num;
        }

        public object exceptionLog(dynamic strMsg, string mappath, string employeeid)
        {
            try
            {

                string strPath = ConfigurationSettings.AppSettings["loglocation"] + mappath;
                if (!Directory.Exists(strPath))
                    Directory.CreateDirectory(strPath);
                string path = strPath + "\\" + employeeid + "_" + serNumber().ToString();
                StreamWriter swLog = new StreamWriter(path + ".txt", true);
                swLog.WriteLine(strMsg);
                swLog.Close();
                swLog.Dispose();
                return "Success";
            }
            catch
            {
                return "Fail";
            }
        }
    }
}