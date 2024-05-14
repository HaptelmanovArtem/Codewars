using System.Collections.Specialized;

namespace General
{

    /// <summary>
    /// https://leetcode.com/problems/valid-anagram/
    /// </summary>
    public class ValidAnagramSln
    {
        // counting each item
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            var temp = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++) 
            {
                if (temp.ContainsKey(s[i]))
                    temp[s[i]]++;
                else
                    temp[s[i]] = 1;
            }

            for (int i = 0; i < t.Length; i++)
            {
                if (!temp.ContainsKey(t[i]))
                    return false;
                else
                    temp[t[i]]--;
            }

            foreach (var kvp in temp)
            {
                if (temp[kvp.Key] != 0)
                    return false;
            }

            return true;
        }

        // with sort
        public bool IsAnagramSort(string s, string t) 
        {
            if (s.Length != t.Length)
                return false;

            var sArr = s.ToCharArray();
            var tArr = t.ToCharArray();

            Array.Sort(sArr);
            Array.Sort(tArr);

            for (int i = 0; i < s.Length; i++)
            {
                if (sArr[i] != tArr[i])
                    return false;
            }

            return true;
        }
    }
}