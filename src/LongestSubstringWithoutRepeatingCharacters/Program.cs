// See https://aka.ms/new-console-template for more information

using System.Text;

LengthOfLongestSubstring("dvdf");

static int LengthOfLongestSubstring(string s)
{
  var result = 0;
  var buffer = string.Empty;

  for (int i = 0; i < s.Length; i++)
  {
    buffer += s[i];
    for (int j = i + 1; j < s.Length; j++)
    {
      if (!buffer.Contains(s[j]))
      {
        buffer += s[j];
        continue;
      }
      break;
    }
    
    result = buffer.Length > result ? buffer.Length : result;
    buffer = string.Empty;
  }
  
  return result;
}