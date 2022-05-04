// See https://aka.ms/new-console-template for more information
// https://leetcode.com/problems/removing-minimum-and-maximum-from-array/

Console.WriteLine("Hello, World!");

MinimumDeletions(new[] {2, 10, 7, 5, 4, 1, 8, 6});

int MinimumDeletions(int[] nums)
{
  (int value, int index) maxElement = new(int.MinValue, 0);
  (int value, int index) minElement = new(int.MaxValue, 0);

  for (var i = 0; i < nums.Length; i++)
  {
    if (nums[i] > maxElement.value)
    {
      maxElement.value = nums[i];
      maxElement.index = i;
    }

    if (nums[i] <= minElement.value)
    {
      minElement.value = nums[i];
      minElement.index = i;
    }
  }

  var maxIndex = new[] {maxElement.index, minElement.index}.Max();
  var minIndex = new[] {maxElement.index, minElement.index}.Min();

  var fromBackToStart = nums.Length - minIndex;
  var fromStartToBack = maxIndex + 1;
  var fromDiffWays = minIndex + 1 + (nums.Length - maxIndex);

  return new[] {fromBackToStart, fromStartToBack, fromDiffWays}.Min();
}