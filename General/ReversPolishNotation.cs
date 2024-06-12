namespace General;

/// <summary>
/// https://leetcode.com/problems/evaluate-reverse-polish-notation/description/
/// </summary>
public class ReversPolishNotation
{
    public int EvalRPN(string[] tokens)
    {
        var stack = new Stack<int>();

        foreach (var token in tokens)
        {
            if (!IsOperation(token))
            {
                stack.Push(int.Parse(token));
                continue;
            }

            var x = stack.Pop();
            var y = stack.Pop();

            var opResult = MakeOperation(y, x, token);
            
            stack.Push(opResult);
        }

        return stack.Pop();
    }

    private bool IsOperation(string token) => token is "+" or "-" or "*" or "/";

    private int MakeOperation(int x, int y, string token)
    {
        return token switch
        {
            "+" => x + y,
            "-" => x - y,
            "*" => x * y,
            "/" => x / y,
        };
    }
}