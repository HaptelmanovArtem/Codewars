using System;
using System.Linq;

namespace DetectPangram
{
  /// <summary>
  /// https://www.codewars.com/kata/545cedaa9943f7fe7b000048/train/csharp
  /// </summary>
  internal static class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine(IsPangram("The quick brown fox jumps over the lazy dog."));
    }
    
    public static bool IsPangram(string str)
    {
      const int startLetterIndex = 97;
      const int endLetterIndex = 122;
      
      var letterIndexMap = Enumerable
        .Range(startLetterIndex, (endLetterIndex - startLetterIndex) + 1)
        .ToDictionary(i => i, _ => false);
      
      foreach (var t in str.ToLower())
      {
        var isLetter = char.IsLetter(t);

        if (isLetter && t >= startLetterIndex && t <= endLetterIndex)
        {
          letterIndexMap[t] = true;
        }
      }

      return letterIndexMap.Values.All(i => i);
    }
  }
}