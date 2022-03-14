using System;
using System.Collections.Generic;

namespace Tree
{
    public interface IIntegerTree: IAbstractTree<int>
    {
        List<List<int>> PathsWithGivenSum(int sum);

        IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum);
    }
}
