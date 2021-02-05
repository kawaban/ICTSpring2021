using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Problem2
{
    public class Program
    {
        public class Solution {
      
            public string defangIPaddr(string address)
            { 
                address = address.Replace(".", "[.]");
                

                return address;
            }
        };
        
        public static void Main(string[] args)
        {
            Solution s1 = new Solution();
            string ip = Console.ReadLine();
            Console.WriteLine(s1.defangIPaddr(ip));
            

        }

      
    }
}