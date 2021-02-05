using System;
using X;
using Y;

namespace X{
    class Student
    {
        public string name;
        public string surname;
        public double gpa;

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", name, surname, gpa);
        }
    }

}

namespace Y{
    class Student
    {
        public string name;
        public string surname;
        public double gpa;

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", name, gpa, surname);
        }
    }

}
    
namespace Sample2
{

    

    public class Program
    {
        public static void Main(string[] args)
        {
            Y.Student newStudent = new Y.Student();
            newStudent.name = "A";
            newStudent.surname = "B";
            newStudent.gpa = 23;

            Console.WriteLine(newStudent);

        }
    }
}