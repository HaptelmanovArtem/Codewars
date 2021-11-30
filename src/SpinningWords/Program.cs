using System;
using System.Linq;

namespace SpinningWords
{
  /// <summary>
  /// Stop gninnipS My sdroW!
  /// </summary>
  internal static class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine(SpinWords("Hey wollef sroirraw"));
    }

    public static string SpinWords(string sentence)
    {
      const int lengthForReverse = 5;

      if (string.IsNullOrWhiteSpace(sentence))
        throw new ArgumentException("Incorrect argument", sentence);

      var words = sentence.Split(' ');

      var spinningWords = words
        .Select(word => word.Length >= lengthForReverse
          ? new string(word.Reverse().ToArray())
          : word);

      return string.Join(" ", spinningWords);
    }
  }
}