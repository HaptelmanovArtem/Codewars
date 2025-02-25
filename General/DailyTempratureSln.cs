namespace General;

public partial class Solution
{
    // https://leetcode.com/problems/daily-temperatures/description/
    public int[] DailyTemperatures(int[] temperatures)
    {
        var iStack = new Stack<(int Index, int Temprature)>();
        var result = new int[temperatures.Length];

        for (var i = 0; i < temperatures.Length; i++)
        {
            while (iStack.TryPeek(out var peek) && peek.Temprature < temperatures[i])
            {
                iStack.Pop();
                result[peek.Index] = i - peek.Index;
            }

            iStack.Push((i, temperatures[i]));
        }

        return result;
    }
}