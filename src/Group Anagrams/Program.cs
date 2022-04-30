// See https://aka.ms/new-console-template for more information
// https://leetcode.com/problems/group-anagrams/

public static class Program
{
  public static void Main(string[] args)
  {
    var a = GroupAnagrams(new[] {"ac", "c"});
  }

  private static IList<IList<string>> GroupAnagrams(string[] strs)
  {
    if (strs.Length == 0) return new List<IList<string>>(0);

    var result = new List<IList<string>>();

    var source = strs.Select(i => new AnagramDto {Item = i, Used = false}).ToList();

    foreach (var group in source.Where(i => !i.Used))
    {
      if (group.Used) continue;

      var anagram = group.Item;

      var anagramCluster = new List<string>();

      var groupedValue = anagram.GroupBy(i => i).ToDictionary(i => i.Key, i => i.Count());

      foreach (var j in source.Where(k => !k.Used))
        if (IsAnagram(groupedValue, j.Item))
        {
          j.Used = true;
          anagramCluster.Add(j.Item);
        }

      group.Used = true;

      result.Add(anagramCluster);
    }

    return result;
  }

  private static bool IsAnagram(IReadOnlyDictionary<char, int> xDict, string y)
  {
    if (xDict.Count == 0 && y.Length != 0)
      return false;

    foreach (var (key, value) in xDict)
    {
      if (!y.Contains(key))
        return false;

      if (value != y.Count(j => j == key))
        return false;
    }

    return true;
  }

  private class AnagramDto
  {
    public string Item { get; set; }
    public bool Used { get; set; }
  }
}