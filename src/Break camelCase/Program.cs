using System;
using System.Text;

namespace Break_camelCase
{
  internal static class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine(BreakCamelCase("testTestTestiong"));
    }
    
    public static string BreakCamelCase(string str)
    {
      var sb = new StringBuilder();
      
      foreach (var charItem in str)
      {
        if (char.IsUpper(charItem))
        {
          sb.Append($" {charItem}");
          continue;
        }

        sb.Append(charItem);
      }

      return sb.ToString();
    }
  }
}