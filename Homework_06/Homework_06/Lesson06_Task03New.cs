using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;

namespace Homework_06
{
    public class Lesson06_Task03New
    {
        private static List<Student> _students;
        private const string FILE = "students.csv";


        public static void RunTask03New()
        {
            _students = new List<Student>(LoadStudents(FILE));
            CountMasters();
            CountStudentsFrom18To20();
            SortStudentsByAge();
            SortStudentsByAgeAndCourse();
        }

        #region Task03New methods

        private static void SortStudentsByAgeAndCourse()
        {
            var studentsList = _students
                .OrderBy(student => student.Age)
                .ThenBy(student => student.Course);

            int index = 1;
            foreach (var student in studentsList)
            {
                Console.WriteLine($"#{index++} {student.FamilyName} " +
                    $"{student.Name} - age of {student.Age} years old - course: {student.Course}");
            }
            Console.WriteLine();
        }

        private static void SortStudentsByAge()
        {
            var studentsList = _students
                .OrderBy(student => student.Age);

            int index = 1;
            foreach (var student in studentsList)
            {
                Console.WriteLine($"#{index++} {student.FamilyName} " +
                    $"{student.Name} - age of {student.Age} years old");
            }
            Console.WriteLine();
        }

        private static void CountStudentsFrom18To20()
        {
            var studentsCount = _students
                .Where(student => student.Age >= 18 && student.Age <= 20)
                .GroupBy(student => student.Faculty);
                
            foreach(var group in studentsCount)
            {
                Console.WriteLine($"There are {group.Count()} students from " +
                    $"18 to 20 years old at {group.Key} faculty{Environment.NewLine}");                    
            }
            
        }

        private static void CountMasters()
        {
            var mastersCount = _students
                .Where(student => student.Degree == ScientificDegree.Master)
                .Count();

            Console.WriteLine($"There are {mastersCount} students " +
                $"study at 5th and 6th courses{Environment.NewLine}");
        }

        private static List<Student> LoadStudents(string fileName)
        {
            List<Student> students = new List<Student>();

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File '{fileName}' was not found");
                return null;
            }

            using (FileStream fileReader = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (StreamReader streamReader = new StreamReader(fileReader))
            {
                while (!streamReader.EndOfStream)
                {
                    string studentLine = streamReader.ReadLine();
                    string[] studentInfo = studentLine.Split(';');

                    Contract.Assert(studentInfo.Length == 9);

                    Student student = new Student(
                        studentInfo[0], studentInfo[1], studentInfo[2], studentInfo[3], studentInfo[4],
                        int.Parse(studentInfo[5]), int.Parse(studentInfo[6]), int.Parse(studentInfo[7]), studentInfo[8]);
                    students.Add(student);
                }
            }

            Contract.Assert(students.Count > 0);

            return students;
        }
        #endregion
    }

    #region class Student

    public class Student
    {
        private int _course;

        public string Name { get; private set; }
        public string FamilyName { get; private set; }
        public string Univercity { get; private set; }
        public string Faculty { get; private set; }
        public string Department { get; private set; }
        public int Age { get; private set; }
        public int Course 
        { 
            get => _course;
            private set
            {
                if(value >= 1 && value <= 6)
                    _course = value;
                else
                    _course = 0;
            }
        }
        public int Group { get; private set; }
        public string City { get; private set; }
        public ScientificDegree Degree => Course <= 4 ? ScientificDegree.Bachelor : ScientificDegree.Master;

        public Student(
            string name, string familyName, string univercity, string faculty, 
            string department, int age, int course, int group, string city)
        {
            Name = name;
            FamilyName = familyName;
            Univercity = univercity;
            Faculty = faculty;
            Department = department;
            Age = age;
            Course = course;
            Group = group;
            City = city;
        }
    }

    public enum ScientificDegree { Bachelor, Specialist, Master, DoctoralCandidate, DoctorOfScience, }

    #endregion
}
