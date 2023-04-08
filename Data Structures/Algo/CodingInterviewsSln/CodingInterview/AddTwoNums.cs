using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterview
{
    /*
     *     You are given two non-empty linked lists representing two non-negative integers.
           The digits are stored in reverse order, and each of their nodes contains a single digit.
           Add the two numbers and return the sum as a linked list. \n " +
           You may assume the two numbers do not contain any leading zero, except the number 0 itself.
     * 
    */



    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int data)
        {
            int val = data;
            ListNode next = null;
        }
    }


    public class AddTwoNumbers
    {
        public ListNode Runn(ListNode l1, ListNode l2)
        {

            int carry = 0;
            ListNode newList = new ListNode(0);
            ListNode temp = newList;
            int totalSum = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                if (l1 != null)
                {
                    totalSum += l1.val;
                    l1 = l1.next;
                }


                if (l2 != null)
                {
                    totalSum += l2.val;
                    l2 = l2.next;
                }

                totalSum += carry;
                carry = totalSum / 10;
                temp.next = new ListNode(totalSum % 10);
                totalSum = 0;
                temp = temp.next;
            }
            return newList.next;
        }
    }

}
