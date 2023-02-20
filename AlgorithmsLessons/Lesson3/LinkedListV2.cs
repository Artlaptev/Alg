using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    public class LinkedListV2<T>
    {
        /// <summary>
        /// Головной узел
        /// </summary>
        private Node head;

        /// <summary>
        /// Ссылка на последний элемен
        /// </summary>
        private Node tail;

        public Node Head => head;
        public Node Tail => tail;

        /// <summary>
        /// Узел
        /// </summary>
        public class Node
        {
            /// <summary>
            /// Значение
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// Указатель на следующий элемент
            /// </summary>
            public Node Next { get; set; }

            /// <summary>
            /// Указатель на предыдущий элемент
            /// </summary>
            public Node Prev { get; set; }


            public Node(T value)
            {
                Value = value;
            }
        }

        public void addFirst(T value)
        {
            Node node= new Node(value);
            if (head != null)
            {
                node.Next = head;
                head.Prev= node;
            }
            else
            {
                tail = node;
            }
            head = node;
        }

        public void removeFirst()
        {
            if (head != null && head.Next != null)
            {
                head.Next.Prev = null;
                head = head.Next;
            }
            else
            {
                head = null;
                tail = null;
            }
        }


    }
}
