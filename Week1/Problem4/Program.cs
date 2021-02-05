using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Problem4
{
    public class Solution
    {
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            string str1 = string.Join("", word1);
            string str2 = string.Join("", word2);
            return str1 == str2;
        }
    }

    public class Program
    {

        public static void Main(string[] args)
        {
            Solution s1 = new Solution();
            string[] word1 = Console.ReadLine().Split();
            string[] word2 = Console.ReadLine().Split();
            if (s1.ArrayStringsAreEqual(word1, word2))
            {
                Console.WriteLine("true");
            }
            else Console.WriteLine("false");


        }


    }
}