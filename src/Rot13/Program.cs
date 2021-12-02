using System;
using System.Text;

namespace Rot13
{
  /// <summary>
  /// https://www.codewars.com/kata/530e15517bc88ac656000716/train/csharp
  /// </summary>
  internal static class Program
  {
    private const int LatinUpperStartIndex = 65;
    private const int LatinUpperEndIndex = 90;
    private const int LatinLowerStartIndex = 97;
    private const int LatinLowerEndIndex = 122;
    private const int Rot13Index = 13;

    private static void Main(string[] args)
    {
      Console.WriteLine(Rot13("test"));
    }
    
    public static string Rot13(string message)
    {
      var sb = new StringBuilder();

      foreach (var item in message)
      {
        if (item >= LatinUpperStartIndex && item <= LatinUpperEndIndex)
        {
          sb.Append(GetRot13Symbol(item, LatinUpperStartIndex, LatinUpperEndIndex));
        }
        else if (item >= LatinLowerStartIndex && item <= LatinLowerEndIndex)
        {
          sb.Append(GetRot13Symbol(item, LatinLowerStartIndex, LatinLowerEndIndex));
        }
        else
          sb.Append(item);
      }

      return sb.ToString();
    }

    private static char GetRot13Symbol(
      char index,
      int start, 
      int end)
    {
      var position = index;
      var counter = 0;
      
      while (counter < Rot13Index)
      {
        if (++position > end)
        {
          position = (char)start;
        }

        counter++;
      }

      return position;
    }
  }
}