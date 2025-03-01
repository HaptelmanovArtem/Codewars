using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    /// <summary>
    /// https://leetcode.com/problems/container-with-most-water/description/
    /// </summary>
    public partial class Solution
    {
        public int MaxArea(int[] height)
        {
            var l = 0;
            var r = height.Length - 1;

            var maxArea = 0;

            while (l < r)
            {
                var minH = Math.Min(height[l], height[r]);
                var len = r - l;
                var area = minH * len;

                if (height[l] > height[r])
                    r--;
                else l++;

                maxArea = Math.Max(maxArea, area);
            }

            return maxArea;
        }
    }
}
