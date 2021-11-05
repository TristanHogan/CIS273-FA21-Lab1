using System;
namespace KthToLast
{

    public class DoublyLinkedListNode<T>
    {
        public T Data { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Prev { get; set; }

        public DoublyLinkedListNode(T data = default(T), DoublyLinkedListNode<T> prev = null, DoublyLinkedListNode < T> next = null)
        {
            Data = data;
            Prev = prev;
            Next = next;

        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }

    public class DoublyLinkedList<T>: IList<T>
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }

        public DoublyLinkedList()
        {
        }

        public int Length
        {
            get
            {
                int count = 0;
                var currentNode = Head;
                while (currentNode != null)
                {
                    count++;
                    currentNode = currentNode.Next;
                }

                return count;
            }
        }

        public bool IsEmpty => throw new NotImplementedException();

        public T First => throw new NotImplementedException();

        public T Last => throw new NotImplementedException();

        public void Append(T item)
        {
            throw new NotImplementedException();
        }

        public void Prepend(T item)
        {
            throw new NotImplementedException();
        }

        public void InsertAfter(T newValue, T existingValue)
        {
            throw new NotImplementedException();
        }

        public void InsertAt(T newValue, int index)
        {
            throw new NotImplementedException();
        }

        public int FirstIndexOf(T existingValue)
        {
            throw new NotImplementedException();
        }

        public void Remove(T value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public IList<T> Reverse()
        {
            throw new NotImplementedException();
        }

        public T KthToLast(int k)
        {
            int count = k;
            var currentNode = Tail;
            while (count != 0)
            {
                currentNode = currentNode.Prev;
                count--;

            }
            return currentNode.Data;
        }
    }
}
