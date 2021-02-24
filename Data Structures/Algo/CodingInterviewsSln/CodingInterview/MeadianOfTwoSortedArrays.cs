using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingInterview
{
    public class MeadianOfTwoSortedArrays
    {
        /*
         * Given two sorted arrays nums1 and nums2 of size m and n respectively, 
         * return the median of the two sorted arrays.
         * 
         * Follow up: 
         * The overall run time complexity should be O(log (m+n)).
         * 
         * Example 1: Input: nums1 = [1,3], nums2 = [2]
                      Output: 2.00000
                      Explanation: merged array = [1,2,3] and median is 2.
         * 
         * Example 2: Input: nums1 = [1,2], nums2 = [3,4]
                      Output: 2.50000
                      Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
         *
         * Example 3: Input: nums1 = [0,0], nums2 = [0,0]
                         Output: 0.00000
         *
         * Example 4: Input: nums1 = [], nums2 = [1]
                      Output: 1.00000

         *
         * Example 5: Input: nums1 = [2], nums2 = []
                      Output: 2.00000
         *
         * Constraints: nums1.length == m
            nums2.length == n
            0 <= m <= 1000
            0 <= n <= 1000
            1 <= m + n <= 2000
            -10**6 <= nums1[i], nums2[i] <= 10**6
         *
        */

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            // Finding the shortests arrary to begin partition
            if (nums1.Length > nums2.Length)
                return FindMedianSortedArrays(nums2, nums1);

            int lenNums1 = nums1.Length;
            int lenNums2 = nums2.Length;
            int low = 0;
            int high = lenNums1;

            while (low <= high)
            {
                int partitionNums1 = (low + high) / 2;
                int partitionNums2 = (lenNums1 + lenNums2 + 1) / 2 - partitionNums1;

                int maxLeftOfPartitionNums1 = partitionNums1 == 0 ? int.MinValue : nums1[partitionNums1 - 1];
                int ninRightOfPartitionNums1 = partitionNums1 == lenNums1 ? int.MaxValue : nums1[partitionNums1];

                int maxLeftOfPartitionNums2 = partitionNums2 == 0 ? int.MinValue : nums2[partitionNums2 - 1];
                int ninRightOfPartitionNums2 = partitionNums2 == lenNums2 ? int.MaxValue : nums2[partitionNums2];

                if (maxLeftOfPartitionNums1 <= ninRightOfPartitionNums2 &&
                    maxLeftOfPartitionNums2 <= ninRightOfPartitionNums1)
                {
                    List<int> maxList = new List<int>() { maxLeftOfPartitionNums1, maxLeftOfPartitionNums2 };
                    List<int> minList = new List<int>() { ninRightOfPartitionNums1, ninRightOfPartitionNums2 };
                    
                    if ((lenNums1 + lenNums2) % 2 == 0)
                        return (double)(maxList.Max() + minList.Min()) / 2;

                    return maxList.Max();
                }

                else if (maxLeftOfPartitionNums1 > ninRightOfPartitionNums2)
                { 
                    high = partitionNums1 - 1; 
                }

                else
                {
                    low = partitionNums1 + 1;
                }
            }
            throw new ArgumentException();
        }
    }
}
