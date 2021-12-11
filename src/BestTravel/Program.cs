using System;
using System.Collections.Generic;
using System.Linq;

namespace BestTravel
{
  /// <summary>
  /// https://www.codewars.com/kata/55e7280b40e1c4a06d0000aa/train/csharp
  /// </summary>
  class Program
  {

    static void Main(string[] args)
    {
      List<int> ts = new List<int> {50, 55, 57, 58, 60};
      int? n = ChooseBestSum(163, 3, ts);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="t">Maximum distance that Marry can do</param>
    /// <param name="k">Count of towns that John want to visit</param>
    /// <param name="ls">Distances to towns</param>
    /// <returns></returns>
    public static int? ChooseBestSum(int t, int k, List<int> ls)
    {
      if (k > ls.Count)
        return null;
      
      if (ls.Count == 1 && ls[0] <= t)
      {
        return ls[0];
      }

      if (ls.Count == 1)
        return null;

      var sums = new List<int>();
      
      Combinators(ls, 0, k, new List<int>(), sums);

      foreach (var orderItem in sums.OrderByDescending(i => i))
      {
        if (orderItem <= t)
          return orderItem;
      }

      return null;
    }

    private static void Combinators(List<int> ls, int startPosition, int k, List<int> res, List<int> distances)
    {
      if (k == 0)
      {
        distances.Add(res.Sum());
        return;
      }
      
      for (var i = startPosition; i < ls.Count; i++)
      {
        res.Add(ls[i]);
        Combinators(ls, i + 1, k - 1, res, distances);
        res.RemoveAt(res.Count - 1);
      }
    }
  }
}