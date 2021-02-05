using System;
using System.Collections.Generic;

namespace Sample5
{
    public class Solution
    {
        public int[] RunningSum(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] += nums[i - 1];
            }

            return nums;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solution s1 = new Solution();
            string[] parts = Console.ReadLine().Split();
            List<int> numbers = new List<int>();
            for (int i = 0; i < parts.Length; ++i)
            {
                numbers.Add(int.Parse(parts[i]));
            }

            int[] nums = numbers.ToArray();
            foreach (int x in s1.RunningSum(nums))
            {
                Console.Write(x + " ");
            }
        }

    }
}