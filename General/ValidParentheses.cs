namespace General;

/// <summary>
/// https://leetcode.com/problems/valid-parentheses/description/
/// </summary>
public class ValidParentheses
{
    private const char OpenBracket = '(';
    private const char CloseBracket = ')';
    
    private const char OpenJSBracket = '{';
    private const char CloseJSBracket = '}';
    
    private const char OpenSqBracket = '[';
    private const char CloseSqBracket = ']';

    public bool IsValid(string s)
    {
        if (s.Length % 2 != 0)
            return false;

        var st = new Stack<char>();

        foreach (var item in s)
        {
            if (item is OpenBracket or OpenJSBracket or OpenSqBracket)
            {
                st.Push(item);
            }
            else
            {
                if (!st.TryPop(out var popItem))
                    return false;

                if (item is CloseBracket && popItem is not OpenBracket)
                    return false;
                
                if (item is CloseSqBracket && popItem is not OpenSqBracket)
                    return false;
                
                if (item is CloseJSBracket && popItem is not OpenJSBracket)
                    return false;
            }
        }

        return st.Count == 0;
    }
}