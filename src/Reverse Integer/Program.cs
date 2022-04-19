// See https://aka.ms/new-console-template for more information

using System.Text;

Reverse(-2147483648);

int Reverse(int x)
{
  var st = x.ToString().Reverse().ToList();

  var result = new StringBuilder();

  for(var i = 0; i < st.Count; i++)
  {
    if (i == 0 && st[i] == '0')
    {
      continue;
    }
    
    if (st[i] == '-')
    {
      result.Insert(0, st[i]);
      continue;
    }

    result.Append(st[i]);
  }

  var res = result.ToString();
  
  var reversed = string.IsNullOrWhiteSpace(res) ? 0 : Convert.ToInt64(res);

  if (reversed > Int32.MaxValue || reversed < Int32.MinValue)
  {
    return 0;
  }

  return (int)reversed;
}