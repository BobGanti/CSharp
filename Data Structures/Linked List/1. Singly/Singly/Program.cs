using System;
using System.Collections.Generic;
using System.Linq;

namespace Singly
{
    public class Node
    {
        public int data;
        public Node next;
        public Node(int value)
        {
            data = value;
            next = null;
        }
    }

    public class SinglyList
    {
        public Node head;
        public Node tail;
        public SinglyList()
        {
            head = null;
            tail = null;
        }

        public void PrintList()
        {
            if (IsEmptyList())
            {
                Console.WriteLine("The list is empty!");
            }
            Node current = head;
            while (current != null)
            {
                Console.Write("[" + current.data + "]-> ");
                current = current.next;
            }

        }

        public void AddFirst(int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                Node temp = newNode;
                temp.next = head;
                head = temp;
            }
        }

        public void AddLast(int data)
        {
            var newNode = new Node(data);
            if (head == null)
                head = tail = newNode;

            else
            {
                tail.next = newNode;
                tail = newNode;

            }
        }

        public void AddBefore(int dataAfter, int data)
        {
            if (IsEmptyList())
                return;

            if (head.data == dataAfter)
            {
                AddFirst(data);
            }

            else
            {
                Node current = head;
                while (current != null)
                {
                    var newNode = new Node(data);
                    if (current.data == dataAfter)
                    {
                        Node prev = GetPrevious(current);
                        newNode.next = current;
                        prev.next = newNode;
                    }
                    current = current.next;
                }
            }
        }

        public void AddAfter(int dataBefore, int data)
        {
            if (IsEmptyList())
                return;

            if (head == tail && head.data == dataBefore)
            {
                Node newNode = new Node(data);
                head.next = newNode;
                newNode.next = null;
                tail = newNode;
            }
            else
            {
                Node current = head;
                var newNode = new Node(data);
                while (current != null)
                {
                    if (current.data.Equals(dataBefore))
                    {
                        newNode.next = current.next;
                        current.next = newNode;
                    }
                    current = current.next;
                }
            }

        }

        public void RemoveFirst()
        {
            if (head == tail)
                head = tail = null;
            else
            {
                Node temp = head.next;
                head.next = null;
                head = temp;
            }
        }

        public void RemoveLast()
        {
            if (head == tail)
                head = tail = null;
            else
            {
                Node prev = GetPrevious(tail);
                prev.next = null;
                tail = prev;
            }
        }

        // Removes data from unknow position
        public void RemoveData(int data)
        {
            if (head == tail && head.data == data)
                RemoveFirst();
            else
            {
                if (tail.data == data)
                {
                    RemoveLast();
                }
                else
                {
                    Node current = head;
                    while (current != null)
                    {
                        if (current.data == data)
                        {
                            break;
                        }
                        current = current.next;
                    }
                    Node prev = GetPrevious(current);
                    Node nxt = current.next;
                    current.next = null;
                    prev.next = nxt;

                }
            }
        }

        public void GetPairsWithSum(int target)
        {
            var dict = new Dictionary<int, int>();
            Node p1 = head;
            Node p2 = null;
            while (p1 != null)
            {
                p2 = p1.next;
                while (p2 != null)
                {
                    if (p1.data + p2.data == target)
                    {
                        dict.Add(p1.data, p2.data);
                    }
                    p2 = p2.next;
                }
                p1 = p1.next;
            }
            foreach (KeyValuePair<int, int> pair in dict)
            {
                Console.WriteLine("({0}, {1})", pair.Key, pair.Value);
            }
        }

        // Returns the index of 1st occurrence of data in list
        public int GetIndexOf(int data)
        {
            int index = 0;
            var curr = head;
            while (curr != null)
            {
                if (curr.data == data)
                    return index;
                curr = curr.next;
                index++;
            }
            return -1;
        }

        public int GetLength()
        {
            int count = 0;
            Node curr = head;
            while (curr != null)
            {
                count++;
                curr = curr.next;
            }
            return count;
        }

        public bool Contains(int data)
        {
            return GetIndexOf(data) != -1;
        }

        private Node GetPrevious(Node node)
        {
            Node curr = head;
            while (curr.next != null)
            {
                if (curr.next.Equals(node))
                    break;
                curr = curr.next;
            }
            return curr;
        }

        private bool IsEmptyList()
        {
            return head == null;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            SinglyList list = new SinglyList();

            list.AddLast(20);
            list.AddLast(30);
            list.AddLast(40);
            list.AddLast(50);
            list.AddAfter(40, 60);
            list.AddFirst(10);

            list.PrintList();
            Console.WriteLine();
            list.GetPairsWithSum(60);
            Console.WriteLine();
            Console.WriteLine("Lenght: " + list.GetLength());

            Console.WriteLine("\n\n");
            Console.WriteLine("Head: " + list.head.data);
            Console.WriteLine("Head.Next: " + list.head.next.data);
            Console.WriteLine("Tail: " + list.tail.data);
            Console.WriteLine("Tail.Next: " + list.tail.next);
        }
    }
}