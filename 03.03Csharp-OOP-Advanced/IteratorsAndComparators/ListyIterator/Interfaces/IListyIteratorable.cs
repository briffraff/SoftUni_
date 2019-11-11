using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator.Interfaces
{
    public interface IListyIteratorable
    {
        bool Move();
        void Print();
        bool HasNext();

    }
}
