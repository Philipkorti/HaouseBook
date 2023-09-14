using Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Setup
    {
        /// <summary>
        /// Setup methode for these Programm.
        /// </summary>
        /// <param name="path">Path for the files.</param>
        public static void SetUp(string path)
        {
            string folderpath;
            if (path == "")
            {
                // Create the config folder.
                folderpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\HouseBook";
                Directory.CreateDirectory(folderpath);
                
            }
            else
            {
                // Create the file folder.
                folderpath = path + @"\HouseBook";
                Directory.CreateDirectory(folderpath);
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\HouseBook\Config");
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\HouseBook\Config\Config.txt").Close();
            }
        }
        public static void SaveInformation(Config config)
        {
            using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\HouseBook\Config\Config.txt"))
            {
                sw.WriteLine(config.Path);
                sw.WriteLine(config.Country);
                sw.WriteLine(config.Curentcy);
                sw.WriteLine(config.Income); 
                sw.WriteLine(config.Forthmonthsalary);
                sw.WriteLine(config.Monthsalary);
                sw.WriteLine(config.ForthmonthsalaryDate.ToString("dd MM"));
                sw.WriteLine(config.MonthsalaryDate.ToString("dd MM"));
            }
        }

    }
}
