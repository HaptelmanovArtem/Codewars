using System.Text;

namespace General
{
    public partial class Solution
    {
        public bool IsPalindrome(string s)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetterOrDigit(s[i]))
                    sb.Append(s[i]);
            }

            var newString = sb.ToString().ToLower();
            
            var x = 0;
            var y = newString.Length - 1;
            var mid = newString.Length / 2;

            while (x <= mid && y >= mid) 
            {
                if (newString[x] != newString[y])
                    return false;

                x++;
                y--;
            }

            return true;
        }
    }
}
