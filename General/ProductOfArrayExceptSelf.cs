namespace General
{
    /// <summary>
    /// https://leetcode.com/problems/product-of-array-except-self/description/
    /// </summary>
    public class ProductOfArrayExceptSelf
    {
        // [1, 2, 3, 4]
        // pre [1, 1, 2, 6]
        // pos [24, 12, 4, 1]

        // prefix / posfix use by 1 array with o(1) memory 
        public int[] ProductExceptSelfV2(int[] nums)
        {
            var result = new int[nums.Length];

            int lastPrefix = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                result[i] = lastPrefix;
                lastPrefix = nums[i] * result[i];
            }

            int lastPostfix = nums[nums.Length - 1];
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (i == 0)
                {
                    result[i] = lastPostfix;
                    continue;
                }

                result[i] = lastPostfix * result[i];
                lastPostfix = nums[i] * lastPostfix;
            }

            return result;
        }

        // prefix / posfix solution
        public int[] ProductExceptSelf(int[] nums)
        {
            var result = new int[nums.Length];
            var postfix = new int[nums.Length];
            var prefix = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                if (i - 1 < 0)
                {
                    prefix[i] = nums[i];
                    continue;
                }

                prefix[i] = nums[i] * prefix[i - 1];
            }

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i + 1 >= nums.Length)
                {
                    postfix[i] = nums[i];
                    continue;
                }

                postfix[i] = nums[i] * postfix[i + 1];
            }

            for(int i = 0; i < nums.Length; i++)
            {
                if (i - 1 < 0)
                {
                    result[i] = postfix[i + 1];
                    continue;
                }

                if (i + 1 >= nums.Length)
                {
                    result[i] = prefix[i - 1];
                    continue;
                }

                result[i] = prefix[i - 1] * postfix[i + 1];
            }

            return result;
        }
    }
}