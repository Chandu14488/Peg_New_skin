using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.PageHelper.Comm
{
    class ExecutionLog
    {
        public void Log(String filename,String text)
        {
            try
            {
                // Create file 
                string Currentpath = Directory.GetCurrentDirectory();
                String[] ab = Currentpath.Split(new string[] { "bin" }, StringSplitOptions.None);
                String a = ab[0];
                String fPath = a + "ExecutionLog\\"+filename+".txt";
                if (!File.Exists(fPath))
                 {
                     FileStream aFile = new FileStream(fPath, FileMode.Create, FileAccess.Write);
                     StreamWriter sw = new StreamWriter(aFile);
                     sw.WriteLine(text);

                     sw.Close();
                     aFile.Close();
                }
                else if (File.Exists(fPath))
                 {
                     FileStream aFile1 = new FileStream(fPath, FileMode.Append, FileAccess.Write);
                     StreamWriter sw = new StreamWriter(aFile1);
                     sw.WriteLine(text);

                     sw.Close();
                     aFile1.Close();
                 }
            }
            catch (Exception e)
            {
                //Catch exception if any
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public void Count(String filename, String text)
        {
            try
            {
                // Create file 
                string Currentpath = Directory.GetCurrentDirectory();
                String[] ab = Currentpath.Split(new string[] { "bin" }, StringSplitOptions.None);
                String a = ab[0];
                String fPath = a + "ExecutionLog\\" + filename + ".txt";
                if (!File.Exists(fPath))
                {
                    using (StreamWriter sw = File.CreateText(fPath))
                    {
                        sw.WriteLine(text);
                    }
                }
                else if (File.Exists(fPath))
                {
                    using (StreamWriter sw = File.CreateText(fPath))
                    {
                        sw.WriteLine(text);
                    }
                }
            }
            catch (Exception e)
            {
                //Catch exception if any
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public String readLastLine(String filename)
        {
            string Currentpath = Directory.GetCurrentDirectory();
            String[] ab = Currentpath.Split(new string[] { "bin" }, StringSplitOptions.None);
            String a = ab[0];
            String fPath = a + "ExecutionLog\\" + filename + ".txt";
            string line = "";
            if (File.Exists(fPath))
            {
                var lines = File.ReadLines(fPath);
               line = lines.Last();
            }
            return line;
        }

        public String GetAllTextFile(string filename)
        {
            string Currentpath = Directory.GetCurrentDirectory();
            String[] ab = Currentpath.Split(new string[] { "bin" }, StringSplitOptions.None);
            String a = ab[0];
            String fPath = a + "ExecutionLog\\" + filename + ".txt";
            return File.ReadAllText(fPath);
        }

        public void DeleteFile(string filename)
        {
            string Currentpath = Directory.GetCurrentDirectory();
            String[] ab = Currentpath.Split(new string[] { "bin" }, StringSplitOptions.None);
            String a = ab[0];
            String fPath = a + "ExecutionLog\\" + filename + ".txt";
            if (File.Exists(fPath))
            {
                File.Delete(fPath);
            }
        }


    }
}
