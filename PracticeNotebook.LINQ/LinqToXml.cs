using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
namespace PracticeNotebook.LINQ
{
    public class LinqToXml
    {
        /*
         * todo [question - in progress - find an elegant solution to combine path in c# project]
         * Combine file path in c#.
         * `Environment.CurrentDirectory` will bring you to the `bin` folder
         */
        public void ReadData()
        {
            var solutionDirPath = Directory.GetParent(Environment.CurrentDirectory).Parent;
            if (solutionDirPath != null) solutionDirPath = solutionDirPath.Parent;
            if (solutionDirPath != null) solutionDirPath = solutionDirPath.Parent;
            // null-coalescing operator: ??
            // null-coalescing assignment operator: ??=
            string path = Path.Combine(Convert.ToString(solutionDirPath) ?? throw new FileNotFoundException(), "PracticeNotebook.LINQ", "Course.xml");
            XDocument document = XDocument.Load(path);
            // null condition operators: ?. or ?[]
            var listOfCourse = document.Descendants("course").Select(x => x.Attribute("id")?.Value + ", " + x.Element("name")?.Value);
            
            // todo [question - has been solved]
            // why it is only printing out the first one which is id = 1 Because there is only single one element under `courses`.
            // var listOfCourseId = document.Descendants("courses").Select(x => x.Element("course")?.Attribute("id")?.Value);
            
            foreach (var c in listOfCourse)
            {
                Console.WriteLine(c);
            }

            var listOfDesciption = document.Descendants("decription").Select(x => x.Element("level")?.Value);

            foreach (var d in listOfDesciption)
            {
                Console.WriteLine(d);
            }

        }
    }
}