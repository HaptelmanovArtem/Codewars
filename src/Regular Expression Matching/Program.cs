// See https://aka.ms/new-console-template for more information

Console.WriteLine(IsMatch("aab", "c*a*b"));

const char singleCharExpression = '.';
const char zeroOrMorePrevCharExpression = '*';

bool IsMatch(string s, string p)
{
  var options = new[] {singleCharExpression, zeroOrMorePrevCharExpression};

  var isRegularExpression = p.Any(c => options.Contains(c));

  if (!isRegularExpression) return p == s;

  if (s.Length == 0) return true;

  var matrix = new bool[s.Length + 1, p.Length + 1];

  matrix[0, 0] = true;

  for (var i = 2; i < matrix.GetLength(1); i++)
    if (p[i - 1] == zeroOrMorePrevCharExpression)
      matrix[0, i] = matrix[0, i - 2];

  for (var i = 1; i < matrix.GetLength(0); i++)
  for (var j = 1; j < matrix.GetLength(1); j++)
    if (s[i - 1] == p[j - 1] || p[j - 1] == singleCharExpression)
    {
      matrix[i, j] = matrix[i - 1, j - 1];
    }
    else if (j > 1 && p[j - 1] == zeroOrMorePrevCharExpression)
    {
      matrix[i, j] = matrix[i, j - 2];
      if (s[i - 1] == p[j - 2] || p[j - 2] == singleCharExpression) matrix[i, j] = matrix[i, j] || matrix[i - 1, j];
    }

  return matrix[s.Length, p.Length];
}