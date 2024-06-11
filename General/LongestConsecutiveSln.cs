namespace General;

/// <summary>
/// https://leetcode.com/problems/longest-consecutive-sequence/
/// </summary>
public class LongestConsecutiveSln
{
    public int LongestConsecutiveNaiveWithSort(int[] nums)
    {
        if (nums.Length == 0)
            return 0;
        
        Array.Sort(nums);

        int result = 1;
        int tempResult = 1;
        
        for (int i = 1; i < nums.Length; i++)
        {
            var difference = nums[i] - nums[i - 1];
            
            if (difference == 1)
            {
                tempResult += 1;

                if (tempResult > result)
                    result = tempResult;
            }
            else if (difference == 0)
            {
                continue;
            }
            else
            {
                tempResult = 1;
            }
        }

        return result;
    }
    
    public int LongestConsecutiveWithoutSorting(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        var set = new HashSet<int>(nums);
        int maxSeq = 0;

        foreach (var item in set)
        {
            if (set.Contains(item - 1))
            {
                continue;
            }

            int temp = 1;
            while (set.Contains(item + temp))
            {
                temp++;
            }

            maxSeq = Math.Max(maxSeq, temp);
        }
        
        return maxSeq;
    }
}