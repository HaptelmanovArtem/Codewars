using System;
using System.Collections.Generic;
using System.Linq;

namespace UniqueInOrder
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(string.Join(string.Empty, UniqueInOrder(new[] {true, true, true, true})));
    }

    public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
    {
      var iterableList = iterable.ToList();

      if (iterableList.Count == 0)
        return Enumerable.Empty<T>();

      var res = new List<T>();

      for (var i = 0; i < iterableList.Count; i++)
      {
        if (i + 1 >= iterableList.Count)
        {
          res.Add(iterableList[i]);
          break;
        }

        if (!iterableList[i].Equals(iterableList[i + 1]))
          res.Add(iterableList[i]);
      }

      return res;
    }
  }
}