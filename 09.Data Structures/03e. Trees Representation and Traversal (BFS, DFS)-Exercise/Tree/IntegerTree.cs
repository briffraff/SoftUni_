﻿using System.Collections;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public List<List<int>> PathsWithGivenSum(int sum)
        {
            List<List<int>> result = new List<List<int>>();

            var currentPath = new LinkedList<int>();
            currentPath.AddFirst(this.Key);

            int currentSum = this.Key;

            this.Dfs(this, result as List<List<int>>, currentPath, ref currentSum, sum);

            return result;
        }

        private void Dfs(
            Tree<int> subtree,
            List<List<int>> result,
            LinkedList<int> currentPath,
            ref int currentSum,
            int wantedSum)
        {
            foreach (var child in subtree.Children)
            {
                currentSum += child.Key;
                currentPath.AddLast(child.Key);
                this.Dfs(child, result, currentPath, ref currentSum, wantedSum);
            }

            if (currentSum == wantedSum)
            {
                result.Add(new List<int>(currentPath));
            }

            currentSum -= subtree.Key;
            currentPath.RemoveLast();
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }
    }
}
