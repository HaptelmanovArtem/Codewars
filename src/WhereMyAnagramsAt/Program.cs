using System;
using System.Collections.Generic;
using System.Linq;

namespace WhereMyAnagramsAt
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }

    public static List<string> Anagrams(string word, List<string> words)
    {
      return words
        .Where(i => i.OrderBy(j => j).SequenceEqual(word.OrderBy(j => j)))
        .ToList();
    }
  }
}