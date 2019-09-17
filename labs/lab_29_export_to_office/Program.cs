using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed;
using Xceed.Words.NET;
using System.Diagnostics;

namespace lab_29_export_to_office
{
    class Program
    {
        static void Main(string[] args)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var fileName = @"RabbitReport.docx";
            var desktop = desktopPath + "\\" + fileName;
            Console.WriteLine(desktop.ToString());
            var doc = DocX.Create(desktop);

            doc.InsertParagraph("Rabbit Report");

            doc.InsertParagraph("Number of rabbits created : 1000");

            doc.InsertParagraph("Time taken : 7.256s with one loop");

            doc.InsertParagraph("Time taken : 17.256s with 1000 loops");

            doc.Save();

            Process.Start("WINWORD.EXE", desktop);

            Console.ReadLine();
        }
    }
}
