using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace Delete_Files
{
    internal class Delete_older_files
    {
        static void Main(string[] args)
        {
            string PathValue = ConfigurationManager.AppSettings["Path"];
            string DaysValue = ConfigurationManager.AppSettings["Days"];
            DirectoryInfo yourRootDir = new DirectoryInfo(PathValue);
            foreach (FileInfo file in yourRootDir.GetFiles())
            {
                if (file.LastWriteTime < DateTime.Now.AddDays(-Convert.ToDouble(DaysValue)))
                    file.Delete();
                Console.WriteLine("Deleted the files from path { "+PathValue+" } which are older then "+DaysValue+ " days");
            }
            Console.ReadKey();
        }
    }
}
