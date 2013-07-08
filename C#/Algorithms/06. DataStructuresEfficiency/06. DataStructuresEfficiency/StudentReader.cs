using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class StudentReader
{
    /* Task 1: 
     * A text file students.txt holds information about students and their courses in the following format:
     * 
        * Kiril  | Ivanov   | C#
        * Stefka | Nikolova | SQL
        * Stela  | Mineva   | Java
        * Milena | Petrova  | C#
        * Ivan   | Grigorov | C#
        * Ivan   | Kolev    | SQL 
     * 
     *Using SortedDictionary<K,T> print the courses in alphabetical order and for each of them prints the students ordered by family and then by name:
     
       * C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
       * Java: Stela Mineva
       * SQL: Ivan Kolev, Stefka Nikolova 
     */

    static void Main(string[] args)
    {
        StreamReader reader = new StreamReader("..\\..\\input.txt");

        SortedDictionary<string, List<string>> courses = new SortedDictionary<string, List<string>>();
        char[] splitter = { '|' };

        using (reader)
        {
            var line = reader.ReadLine();

            while (line != null)
            {
                //TO Check: why StringSplitOptions.RemoveEmptyEntries does not removes the empty spaces. 
                string[] input = line.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                var name = input[0].Trim() + " " + input[1].Trim();
                var course = input[2].Trim();
                if (courses.ContainsKey(course))
                {
                    courses[course].Add(name);
                }
                else
                {
                    courses.Add(course, new List<string> { name });
                }
                line = reader.ReadLine();

            }
        }

        foreach (var course in courses)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}: ", course.Key);
            course.Value.Sort();
            foreach (var value in course.Value)
            {
                sb.AppendFormat("{0}, ", value);
            }

            //Removing the last comma(',') from the end of the string
            sb.Length -= 2;
            Console.WriteLine(sb.ToString());
        }
    }
}

