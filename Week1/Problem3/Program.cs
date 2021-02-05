using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Problem3
{
    
    public class Solution {
        public int numberOfSteps (int num)
        {
            int steps = 0;
            while (num > 0)
            {
                if (num % 2 == 1)
                {
                    num--;
                    steps++;
                }
                
                else if (num % 2 == 0)
                {
                    num = num / 2;
                    steps++;
                }

                
            }

            return steps;
        }
    };
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution s1 = new Solution();
            string str = Console.ReadLine();
            Console.Write(s1.numberOfSteps(int.Parse(str)));
            

        }

   
    }
}
