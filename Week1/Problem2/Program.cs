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
      
            string defangIPaddr(string address) {
                for (int i = 0; i < address.Length; i++)
                {
                    if (address[i] == '.')
                    {
                        address[i] = '[.]';
                    }
                }
            }
        };
        
        public static void Main(string[] args)
        {
            Solution s1 = new Solution();
            string[] ip = Console.ReadLine().Split();
            

        }

      
    }
}