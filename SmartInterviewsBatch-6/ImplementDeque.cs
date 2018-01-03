using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInterviewsBatch_6
{
    public class ImplementDeque : ISolution
    {
        public override void Solve()
        {
            int t = ReadInt();
            Deque<sbyte> deque = new Deque<sbyte>();
            while (t-- > 0) {
                string operation = ReadString();
                if (operation.Contains("pop"))
                {
                    if (operation.Split('_')[1].Contains("front"))
                    {
                        output.AppendLine(deque.IsEmpty() ? "Empty" : deque.PopFront().ToString());
                    }
                    else {
                        output.AppendLine(deque.IsEmpty() ? "Empty" : deque.PopBack().ToString());
                    }
                }
                else {
                    sbyte data = sbyte.Parse(operation.Split(' ')[1]);
                    if (operation.Contains("front"))
                    {
                        deque.PushFront(data);
                    }
                    else {
                        deque.PushBack(data);
                    }
                }
            }
            Console.Write(output);
        }
    }

    public class Deque<T> {
        Node<T> head;
        Node<T> tail;

        public Deque() {
            head = new Node<T>();
            tail = new Node<T>();
            head.next = tail;
            head.prev = null;
            tail.next = null;
            tail.prev = head;
        }

        public void PushFront(T data) {
            Node<T> newNode = new Node<T>(data);
            newNode.next = head.next;
            head.next.prev = newNode;
            head.next = newNode;
            newNode.prev = head;
            head.prev = null;
        }

        public void PushBack(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.prev = tail.prev;
            tail.prev.next = newNode;
            newNode.next = tail;
            tail.prev = newNode;
            tail.next = null;
        }

        public T PopFront() {
            Node<T> poppedElement = head.next;
            head.next = poppedElement.next;
            poppedElement.next.prev = head;
            poppedElement.prev = null;
            poppedElement.next = null;
            return poppedElement.data;
        }

        public T PopBack()
        {
            Node<T> poppedElement = tail.prev;
            poppedElement.prev.next = tail;
            tail.prev = poppedElement.prev;
            poppedElement.prev = poppedElement.next = null;
            return poppedElement.data;
        }

        public bool IsEmpty() {
            return head.next == tail && tail.prev == head;
        }
    }

    public class Node<T> {
        public T data;
        public Node<T> prev;
        public Node<T> next;

        public Node(T data) {
            this.data = data;
            next = prev = null;
        }

        public Node() {
            prev = next = null;
        }
    }
}
