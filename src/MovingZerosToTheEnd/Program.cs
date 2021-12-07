using System;
using System.Linq;

namespace MovingZerosToTheEnd
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}));
    }
    
    public static int[] MoveZeroes(int[] arr)
    {
      var result = new int[arr.Length];

      var index = 0;
      var endIndex = result.Length;

      foreach (var value in arr)
      {
        if (value == 0)
        {
          result[--endIndex] = 0;
        }
        else
        {
          result[index++] = value;
        }
      }

      return result;
    }
  }
}