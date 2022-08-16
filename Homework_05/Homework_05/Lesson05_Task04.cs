using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Homework_05
{
    public class Lesson05_Task04
    {
        private static List<Student> _students = new List<Student>();
        private const string FILE = "StudentsData.txt";

        public static void RunTask04()
        {
            List<string> worstStudents = GetWorstStudents();
            Console.WriteLine("Ученики с худшими оценками:");
            foreach (string student in worstStudents)
                Console.WriteLine(student);
        }

        #region Task04 methods

        private static List<string> GetWorstStudents()
        {
            LoadStudents();

            if (_students.Count == 0)
                throw new Exception("Students data was not loaded");

            var worstStudents = _students
                .OrderBy(student => student.AvarageGrade)
                .GroupBy(student => student.AvarageGrade)
                .Take(3)
                .SelectMany(group => group)
                .Select(student => student.ToString())
                .ToList();

            return worstStudents;
        }

        private static void LoadStudents()
        {
            _students.Clear();
            List<string> studentsFromFile = new List<string>();

            using (StreamReader reader = new StreamReader(FILE))
                while (!reader.EndOfStream)
                    studentsFromFile.Add(reader.ReadLine());

            for (int i = 1; i < studentsFromFile.Count; i++)
                _students.Add(ParseStudent(studentsFromFile[i]));

        }

        private static Student ParseStudent(string studentFromFile)
        {
            string[] data = studentFromFile.Split(' ');
            string familyName = data[0];
            string name = data[1];
            List<int> grades = new List<int>();

            for (int i = 2, j = 0; i < data.Length; i++, j++)
            {
                if (int.TryParse(data[i], out int grade))
                    grades.Add(grade);
            }

            return new Student(name, familyName, grades);
        }

        #endregion
    }

    #region class Student

    public class Student
    {
        private readonly string _name;
        private readonly string _familyName;
        private List<int> _grades;

        public double AvarageGrade => _grades.Average();

        public Student(string name, string familyName, List<int> grades)
        {
            _name = name;
            _familyName = familyName;
            _grades = new List<int>(grades);
        }

        public override string ToString() => $"{_familyName} {_name} со средней оценкой {AvarageGrade:F1}";
    }

    #endregion
}
