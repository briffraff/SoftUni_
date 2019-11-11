using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ListyIterator.Interfaces;

namespace ListyIterator
{
    public class ListyIterator<T> : IListyIteratorable, IEnumerable<T>
    {
        //fields
        private T[] elements;
        private int index;

        //ctor
        public ListyIterator(T[] elements)
        {
            this.elements = elements;
            this.index = 0;
        }

        //props
        public T[] Elements
        {
            get { return elements; }
            set { elements = value; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }


        //Meths
        public bool Move()
        {
            if (this.index < this.Elements.Length - 1)
            {
                this.index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.index < this.Elements.Length - 1)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            string currentElement = this.Elements[this.Index].ToString();

            if (this.Elements.Length != 0)
            {
                Console.WriteLine(currentElement);
                return;
            }

            throw new InvalidOperationException("Invalid Operation!");
        }

        //===============================ADDS================================
        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", this.Elements));
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.Elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
