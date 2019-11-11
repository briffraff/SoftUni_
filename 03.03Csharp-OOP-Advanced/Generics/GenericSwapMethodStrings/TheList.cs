using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class TheList<T>
    {
        private List<T> thisList;

        public TheList(List<T> thisList)
        {
            this.ThisList = thisList;
        }

        public List<T> ThisList
        {
            get { return thisList; }
            set { thisList = value; }
        }

        public void Swap(int index1, int index2)
        {
            T tempVar = this.ThisList[index1];
            this.thisList[index1] = thisList[index2];
            this.thisList[index2] = tempVar;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.ThisList)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
