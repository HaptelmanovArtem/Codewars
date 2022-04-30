// See https://aka.ms/new-console-template for more information

using System.Text;

var s = MyAtoi(" ");

int MyAtoi(string s)
{
  s = s.TrimStart();

  if (s.Length == 0)
    return 0;

  var sb = new StringBuilder();

  var index = 0;
  var isNegative = false;

  if (s[index] == '-' || s[index] == '+') isNegative = s[index++] == '-';

  int? lastCorrectValue = null;
  for (; index < s.Length; index++)
  {
    if (!char.IsDigit(s[index]))
      break;

    sb.Append(s[index]);

    if (int.TryParse(sb.ToString(), out var res))
    {
      lastCorrectValue = res * (isNegative ? -1 : 1);
    }
    else if (lastCorrectValue.HasValue)
    {
      if (lastCorrectValue.Value > 0)
        return int.MaxValue;

      return int.MinValue;
    }
  }

  return lastCorrectValue ?? 0;
}