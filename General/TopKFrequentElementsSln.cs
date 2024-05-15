namespace General
{
    /// <summary>
    /// https://leetcode.com/problems/top-k-frequent-elements/
    /// </summary>
    public class TopKFrequentElementsSln
    {
        public int[] TopKFrequentFirstMind(int[] nums, int k)
        {
            var tempStorage = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (tempStorage.ContainsKey(nums[i])) 
                {
                    tempStorage[nums[i]]++;
                }
                else
                {
                    tempStorage[nums[i]] = 1;
                }
            }

            return tempStorage
                .OrderBy(k => k.Value)
                .Select(k => k.Key)
                .TakeLast(k)
                .ToArray();
        }

        public int[] TopKFrequent(int[] nums, int k)
        {
            var itemCount = new Dictionary<int, int>();
            var frequency = new List<int>[nums.Length + 1];

            for (int i = 0; i < nums.Length; i++)
            {
                if (itemCount.ContainsKey(nums[i]))
                {
                    itemCount[nums[i]]++;
                }
                else
                {
                    itemCount[nums[i]] = 1;
                }
            }

            foreach (var i in itemCount)
            {
                if (frequency[i.Value] is null)
                    frequency[i.Value] = new List<int> { i.Key };
                else
                    frequency[i.Value].Add(i.Key);
            }

            var result = new List<int>();

            for (var i = frequency.Length - 1; i >= 0 && result.Count < k; i--)
            {
                if (frequency[i] is null)
                    continue;

                if (frequency[i].Count > k)
                {
                    result.AddRange(frequency[i]);

                    return result.Take(k).ToArray();
                }

                if (frequency[i].Count + result.Count > k)
                {
                    result.AddRange(frequency[i].Take(k - frequency[i].Count));
                    return result.ToArray();
                }

                result.AddRange(frequency[i]);
            }

            return result.ToArray();
        }
    }
}
