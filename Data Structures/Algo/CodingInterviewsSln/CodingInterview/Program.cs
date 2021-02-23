using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingInterview
{
    public class MergeNames
    {
        public static string[] UniqueNames(string[] names1, string[] names2)
        {
            List<string> newNames = new List<string>();
            List<string> seenlist = new List<string>();
            foreach (string name1 in names1)
            {
                if (!seenlist.Contains(name1))
                {
                    newNames.Add(name1);
                    seenlist.Add(name1);
                }
            }

            foreach (string name2 in names2)
            {
                if (!seenlist.Contains(name2))
                {
                    newNames.Add(name2);
                    seenlist.Add(name2);
                }
                   
            }
            return newNames.ToArray();
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            string[] names1 = new string[] { "Ava", "Emma", "Olivia", "Olivia" , "Ava", "Olivia" };
            string[] names2 = new string[] { "Olivia", "Sophia", "Emma" };
            Console.WriteLine(string.Join(", ", MergeNames.UniqueNames(names1, names2))); // should print Ava, Emma, Olivia, Sophia

        }
    }

}
