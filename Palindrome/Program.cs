using System;
using System.Collections.Generic;

namespace Palindrome
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static bool IsPalindrome<T>(LinkedList<T> linkedList)
        {
            var reversedList = linkedList.Reverse();
            if (reversedList.ToString().Equals(linkedList.ToString()))
            {
                return true;
            }
            return false;
        }

    }
}
