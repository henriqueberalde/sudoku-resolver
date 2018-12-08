using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Library.Entities
{
    public class ResolverItem
    {
        public int Value { get; set; }
        public List<int> PossibleValues { get; set; }

        public ResolverItem Intersect(ResolverItem second)
        {
            var list1 = PossibleValues.ToList();
            var list2 = second.PossibleValues.ToList();

            return new ResolverItem { PossibleValues = list1.Intersect(list2).ToList() };
        }
    }
}
