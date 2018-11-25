using System;
using System.Collections.Generic;
using static Sudoku.Library.SudokuValidator;

namespace Sudoku.Library
{
    public static class SudokuUtil
    {
        public static List<SudokuRangeItem> GetRange(RangeType type, int index)
        {
            var result = new List<SudokuRangeItem>();
            int aBegin = 0;
            int aEnd = 0;
            int bBegin = 0;
            int bEnd = 0;

            switch (type)
            {
                case RangeType.Row:
                    aBegin = index;
                    aEnd = index + 1;
                    bBegin = 0;
                    bEnd = 9;
                    break;
                case RangeType.Column:
                    aBegin = 0;
                    aEnd = 9;
                    bBegin = index;
                    bEnd = index + 1;
                    break;
                case RangeType.Block:

                    var firstBlockIndex = new int[9] {0,0,0,3,3,3,6,6,6};

                    aBegin = firstBlockIndex[index];
                    aEnd = firstBlockIndex[index] + 3;
                    bBegin = (index - firstBlockIndex[index]) * 3;
                    bEnd = bBegin + 3;

                    break;
            }

            for (int i = aBegin; i < aEnd; i++)
                for (int j = bBegin; j < bEnd; j++)
                    result.Add(new SudokuRangeItem(i, j));

            return result;
        }

        public static int GetBlockIndex(int rowIndex, int columnIndex)
        {
            var finalDick = new Dictionary<int, int>
            {
                {0, 0},
                {1, 1},
                {2, 2},
                {10, 3},
                {11, 4},
                {12, 5},
                {20, 6},
                {21, 7},
                {22, 8}
            };

            int rowValue = rowIndex / 3;
            int columnValue = columnIndex / 3;

            return finalDick[Convert.ToInt32(rowValue.ToString() + columnValue.ToString())];
        }
    }
}
