using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            var teacher = new Teacher(name);
            return teacher;
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            var localCourse = new LocalCourse(name, teacher, lab);
            return localCourse;
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            var offsiteCourse = new OffsiteCourse(name, teacher, town);
            return offsiteCourse;
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }

    public abstract class Course : ICourse
    {
        private string name;
        private ITeacher teacher;
        public IList<string> Topics { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    name = value;
                }
            }
        }
        public ITeacher Teacher
        {
            get { return teacher; }
            set { teacher = value; }
        }

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.Topics = new List<string>();
        }

        public void AddTopic(string topic)
        {
            this.Topics.Add(topic);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(this.GetType().Name + ":");
            result.Append(" Name=" + this.Name + ";");
            if (Teacher != null)
            {
                result.Append(" Teacher=" + this.Teacher.Name + ";");
            }
            if (Topics.Count > 0)
            {
                result.Append(" Topics=[");
                foreach (var topic in Topics)
                {
                    result.Append(topic + ", ");
                }
                result.Length -= 2;
                result.Append("];");
            }
            return result.ToString();
        }
    }


    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public string Lab
        {
            get { return lab; }
            set
            {
                if (value != null)
                {
                    lab = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.Append(" Lab=" + this.Lab);
            return result.ToString();
        }
    }

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public string Town
        {
            get { return town; }
            set
            {
                if (value != null)
                {
                    town = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.Append(" Town=" + this.Town);
            return result.ToString();
        }
    }

    public class Teacher : ITeacher
    {
        private string name;
        public IList<string> Courses { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                if (value != null)
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public Teacher(string name)
        {
            this.Name = name;
            this.Courses = new List<string>();
        }

        public void AddCourse(ICourse course)
        {
            Courses.Add(course.Name);
        }

        public override string ToString()
        {
            var teacherInfo = new StringBuilder();
            teacherInfo.Append("Teacher: ");
            teacherInfo.Append("Name=" + this.Name);
            if (Courses.Count > 0)
            {
                teacherInfo.Append("; Courses=[");
                foreach (var course in Courses)
                {
                    teacherInfo.Append(course + ", ");
                }
                teacherInfo.Length -= 2;
                teacherInfo.Append("]");
            }
            return teacherInfo.ToString();
        }
    }
}
