using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingInterview
{
    public class LongestSubstring
    {
        //TITLE: Longest Substring.
        //DESCRIPTION: Longest Substring Without Repeating Characters. 
        //Given a string s, find the length of the longest substring without repeating characters.

        public static int LengthOfLongestSubstring(string s)
        {
            int index = 0;
            int letterCount = 0;
            int maxLengthSubstring = 0;
            Dictionary<char, int> seenDict = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (seenDict.ContainsKey(c) && letterCount <= seenDict[c])
                {
                    letterCount = seenDict[c] + 1;
                }
                else
                {
                    List<int> list = new List<int>() { maxLengthSubstring, index - letterCount + 1 };
                    maxLengthSubstring = list.Max();
                }
                seenDict[c] = index;
                index++;
            }
            return maxLengthSubstring;
        }
    }
}
