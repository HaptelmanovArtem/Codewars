using System;
using System.IO.Compression;
using System.Linq;

namespace StripComments
{
  /// <summary>
  /// https://www.codewars.com/kata/51c8e37cee245da6b40000bd/train/csharp
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(StripComments("#b\n\n\n\n\nc\nd", new string[] { "#", "$" }));
    }

    public static string StripComments(string text, string[] commentSymbols)
    {
      if (commentSymbols.Length == 0 || text.Length == 0)
        return text;

      var textByLines = text.Split("\n", StringSplitOptions.None);

      var textWithoutComments = textByLines.Select(textByLine =>
      {
        foreach (var commentSymbol in commentSymbols)
        {
          var commentSymbolIndex = textByLine.IndexOf(commentSymbol, StringComparison.Ordinal);

          if (commentSymbolIndex == -1)
            continue;

          return textByLine.Remove(commentSymbolIndex, textByLine.Length - commentSymbolIndex).TrimEnd();
        }

        return textByLine.TrimEnd();
      });

      return string.Join("\n", textWithoutComments);
    }
  }
}