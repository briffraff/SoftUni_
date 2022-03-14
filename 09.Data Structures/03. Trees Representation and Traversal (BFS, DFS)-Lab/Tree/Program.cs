namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {

            Tree<int> tree1 = new Tree<int>(5, new Tree<int>(10), new Tree<int>(200));
            var tree = tree1;
        }
    }
}
