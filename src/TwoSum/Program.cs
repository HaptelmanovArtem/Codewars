using System;
using System.Diagnostics;
using System.Linq;

namespace TwoSum
{
  //https://leetcode.com/problems/two-sum/
  class Program
  {
    static void Main(string[] args)
    {
      var res = TwoSum(new int[] {2, 7, 11, 15}, 9);
    }
    
    public static int[] TwoSum(int[] nums, int target) 
    {
      for (int i = 0; i < nums.Length; i++)
      {
        for (int j = i + 1; j < nums.Length; j++)
        {
          if (nums[i] + nums[j] == target)
          {
            return new[] {i, j};
          }
        }
      }

      return null;
    }
  }
}