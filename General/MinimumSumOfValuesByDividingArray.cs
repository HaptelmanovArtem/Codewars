using System.Threading.Tasks;

namespace General
{

    /// <summary>
    /// https://leetcode.com/problems/minimum-sum-of-values-by-dividing-array/description/
    /// </summary>
    public static class MinimumSumOfValuesByDividingArray
    {
        static int maxValue = (int)1e9;
        static Dictionary<int, int>[,] matrix;

        public static int MinimumValueSum(int[] nums, int[] andValues)
        {
            matrix = new Dictionary<int, int>[nums.Length, andValues.Length];

            var item = Move(nums, andValues, 0, 0, int.MaxValue);

            return item >= maxValue ? -1 : item;
        }

        private static int Move(
            int[] nums,
            int[] andValues,
            int i,
            int j,
            int accumulatedValue)
        {
            if (i == nums.Length && j == andValues.Length)
                return 0;

            if (i == nums.Length || j == andValues.Length)
                return maxValue;

            if (matrix[i, j] != null && matrix[i, j].ContainsKey(accumulatedValue))
                return matrix[i, j][accumulatedValue];

            accumulatedValue &= nums[i];

            if (accumulatedValue < andValues[j])
                return maxValue;

            var splitSum = maxValue;
            if (accumulatedValue == andValues[j])
            {
                splitSum = nums[i] + Move(nums, andValues, i + 1, j + 1, int.MaxValue);
            }

            var notSplitSum = Move(nums, andValues, i + 1, j, accumulatedValue);

            var result = Math.Min(splitSum, notSplitSum);

            if (matrix[i, j] == null)
                matrix[i, j] = new Dictionary<int, int>();

            matrix[i, j][accumulatedValue] = result;

            return result;
        }
    }
}