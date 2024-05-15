using System.Collections.Generic;

namespace General
{
    /// <summary>
    /// https://leetcode.com/problems/word-pattern/description/
    /// </summary>
    public class WordPatternSln
    {
        public bool WordPattern(string pattern, string s)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                return false;

            var tempStorage = new Dictionary<string, char>();
            var splitedData = s.Split(' ');
            var splitedPattern = pattern;

            if (splitedData.Length != splitedPattern.Length)
                return false;

            var uniquePatternItems = pattern.Distinct().Count();
            var uniqueWords = splitedData.Distinct().Count();

            if (uniquePatternItems != uniqueWords)
                return false;

            for (var i = 0; i < splitedData.Length; i++)
            {
                if (tempStorage.TryGetValue(splitedData[i], out var ptrn))
                {
                    if (ptrn != pattern[i])
                        return false;
                }
                else
                {
                    tempStorage[splitedData[i]] = splitedPattern[i];
                }
            }

            return true;
        }
    }
}
