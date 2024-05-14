using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TwoSum
{
    //https://leetcode.com/problems/two-sum/
    class Program
    {
        static void Main(string[] args)
        {
            var res = TwoSumFullPopulateDict(new int[] { 3, 2, 4 }, 6);
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] { i, j };
                    }
                }
            }

            return null;
        }


        public int[] TwoSumWithDictDynamicUnderstandWhatWeNeedToFind(int[] nums, int targer)
        {
            var dict = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                var searchedValue = targer - nums[i];

                if (dict.ContainsKey(searchedValue))
                    return new int[] { dict[searchedValue], i };
                else 
                    dict[nums[i]] = i;
            }

            return new int[] { };
        }

        public static int[] TwoSumFullPopulateDict(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                dict[nums[i]] = i;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                var searchedValue = target - nums[i];

                if (dict.TryGetValue(searchedValue, out var index) && index != i)
                    return new int[] { dict[searchedValue], i };
            }

            return new int[] { };
        }
    }
}