using System;
using System.Collections.Generic;

namespace WhoLikesIt
{
  /// <summary>
  /// https://www.codewars.com/kata/5266876b8f4bf2da9b000362/csharp
  /// </summary>
  internal static class Program
  {
    private static void Main()
    {
    }
    
    private static readonly IReadOnlyDictionary<int, string> _lenghtToPatternMap = new Dictionary<int, string>
    {
      [0] = "no one likes this",
      [1] = "{0} likes this",
      [2] = "{0} and {1} like this",
      [3] = "{0}, {1} and {2} like this",
      [4] = "{0}, {1} and {2} others like this",
    };

    public static string Likes(string[] name)
    {
      if (name.Length <= 3) 
        return string.Format(_lenghtToPatternMap[name.Length], name);
      
      var pattern = _lenghtToPatternMap[4];
      return string.Format(pattern, name[0], name[1], name.Length - 2);
    }
  }
}