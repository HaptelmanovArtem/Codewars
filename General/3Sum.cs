using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    /// <summary>
    /// https://leetcode.com/problems/3sum/
    /// </summary>
    public partial class Solution
    {
        // BF sln
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var hashSet = new HashSet<Tuple<int, int, int>>();
            var result = new List<IList<int>>();
            Array.Sort(nums);

            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    for (var k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            var tp = Tuple.Create(nums[i], nums[j], nums[k]);
                            hashSet.Add(tp);
                        }
                    }
                }
            }

            foreach (var item in hashSet)
            {
                result.Add(new List<int>() { item.Item1, item.Item2, item.Item3 });
            }

            return result;
        }

        // With pointers (like 2 sum)
        public IList<IList<int>> ThreeSum_2I(int[] nums)
        {
            Array.Sort(nums);

            var result = new List<IList<int>>();

            for (var i = 0; i < nums.Length;i++)
            {
                if (nums[i] > 0)
                    break;

                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                var x = i + 1;
                var y = nums.Length - 1;

                while (x < y)
                {
                    var sum = nums[i] + nums[x] + nums[y];

                    if (sum > 0)
                        y--;
                    else if (sum < 0)
                        x++;
                    else
                    {
                        result.Add(new List<int> { nums[i], nums[x], nums[y] });

                        x++;
                        y--;
                        while (x < y && nums[x] == nums[x - 1])
                        {
                            x++;
                        }
                    }
                }
            }

            return result;
        }
    }
}
