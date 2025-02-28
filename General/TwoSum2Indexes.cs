namespace General
{
    public partial class Solution
    {
        /// <summary>
        /// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
        /// </summary>
        public int[] TwoSum(int[] numbers, int target)
        {
            var i = 0;
            var y = numbers.Length - 1;

            while (i < y)
            {
                var sum = numbers[i] + numbers[y];

                if (target == sum)
                {
                    return new int[] { i + 1, y + 1 };
                }

                if (target < sum)
                    y--;

                if (target > sum)
                    i++;
            }

            return new int[] { };
        }
    }
}
