using System.Numerics;

namespace General
{
    /// <summary>
    /// https://leetcode.com/problems/contains-duplicate/
    /// </summary>
    public class ContainsDuplicateSln
    {
        // not good for memory but okay for perfomance
        public bool ContainsDuplicateWithHash(int[] nums)
        {
            var hashSet = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!hashSet.Add(nums[i]))
                {
                    return true;
                }
            }

            return false;
        }

        // loop inside loop
        public bool ContainsDuplicateWithoutHashOn2(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool ContainsDuplicateSort(int[] nums)
        {
            Array.Sort(nums);

            for (var i = 0; i < nums.Length; i++)
            {
                if (i + 1 < nums.Length && nums[i] == nums[i + 1])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
