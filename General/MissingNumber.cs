namespace General;

/// <summary>
/// https://leetcode.com/problems/missing-number/description/
/// </summary>
public class MissingNumber
{
    public int MissingNumber_sort(int[] nums)
    {
        var missing = 0;
        
        Array.Sort(nums);

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != missing)
            {
                return missing;
            }
            
            missing++;
        }
        
        return missing;
    }
    
    public int MissingNumber_xor(int[] nums)
    {
        var n = nums.Length;
        var missing = 0;

        for (int i = 1; i <= n; i++)
        {
            missing ^= i;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            missing ^= nums[i];
        }
        
        return missing;
    }
    
    public int MissingNumber_Sum(int[] nums)
    {
        var n = nums.Length;
        var sum = n * (n + 1) / 2;
        
        return sum - nums.Sum();
    }
}