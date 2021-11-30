using System;
using System.Collections.Generic;

namespace FindTheDivisors
{
  /// <summary>
  /// https://www.codewars.com/kata/544aed4c4a30184e960010f4/train/csharp
  /// </summary>
  internal static class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine(Divisors(15));
    }

    public static int[] Divisors(int n)
    {
      var result = new List<int>();
      
      for (var i = 2; i < n; i++)
      {
        if (n % i == 0)
          result.Add(i);
      }

      return result.Count == 0 
        ? null 
        : result.ToArray();
    }
  }
}