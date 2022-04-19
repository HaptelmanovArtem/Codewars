using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Median_of_Two_Sorted_Arrays
{
  class Program
  {
    static void Main(string[] args)
    {
      FindMedianSortedArrays(new[] {2}, new int[]{});
    }

    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
      var length = nums1.Length + nums2.Length;

      var isEven = length % 2 == 0;
      
      var array = new int[length];

      var i = 0;
      var j = 0;
      var k = 0;
      
      while (k != length)
      {
        int? iItem = null;
        int? jItem = null;
        
        if (i < nums1.Length)
        {
          iItem = nums1[i];
        }

        if (j < nums2.Length)
        {
          jItem = nums2[j];
        }

        if (iItem <= jItem || !jItem.HasValue)
        {
          array[k] = iItem.Value;
          i++;
        }
        else
        {
          array[k] = jItem.Value;
          j++;
        }

        k++;
      }

      if (!isEven) 
        return array[length / 2];
      
      var firstIndex = (length / 2) - 1;
      var secondIndex = length / 2;

      return (double) (array[firstIndex] + array[secondIndex]) / 2;

    }
  }
}