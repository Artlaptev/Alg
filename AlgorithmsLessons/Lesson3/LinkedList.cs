using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    /// <summary>
    /// Однонаправленный связанный список
    /// </summary>
    public class LinkedList<T>
    {

        /// <summary>
        /// Головной узел
        /// </summary>
        private Node head;

        public Node Head => head;

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

            public Node(T value)
            {
                Value = value;
            }
        }

        /// <summary>
        /// Добавить новый элемент в начало связанного списка
        /// </summary>
        /// <param name="value"></param>
        public void AddFirst(T value)
        {
            Node node = new Node(value);
            if (head != null)
                node.Next = head;
            head = node;
        }

        /// <summary>
        /// Удалить первый элемент связанного списка
        /// </summary>
        public void RemoveFirst()
        {
            if (head != null)
                head = head.Next;
        }

        /// <summary>
        /// Поиск элемента в связанном списке
        /// </summary>
        /// <param name="value"></param>
        /// <param name="equalityComparer"></param>
        /// <returns></returns>
        public bool Contains(T value, IEqualityComparer<T>? equalityComparer = null)
        {
            Node node = head;
            while (node != null)
            {
                if (equalityComparer?.Equals(node.Value, value) == true || node.Value.Equals(value))
                {
                    return true;
                }
                node = node.Next;
            }
            return false;
        }

        /// <summary>
        /// Сортировка элементов (выбором)
        /// </summary>
        public void DirectSort(IComparer<T> comparer)
        {
            Node node = head;
            while (node != null)
            {
                Node minValueNode = node;
                Node node2 = node.Next;
                while (node2 != null)
                {
                    if (comparer.Compare(minValueNode.Value, node2.Value) > 0)
                    {
                        minValueNode = node2;
                    }
                    node2 = node2.Next;
                }

                if (node != minValueNode)
                {
                    T buf = node.Value;
                    node.Value = minValueNode.Value;
                    minValueNode.Value = buf;
                }

                node = node.Next;
            }
        }

        /// <summary>
        /// Добавить элемент в конец связанного списка
        /// </summary>
        /// <param name="value"></param>
        public void AddLast(T value)
        {
            Node node = new Node(value);
            if (head == null)
            {
                head = node;
            }
            else
            {
                Node last = head;
                while (last.Next != null)
                {
                    last = last.Next;
                }
                last.Next = node;
            }
        }

        /// <summary>
        /// Удалить последний элемент связанного списка
        /// </summary>
        public void RemoveLast()
        {
            if (head == null)
                return;
            Node node = head;
            while (node.Next != null)
            {
                if (node.Next.Next == null)
                {
                    node.Next = null;
                    return;
                }
                node = node.Next;
            }
            head = null;
        }
        public void Reverse()
        {
            Node nextNode = head.Next;
            Node currentNode = head;
            Node prevNode = null;

            currentNode.Next = null;

            prevNode=currentNode;
            currentNode = nextNode;
            nextNode = currentNode.Next;
            

            while(currentNode.Next!=null)
            {
                currentNode.Next=prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
                nextNode = currentNode.Next;
            }
            head = currentNode;
            head.Next = prevNode;

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node node = head;
            
            while(node.Next!=null)
            {
                sb.Append(node.Value.ToString());
                node = node.Next;
            }
            sb.Append(node.Value.ToString());
            return sb.ToString();
        }

    }

}
