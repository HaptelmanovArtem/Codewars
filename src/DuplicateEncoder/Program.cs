using System;
using System.Linq;
using System.Text;

namespace DuplicateEncoder
{
  internal static class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }

    public static string DuplicateEncode(string word)
    {
      const char oneAppearsCase = '(';
      const char moreAppearsCase = ')';

      var sb = new StringBuilder(word.Length);

      var lowerCaseWord = word.ToLowerInvariant();
      
      var wordMap = lowerCaseWord
        .GroupBy(item => item)
        .ToDictionary(i => i.Key, i => i.Count());

      foreach (var count in lowerCaseWord.Select(symbol => wordMap[symbol]))
      {
        if (count > 1)
        {
          sb.Append(moreAppearsCase);
          continue;
        }
        
        sb.Append(oneAppearsCase);
      }
      
      return sb.ToString();
    }
  }
}