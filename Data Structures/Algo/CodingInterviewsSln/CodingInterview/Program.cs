using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingInterview
{

    class Program
    {
        public static void Main(string[] args)
        {
            //MergeNames.Print();

            //Console.WriteLine(LongestSubstring.LengthOfLongestSubstring("abcabcbb"));

            int[] nums1 = { 1, 3 };
            int[] nums2 = { 2 };
            Console.WriteLine(new MeadianOfTwoSortedArrays().FindMedianSortedArrays(nums1, nums2));
        }

    }

}
