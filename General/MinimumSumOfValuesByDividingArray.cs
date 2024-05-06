namespace General
{

    /// <summary>
    /// https://leetcode.com/problems/minimum-sum-of-values-by-dividing-array/description/
    /// </summary>
    public static class MinimumSumOfValuesByDividingArray
    {
        static Dictionary<int, Dictionary<int, Dictionary<int, int>>> matrix = new();
        static int numsLength; 
        static int andValuesLength;
        static int maxValue = (int)1e9;
        static int bitSets = (1 << 30) - 1;

        public static int MinimumValueSum(int[] nums, int[] andValues)
        {
            numsLength = nums.Length;
            andValuesLength = andValues.Length;

            for (int i = 0; i < numsLength; i++)
            {
                matrix[i] = new Dictionary<int, Dictionary<int, int>>();
                for (int j = 0; j < andValuesLength; j++)
                {
                    matrix[i][j] = new Dictionary<int, int>();
                }
            }

            int ans = Calculate(nums, andValues, 0, 0, bitSets);

            return ans < maxValue ? ans : -1;
        }

        public static int MinimumValueSumV2(int[] nums, int[] andValues)
        {
            var andValuesIndex = 0;
            var accumulatedResult = -1;
            var prevNumsIndex = 0;
            var foundPaths = new Dictionary<int, int>();
            var continuationWhenIndex = new Dictionary<int, int>();
            var isCorrectForPrevious = true;

            while (andValuesIndex < andValues.Length)
            {
                var itemToCompare = andValues[andValuesIndex];
                var initialBitResult = int.MaxValue;
                var isResult = false;

                for (int i = prevNumsIndex; i < nums.Length; i++)
                {
                    initialBitResult &= nums[i];

                    if (continuationWhenIndex.ContainsKey(andValuesIndex) &&
                        continuationWhenIndex[andValuesIndex] > i)
                        continue;

                    if (initialBitResult == itemToCompare)
                    {
                        if (accumulatedResult == -1)
                            accumulatedResult = nums[i];
                        else
                            accumulatedResult += nums[i];

                        prevNumsIndex = i + 1;
                        isResult = true;
                        foundPaths[andValuesIndex] = prevNumsIndex;
                        break;
                    }
                }

                andValuesIndex++;

                // if we doesnt find any subarray for 1st andValues.
                if (prevNumsIndex == 0)
                    return accumulatedResult;

                if (!isResult && prevNumsIndex < nums.Length)
                {
                    isCorrectForPrevious = false;
                    Reinitial();
                    continue;
                }

                // in case when we full check nums
                if (prevNumsIndex == nums.Length)
                {
                    continue;
                }

                if (andValuesIndex >= andValues.Length &&
                    prevNumsIndex < nums.Length)
                {
                    Reinitial();
                }    

                if (!isCorrectForPrevious)
                    Reinitial();
            }

            return accumulatedResult;

            void Reinitial()
            {
                accumulatedResult = -1;
                andValuesIndex = 0;

                foreach (var x in foundPaths)
                {
                    continuationWhenIndex[x.Key] = x.Value;
                }
                foundPaths = new Dictionary<int, int>();

                prevNumsIndex = 0;
            }
        }

        private static int Calculate(int[] nums, int[] andValues, int i, int j, int mask)
        {
            if (i == numsLength && j == andValuesLength)
                return 0;
            
            if (i == numsLength || j == andValuesLength)
                return maxValue;

            if (matrix[i][j] != null && matrix[i][j].ContainsKey(mask))
                return matrix[i][j][mask];

            mask &= nums[i];

            // If the updated mask is less than the corresponding and_value, it's not possible to get the expected value
            // because the AND value can only DECRESE if we add more numbers to it
            if (mask < andValues[j])
                return maxValue;

            var split = maxValue;
            if (mask == andValues[j])
                // Add nums[n1] to the sum and increment both n1 and m1
                split = nums[i] + Calculate(nums, andValues, i + 1, j + 1, bitSets);

            // find out the case when we don't split
            // Increment n1 to move to the next element in nums
            var notSplit = Calculate(nums, andValues, i + 1, j, mask);

            // Return the minimum of two cases
            var result = Math.Min(notSplit, split);
            if (matrix[i][j] == null)
            {
                matrix[i][j] = new Dictionary<int, int>();
            }
            matrix[i][j][mask] = result;
            return result;
        }
    }
}