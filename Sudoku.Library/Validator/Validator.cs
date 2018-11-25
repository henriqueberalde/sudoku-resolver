using System.Collections.Generic;

namespace Sudoku.Library
{
    public class SudokuValidator
    {
        public int[,] Sudoku { get; private set; }
        public ValidatorResult[,] Result { get; private set; }
        private int _rows;
        private int _columns;

        public SudokuValidator(int[,] sudoku)
        {
            Sudoku = sudoku;
            Result = new ValidatorResult[9, 9];
            _rows = Sudoku.GetLength(0);
            _columns = Sudoku.GetLength(1);
        }

        public bool Validate(bool fillResult)
        {
            var valid = true;

            for (int i = 0; i < _rows; i++)
            {
                valid = IsRangeValid(SudokuUtil.GetRange(RangeType.Row, i), fillResult) && valid;
                valid = IsRangeValid(SudokuUtil.GetRange(RangeType.Column, i), fillResult) && valid;
                valid = IsRangeValid(SudokuUtil.GetRange(RangeType.Block, i), fillResult) && valid;
            }
            return valid;
        }

        public bool IsRangeValid(List<SudokuRangeItem> range, bool fillResult)
        {
            var valid = true;

            foreach (var item in range)
            {
                var value = Sudoku[item.Row, item.Column];
                var validItem = IsPositionValidOnRange(item.Row, item.Column, range);

                valid = validItem && valid;

                if (fillResult)
                {
                    if (Result[item.Row, item.Column] != null)
                    {
                        if (!validItem)
                            Result[item.Row, item.Column].IsValid = validItem;
                    }
                    else
                    {
                        Result[item.Row, item.Column] = new ValidatorResult
                        {
                            Value = value,
                            IsValid = validItem
                        };
                    }
                }
            }

            return valid;
        }

        public virtual bool IsPositionValidOnRange(int rowPosition, int columnPosition, List<SudokuRangeItem> range)
        {
            if (rowPosition < 0
                || rowPosition > 8
                || columnPosition < 0
                || columnPosition > 8
                || Sudoku[rowPosition, columnPosition] < 1
                || Sudoku[rowPosition, columnPosition] > 9
              )
                return false;

            foreach (var item in range)
                if (
                    (rowPosition != item.Row || columnPosition != item.Column)
                        &&
                    Sudoku[rowPosition, columnPosition] == Sudoku[item.Row, item.Column]
                   )
                    return false;

            return true;
        }

        public enum RangeType
        {
            Row,
            Column,
            Block
        }

        public class SudokuRangeItem
        {
            public SudokuRangeItem(int row, int column)
            {
                Row = row;
                Column = column;
            }
            public int Row { get; set; }
            public int Column { get; set; }
        }

        public class ValidatorResult
        {
            public int Value { get; set; }
            public bool IsValid { get; set; }
        }
    }
}
