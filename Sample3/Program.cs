using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Sample3
{
    public class Program
    {

        class Student
        {
            protected void DoIt()
            {
                Console.WriteLine("done!");
            }

            public virtual string DoItX()
            {
                return "X";
            }
        }

        class SubStudent : Student
        {
            public void DoIt2()
            {
                DoIt();
            }

            public override string DoItX()
            {
                return "XS";
            }
        }
        
        public static void Main(string[] args)
        {
            SubStudent stu = new SubStudent();
            //stu.DoIt();
            Console.WriteLine(stu.DoItX());


        }

       
      
    }
}