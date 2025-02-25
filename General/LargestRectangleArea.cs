using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    public partial class Solution
    {
        // https://leetcode.com/problems/largest-rectangle-in-histogram/
        public int LargestRectangleAreaBroot(int[] heights) // with latency problem
        {
            var maxArea = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                var w = 1;
                var h = heights[i];

                var itselftArea = w * h;

                // right
                var rIndex = i + 1;
                for (int j = rIndex; j < heights.Length; j++)
                {
                    if (h > heights[j])
                        break;

                    rIndex++;
                }

                // left
                var lIndex = i - 1;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (j < 0)
                    {
                        lIndex = 0;
                        break;
                    }

                    if (h > heights[j])
                        break;

                    lIndex--;
                }

                rIndex--;
                lIndex++;

                var area = (rIndex - lIndex + 1) * h;

                maxArea = Math.Max(maxArea, area);
            }

            return maxArea;
        }

        public int LargestRectangleAreaStack(int[] heights) // stack solution
        {
            var maxArea = 0;
            var stack = new Stack<(int I, int H)>();

            for (int i = 0; i < heights.Length; i++)
            {
                var h = heights[i];
                var start = i;

                while (stack.TryPeek(out var tuple) && tuple.H > h)
                {
                    var pop = stack.Pop();

                    maxArea = Math.Max(maxArea, pop.H * (i - pop.I));
                    start = pop.I;
                }


                stack.Push((start, h));
            }

            while (stack.TryPop(out var x))
            {
                maxArea = Math.Max(maxArea, (heights.Length - x.I) * x.H);
            }

            return maxArea;
        }
    }
}
