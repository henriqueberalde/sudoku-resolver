using System;
using System.Collections.Generic;

namespace Sudoku.Library
{
    public static class SudokuUtil
    {
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
