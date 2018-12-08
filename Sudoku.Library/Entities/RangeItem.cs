using System.Collections.Generic;

namespace Sudoku.Library.Entities
{
    public class RangeItem
    {
        public RangeItem(int row, int column)
        {
            Row = row;
            Column = column;
            PossibleValues = new List<int>();
        }

        public RangeItem(int row, int column, int value)
        {
            Row = row;
            Column = column;
            Value = value;
            PossibleValues = new List<int>();
        }

        public int Row { get; set; }
        public int Column { get; set; }
        public int Value { get; set; }
        public List<int> PossibleValues { get; set; }
    }
}
