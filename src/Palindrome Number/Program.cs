// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

IsPalindrome(11);

bool IsPalindrome(int x)
{
  var str = x.ToString();

  var startIndex = 0;
  var endIndex = str.Length - 1;

  while (startIndex <= endIndex)
  {
    if (str[startIndex] != str[endIndex])
      return false;

    startIndex++;
    endIndex--;
  }

  return true;
}