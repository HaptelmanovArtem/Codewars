using System;
using System.Collections.Generic;
using System.Linq;

namespace Next_bigger_number_with_the_same_digits
{
  class Program
  {
    static void Main(string[] args)
    {
      NextBiggerNumber(21581957621);
    }

    public static long NextBiggerNumber(long n)
    {
      var s = n.ToString().ToCharArray();

      var pivotIndex = -1;

      for (var i = s.Length - 1; i >= 0; i--)
      {
        if (i - 1 < 0)
          return -1;

        if (s[i] > s[i - 1])
        {
          pivotIndex = i - 1;
          break;
        }
      }

      if (pivotIndex == -1)
      {
        return -1;
      }

      var rightSideArray = new List<char>();

      for (var i = s.Length - 1; i > pivotIndex; i--)
      {
        rightSideArray.Add(s[i]);
      }

      rightSideArray = rightSideArray.OrderBy(i => i).ToList();
      var swapValueIndex = -1;

      for (var j = 0; j < rightSideArray.Count; j++)
      {
        if (s[pivotIndex] < rightSideArray[j])
        {
          swapValueIndex = j;
          break;
        }
      }

      if (swapValueIndex == -1)
        return -1;

      var pivotTemp = s[pivotIndex];
      s[pivotIndex] = rightSideArray[swapValueIndex];
      rightSideArray[swapValueIndex] = pivotTemp;
      
      var result = new[] {s.ToList().Take(pivotIndex + 1), rightSideArray}
        .SelectMany(i => i)
        .ToList();

      return long.Parse(result.ToArray());
    }
  }
}