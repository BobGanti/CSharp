using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingInterview
{
    public class LongestSubstring
    {
        public static string Title = "Longest Substring";

        public string Description = "Longest Substring Without Repeating Characters" +
                "Given a string s, find the length of the longest substring without repeating characters.";
        
        private static Dictionary<int, string> examples;

        private static Dictionary<int, string> constraints;

        public static Dictionary<int, string> Examples()
        {
            examples = new Dictionary<int, string>();
            examples.Add(1, "");
            examples.Add(2, "");
            examples.Add(3, "");

            return examples;
        }

        public static Dictionary<int, string> Contraints()
        {
            constraints = new Dictionary<int, string>();
            constraints.Add(1, "0 <= s.length <= 5 * 10**4");
            constraints.Add(2, "s consists of English letters, digits, symbols and spaces Accepted");

            return constraints;
        }

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
