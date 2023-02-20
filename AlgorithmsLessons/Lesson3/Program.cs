using System.Collections.Generic;

namespace Lesson3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Student> linkedList = new LinkedList<Student>();



            LinkedList<int> linked = new LinkedList<int>();
            linked.AddLast(1);
            linked.AddLast(2);
            linked.AddLast(3);
            linked.AddLast(4);
            linked.AddLast(5);
            linked.AddLast(6);

            linked.Reverse();
            Console.WriteLine(linked);
            


            var middleNode = MiddleNode(linked.Head);
        }

        public static LinkedList<int>.Node MiddleNode(LinkedList<int>.Node head)
        {
            int counter = 1;

            var node = head;
            while (node.Next != null)
            {
                counter++;
                node = node.Next; 
            }

            counter = counter / 2 + 1;

            node = head;
            for (int i = 0; i < counter - 1; i++)
            {
                node = node.Next;
            }
            return node;
        }

        static void PrintStudents(LinkedList<Student> linkedList)
        {
            Console.WriteLine();
            var node = linkedList.Head;
            while(node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
            Console.WriteLine();

        }
    }
}