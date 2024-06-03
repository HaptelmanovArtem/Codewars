using System.Text;

namespace General
{
    /// <summary>
    /// https://neetcode.io/problems/string-encode-and-decode
    /// </summary>
    public class StringEncodeAndDecodeSln
    {
        public string Encode(IList<string> strs)
        {
            var result = new StringBuilder();

            foreach (var str in strs)
            {
                result.Append($"{str.Length}@{str}");
            }

            return result.ToString();
        }

        public List<string> Decode(string s)
        {
            var result = new List<string>();

            var index = 0;

            while (index < s.Length)
            {
                var numOfSymbolsStr = GetNumberOfSymbols(s, index);
                if (int.TryParse(numOfSymbolsStr, out var numOfSymbols) && numOfSymbols == -1)
                {
                    break;
                }

                var str = s.Substring(index + numOfSymbolsStr.Length + 1, numOfSymbols);
                result.Add(str);
                index = index + numOfSymbolsStr.Length + 1 + numOfSymbols;
            }

            return result;
        }

        private string GetNumberOfSymbols(string s, int currentIndex)
        {
            var sb = new StringBuilder();

            while (currentIndex < s.Length && s[currentIndex] != '@')
            {
                sb.Append(s[currentIndex++]);
            }

            return sb.ToString();
        }
    }
}
