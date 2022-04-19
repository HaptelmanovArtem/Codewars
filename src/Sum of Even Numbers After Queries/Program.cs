using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum_of_Even_Numbers_After_Queries
{
  class Program
  {
    static void Main(string[] args)
    {
      SumEvenAfterQueries(new[] {1, 2, 3, 4}, new int[][]
      {
        new []{1, 0},
        new []{-3, 1},
        new []{-4, 0},
        new []{2, 3}
      });
    }
    
    public static int[] SumEvenAfterQueries(int[] nums, int[][] queries)
    {
      var queryLength = queries.GetUpperBound(0) + 1;
      var result = new int[queryLength];

      var sum = 0;

      for (int i = 0; i < queryLength; i++)
      {
        if (nums[i] % 2 == 0)
          sum += nums[i];
      }
      
      for (int i = 0; i < queryLength; i++)
      {
        if (nums[queries[i][1]] % 2 == 0)
        {
          sum -= nums[queries[i][1]];
        }
        
        nums[queries[i][1]] += queries[i][0];
        
        if (nums[queries[i][1]] % 2 == 0)
        {
          sum += nums[queries[i][1]];
        }

        result[i] = sum;
      }
      
      return result;
    }
  }
}