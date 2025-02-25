namespace General;

public partial class Solution
{
    // https://leetcode.com/problems/car-fleet/description/
    public int CarFleet(int target, int[] position, int[] speed)
    {
        var n = position.Length;
        var result = new List<int>();

        var positionAndSpeed = new List<(int Position, int Speed)>();

        for (var i = 0; i < n; i++)
            positionAndSpeed.Add((position[i], speed[i]));

        positionAndSpeed.Sort();

        var st = new Stack<double>();

        for (var i = n - 1; i >= 0; i--)
        {
            double arrivedIn = ((double)(target - positionAndSpeed[i].Position) / positionAndSpeed[i].Speed);

            while (st.TryPeek(out var arrivedInCloser))
            {
                if (arrivedInCloser >= arrivedIn)
                {
                    break;
                }
                else
                {
                    st.Push(arrivedIn);
                    break;
                }
            }

            if (st.Count == 0)
            {
                st.Push(arrivedIn);
            }
        }

        return st.Count;
    }
}