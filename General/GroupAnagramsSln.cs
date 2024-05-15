using System.Text;

/// <summary>
/// https://leetcode.com/problems/group-anagrams/
/// </summary>
public class GroupAnagramsSln
{
    public IList<IList<string>> GroupAnagramsDetectAnagramViaSorting(string[] strs)
    {
        if (strs.Length == 0)
            return new List<IList<string>>();

        var anagrams = new Dictionary<string, List<string>>();

        var sb = new StringBuilder();

        for (var i = 0; i < strs.Length; i++)
        {
            var str = strs[i];
            var strArr = str.ToArray();
            Array.Sort(strArr);
            var sortedStr = sb.Append(strArr).ToString();

            if (anagrams.ContainsKey(sortedStr))
            {
                anagrams[sortedStr].Add(str);
            }
            else
            {
                anagrams[sortedStr] = new List<string> { str };
            }

            sb.Clear();
        }

        return new List<IList<string>>(anagrams.Values);
    }

    public IList<IList<string>> GroupAnagramsCountChars(string[] strs)
    {
        var minCharacter = 'a';
        if (strs.Length == 0)
            return new List<IList<string>>();

        var anagrams = new Dictionary<string, List<string>>();

        var tempArrLength = 'z' - 'a' + 1;

        for (var i = 0; i < strs.Length; i++)
        {
            var temp = new int[tempArrLength];

            foreach(var c in strs[i])
            {
                int position = (int)c - (int)minCharacter;
                temp[position]++;
            }

            var sb = new StringBuilder();
            for(var k = 0; k < tempArrLength; k++)
            {
                if (temp[k] == 0)
                    continue;

                sb.Append((char)'a' + k);
                sb.Append(temp[k]);
            }

            var key = sb.ToString();
            if (anagrams.ContainsKey(key))
            {
                anagrams[key].Add(strs[i]);
            }
            else
            {
                anagrams[key] = new List<string> { strs[i] };
            }
        }

        return new List<IList<string>>(anagrams.Values);
    }
}