// See https://aka.ms/new-console-template for more information

using System.Text;

LongestPalindrome("aacabdkacaa");
  
string LongestPalindrome(string s)
{
  var res = string.Empty;

  for (int i = 0; i < s.Length; i++)
  {
    var j = i + 1;
    for (; j < s.Length; j++)
    {
      if (IsPalindrome(s, i, j))
      {
        if (j + 1 - 1 > res.Length)
        {
          res = s.Substring(i, j + 1 - i);
        }
      }
    }
    
    if (IsPalindrome(s, i, j - 1))
    {
      if (j + 1 - 1 > res.Length)
      {
        res = s.Substring(i, j - i);
      }
    }
  }

  return res;
}

bool IsPalindrome(string s, int i, int j)
{
  while (i >= 0 && i < j && s[i] == s[j])
  {                 
    i++;                 
    j--;             
  }             
  return i >= j;
}

