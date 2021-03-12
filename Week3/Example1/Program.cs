using System;

namespace Example1
{
    class Student
    {
        public string name;
        public double gpa;
    }

    class Student2
    {
        string name;
        double gpa;

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetGPA(double gpa)
        {   
            if(gpa > 0)
            {
            this.gpa = gpa;
            }
        }

        public string GetName()
        {
            return name;
        }

        public double GetGPA()
        {
            return gpa;
        }
    }

    class Student3
    {
        public string name { get; set; }

        double gpa;
        public double Gpa
        {
            set
            {
                if (value > 0)
                {
                    gpa = value;
                }
            }
            get
            {
                return gpa;
            }

            public override string ToString()
        {
            return name + " " + gpa;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            F4();
        }

        static void F4()
        {
            Student3 s = new Student3 { Gpa = 3.5, name = "John" };
            Console.WriteLine(s);
        }

        static void F3()
        {
            Student3 s = new Student3();
            s.Gpa = -4;
            s.name = "Bob";
            Console.WriteLine(s);
        }

        static void F2()
        {
            Student2 s = new Student2();
            s.SetGPA(3);
            s.SetName("Bob");

           
        }
    }
}
