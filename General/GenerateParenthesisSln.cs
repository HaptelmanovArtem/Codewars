using System.Text;

namespace General;

/// <summary>
/// https://leetcode.com/problems/generate-parentheses/description/
/// </summary>
public class GenerateParenthesisSln
{
    private const char OPEN = '(';
    private const char CLOSE = ')';

    private StringBuilder _sb = new();

    // sb sln
    public IList<string> GenerateParenthesis(int n)
    {
        if (n == 0)
            return new List<string>();

        var result = new List<string>();

        GenerateNew(result, numberOfOpened: 0, numberOfClosed: 0, n, index: 0);

        return result;
    }
    
    private void GenerateNew(List<string> result, int numberOfOpened, int numberOfClosed, int n, int index)
    {
        if (numberOfOpened == n &&
            numberOfClosed == n)
        {
            result.Add(_sb.ToString());
            return;
        }

        if (numberOfOpened < n)
        {
            _sb.Append(OPEN);
            GenerateNew(result, numberOfOpened + 1, numberOfClosed ,n, index + 1);
            _sb.Remove(index, 1);
        }

        if (numberOfClosed < numberOfOpened)
        {
            _sb.Append(CLOSE);
            GenerateNew(result, numberOfOpened, numberOfClosed + 1 ,n, index + 1);
            _sb.Remove(index, 1);
        }
    }
    
    /*private char[] _arr;

    // array sln

    public IList<string> GenerateParenthesis(int n)
    {
        if (n == 0)
            return new List<string>();

        _arr = new char[n * 2];

        var result = new List<string>();

        GenerateNew(result, numberOfOpened: 0, numberOfClosed: 0, n, index: 0);

        return result;
    }

    private void GenerateNew(List<string> result, int numberOfOpened, int numberOfClosed, int n, int index)
    {
        if (numberOfOpened == n &&
            numberOfClosed == n)
        {
            result.Add(new string(_arr));
            return;
        }

        if (numberOfOpened < n)
        {
            _arr[index] = OPEN;
            GenerateNew(result, numberOfOpened + 1, numberOfClosed ,n, index + 1);
        }

        if (numberOfClosed < numberOfOpened)
        {
            _arr[index] = CLOSE;
            GenerateNew(result, numberOfOpened, numberOfClosed + 1 ,n, index + 1);
        }
    }*/

    /*private readonly Stack<char> _stack = new();

    // stack sln
    public IList<string> GenerateParenthesis(int n)
    {
        if (n == 0)
            return new List<string>();

        var result = new List<string>();

        GenerateNew(result, numberOfOpened: 0, numberOfClosed: 0, n);

        return result;
    }

    private void GenerateNew(List<string> result, int numberOfOpened, int numberOfClosed, int n)
    {
        if (numberOfOpened == n &&
            numberOfClosed == n)
        {
            result.Add(string.Join("", _stack.Reverse().Select(k => k)));
            return;
        }

        if (numberOfOpened < n)
        {
            _stack.Push(OPEN);
            GenerateNew(result, numberOfOpened + 1, numberOfClosed ,n);
            _stack.Pop();
        }

        if (numberOfClosed < numberOfOpened)
        {
            _stack.Push(CLOSE);
            GenerateNew(result, numberOfOpened, numberOfClosed + 1 ,n);
            _stack.Pop();
        }
    }*/
}