using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    public class Stack<T>
    {
        private T[] arr;
        int size;
        int pos;

        public Stack(int size = 1)
        {
            pos = 0;
            this.size = size;
            arr = new T[size];
        }

        public void push(T key)
        {
            if (size == pos)
            {
                throw new Exception("Overflow. Please increase stack size and run program again."); 
            }

            arr[pos++] = key;
        }

        public T top()
        {
            return arr[pos - 1];
        }

        public bool empty()
        {
            return (pos == 0);
        }

        public void pop()
        {
            pos--;
        }
    }
}
