using System;
namespace Palindrome
{

    public class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode(T data = default(T), LinkedListNode<T> next = null)
        {
            Data = data;
            Next = next;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }


    public class LinkedList<T> : IList<T>
    {
        public LinkedListNode<T> Head { get; set; }
        public LinkedListNode<T> Tail { get; set; }


        public LinkedList()
        {
            Head = null;
            Tail = null;
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

        public bool IsEmpty => Head == null;

        public T First => Head.Data;

        public T Last => Tail.Data;

        public void AddLast(T item)
        {
            var newNode = new LinkedListNode<T>(item);

            // empty list
            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            // non empty list
            else
            {
                // Add new node after Tail
                Tail.Next = newNode;

                // Update Tail
                Tail = newNode;

            }
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
        }

        public int FirstIndexOf(T existingValue)
        {
            int index = 0;

            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Data.Equals(existingValue))
                {
                    return index;
                }
                index++;
                currentNode = currentNode.Next;
            }

            //for ( currentNode = Head, index=0; currentNode.Next != null; currentNode = currentNode.Next, index++)
            //{
            //    if (currentNode.Data.Equals(existingValue))
            //    {
            //        return index;
            //    }
            //}

            return -1;

        }

        public void InsertAfter(T newValue, T existingValue)
        {
            var currentNode = Head;



            while (currentNode != null)
            {
                if (currentNode.Data.Equals(existingValue))
                {
                    var node = new LinkedListNode<T>(newValue, currentNode.Next);
                    currentNode.Next = node;

                    if (currentNode == Tail)
                    {
                        Tail = node;
                    }

                    return;
                }

                currentNode = currentNode.Next;
            }

            this.AddLast(newValue);
        }

        public void InsertAt(T newValue, int index)
        {


            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                this.Prepend(newValue);

                return;
            }
            if (index == Length)
            {
                this.AddLast(newValue);
                return;
            }


            var currentNode = Head;
            LinkedListNode<T> prevNode = Head;
            for (var I = 0; I < Length; I++)
            {


                if (index == I)
                {
                    var node = new LinkedListNode<T>(newValue, currentNode);
                    prevNode.Next = node;
                    return;
                }

                prevNode = currentNode;
                currentNode = currentNode.Next;
            }
        }


        public void Prepend(T item)
        {

            LinkedListNode<T> newNode = new LinkedListNode<T>(item, Head);
            Head = newNode;
            if (this.Length == 1)
            {
                Tail = newNode;
            }

        }

        public void Remove(T value)
        {
            // If the list is empty, return immediately 
            if (IsEmpty)
            {
                return;
            }

            // Remove head
            if (Head.Data.Equals(value))
            {
                // Removing node from 1-element list
                if (Head == Tail)
                {
                    Tail = null;
                    Head = null;
                }
                else
                {
                    Head = Head.Next;
                }
                return;
            }

            // Remove non-head node

            var currentNode = Head;

            while (currentNode != null)
            {
                if (currentNode.Next != null && currentNode.Next.Data.Equals(value))
                {
                    var nodeToDelete = currentNode.Next;
                    if (nodeToDelete == Tail)
                    {
                        currentNode.Next = null;
                        Tail = currentNode;
                    }
                    else
                    {
                        // update previous node's next to skip the deleted node
                        currentNode.Next = currentNode.Next.Next;
                        nodeToDelete.Next = null;
                    }
                }

                currentNode = currentNode.Next;
            }

        }

        public void RemoveAt(int index)
        {


            if (index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (Length == 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                Head = Head.Next;
                return;
            }

            var currentNode = Head;
            LinkedListNode<T> prevNode = Head;
            for (var I = 0; I < Length - 1; I++)
            {
                if (I == Length - 2)
                {

                    currentNode.Next = currentNode.Next.Next;
                    Tail = currentNode;


                    return;
                }

                if (index == I)
                {
                    prevNode.Next = prevNode.Next.Next;
                    return;
                }

                prevNode = currentNode;
                currentNode = currentNode.Next;
            }
        }

        public IList<T> Reverse()
        {
            var result = new LinkedList<T>();

            var currentNode = Head;
            while (currentNode != null)
            {
                //Prepend every single one of them
                result.Prepend(currentNode.Data);

                currentNode = currentNode.Next;
            }

            return result;
        }

        public override string ToString()
        {
            string result = "[";
            var currentNode = Head;
            while (currentNode != null)
            {
                result += currentNode.Data;
                if (currentNode != Tail)
                {
                    result += ", ";
                }
                currentNode = currentNode.Next;
            }

            result += "]";

            return result;
        }

        public T KthToLast(int k)
        {
            var idNode = Head;
            var lastNode = Head;
            int i = 0;
            while (i != k)
            {

                lastNode = lastNode.Next;
                i++;
            }

            while (lastNode != Tail)
            {
                idNode = idNode.Next;
                lastNode = lastNode.Next;
            }

            return idNode.Data;
        }
    }

}
