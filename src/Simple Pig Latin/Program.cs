using System;
using System.Linq;
using System.Text;

namespace Simple_Pig_Latin
{
  internal static class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
    
    public static string PigIt(string str)
    {
      const string ayWord = "ay";
      
      var words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);

      var sb = new StringBuilder();

      var pigitWords = words.Select(word => 
        !word.All(char.IsLetter) 
          ? word 
          : $"{word[1..]}{word[0]}{ayWord}");

      return string.Join(" ", pigitWords);
    }
  }
} 