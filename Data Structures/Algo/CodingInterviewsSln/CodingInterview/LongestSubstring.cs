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
            int starting = 0;
            int maxlength = 0;
            Dictionary<char, int> seenDict = new Dictionary<char, int>();

            int index = 0;
            foreach (char c in s)
            {
                if (seenDict.ContainsKey(c) && starting <= seenDict[c])
                {
                    starting = seenDict[c] + 1;
                }
                else
                {
                    List<int> list = new List<int>() { maxlength, index - starting + 1 };
                    maxlength = list.Max();
                }
                seenDict[c] = index;
                index++;
            }
            return maxlength;
        }
    }
}
