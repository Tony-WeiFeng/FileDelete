using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileDelete
{
    class Del
    {
        public string Delete_path;
        public DateTime Date_limit;


        public Del(string path, DateTime limit)
        {
            this.Delete_path = path;
            this.Date_limit = limit;
        }

        public void DeleteFile()
        {
            //           string pa = @"C:\A";
            //            DateTime li = new DateTime(2012, 12, 1, 0, 0, 0);
            //StreamWriter sw = new StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\log.txt");


            string logFile = System.IO.Directory.GetCurrentDirectory() + "/log.txt";
            StreamWriter sw = new StreamWriter(logFile, true);

            foreach (var file in GetAllFiles(new DirectoryInfo(Delete_path)))
            {
                try
                {
                    DateTime createTime;
                    DateTime modifyTime;
                    DateTime accessTime;

                    createTime = file.CreationTime;
                    modifyTime = file.LastWriteTime;
                    accessTime = file.LastAccessTime;

                    if (createTime < Date_limit && modifyTime < Date_limit && accessTime < Date_limit)
                    {
                        file.Delete();
                        //Console.WriteLine(file + " was deleted just now!");
                        sw.WriteLine(DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ":  " + file + " was deleted just now!");
                    }
                    else
                    {
                        Console.WriteLine(file);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(file);

                }
            }
            sw.WriteLine(DateTime.Now.Date.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ":  ---------end for this time!--------");
            sw.Close();


        }

        public List<FileInfo> GetAllFiles(DirectoryInfo path, bool firstSubDir = true)
        {
            List<FileInfo> fileslist = new List<FileInfo>();
            if (path != null)
            {
                FileInfo[] file = path.GetFiles();
                fileslist.AddRange(file);
            }
            DirectoryInfo[] subDirs = path.GetDirectories();

            foreach (var subDir in subDirs)
            {
                if (firstSubDir && (subDir.Name.ToLower() == "ms" || subDir.Name.ToLower() == "common"))
                {
                    //do nothing...
                }
                else
                {
                    fileslist.AddRange(GetAllFiles(subDir, false));
                }
            }
            return fileslist;
        }
    }
}