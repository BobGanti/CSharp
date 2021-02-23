using System;
using System.Collections.Generic;

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

    public class AddTwoNumbers
    {
        public static string Question() 
        {
            return
            "You are given two non-empty linked lists representing two non-negative integers. " +
           "The digits are stored in reverse order, and each of their nodes contains a single digit. " +
           "Add the two numbers and return the sum as a linked list. \n " +
           "You may assume the two numbers do not contain any leading zero, except the number 0 itself.";
        }
    }

    class Program
    {
        //public static void Main(string[] args)
        //{
        //    string[] names1 = new string[] { "Ava", "Emma", "Olivia", "Olivia" , "Ava", "Olivia" };
        //    string[] names2 = new string[] { "Olivia", "Sophia", "Emma" };
        //    Console.WriteLine(string.Join(", ", MergeNames.UniqueNames(names1, names2))); // should print Ava, Emma, Olivia, Sophia

        //}

        public static void Main(string[] args)
        {
            Console.WriteLine(AddTwoNumbers.Question());
        }
    }

}
