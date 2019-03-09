using Sudoku.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku.Library
{
    public class SudokuResolver
    {
        private Action<string> _actionLog;
        private int _rows;
        private int _columns;

        public int[,] Sudoku { get; set; }
        public List<RangeItem> RangeItems { get; set; }
        public ValidatorResult[,] Result { get; private set; }

        public SudokuResolver(int[,] sudoku)
        {
            Load(sudoku);
        }

        public SudokuResolver(int[,] sudoku, Action<string> logger)
        {
            _actionLog = logger;
            Load(sudoku);
        }

        private void Load(int[,] sudoku)
        {
            Log("Loading Sudoku");

            if (sudoku == null)
                Log("This is not a valid Sudoku");

            //if (_validator == null)
            //    _validator = new SudokuValidator(sudoku);

            if(Validate(false))
                Log("The Sudoku is already resolved");

            Sudoku = sudoku;
            _rows = Sudoku.GetLength(0);
            _columns = Sudoku.GetLength(1);
            RangeItems = new List<RangeItem>();
            Result = new ValidatorResult[9, 9];

            for (int i = 0; i < _rows; i++)
                for (int j = 0; j < _columns; j++)
                    RangeItems.Add(new RangeItem(i, j, Sudoku[i, j]));

            for (int i = 0; i < _rows; i++)
                for (int j = 0; j < _columns; j++)
                {
                    var item = RangeItems.Find(o => o.Row == i && o.Column == j);
                    if (item.Value == 0)
                        item.PossibleValues = FindPossibleValues(i, j);
                }
        }

        public bool Resolve()
        {
            Log("Resolving");
            bool refresh;

            do
            {
                refresh = false;
                AnalysePhase1();
                AnalysePhase2();

                foreach (var item in GetAllBlank())
                    refresh = TryResolve(item.Row, item.Column) || refresh;
            }
            while (refresh);

            if (!Validate(false))
            {
                Log("Resolver can't resolve this Sudoku");
                return false;
            }

            Log("The Sudoku is resolved");
            return true;
        }

        public bool TryResolve(int row, int column)
        {
            var item = RangeItems.Find(o => o.Row == row && o.Column == column);
            var logMessage = $"Try resolve [{item.Row}, {item.Column}]";

            if (item.PossibleValues.Count == 1)
            {
                item.Value = item.PossibleValues[0];
                item.PossibleValues = new List<int>();
                Sudoku[item.Row, item.Column] = item.Value;

                logMessage += $" -> Resolved: {Sudoku[item.Row, item.Column]}";
                Log(logMessage);
                return true;
            }

            logMessage += $" -> Not Resolved. Possible values: [{string.Join(", ", item.PossibleValues)}]";
            Log(logMessage);
            return false;
        }

        public List<RangeItem> GetAllBlank()
        {
            return RangeItems.FindAll(i => i.Value == 0);
        }

        public List<RangeItem> AnalysePhase1()
        {
            for (int h = 0; h < 3; h++)
            {
                var type = (RangeType)h;

                for (int i = 0; i < 9; i++)
                {
                    var range = GetRange(type, i);

                    for (int j = 0; j < 9; j++)
                    {
                        var items = range.Where(o => o.PossibleValues.Contains(j)).ToList();

                        if (items.Count() == 1)
                            items[0].PossibleValues.RemoveAll(o => o != j);
                    }
                }
            }

            return RangeItems;
        }

        public List<RangeItem> AnalysePhase2()
        {
            for (int h = 0; h < 3; h++)
            {
                var type = (RangeType)h;

                for (int i = 0; i < 9; i++)
                {
                    var range = GetRange(type, i);

                    for (int j = 0; j < range.Count; j++)
                    {
                        var qtdPossibleValues = range[j].PossibleValues.Count;

                        if (qtdPossibleValues <= 1)
                            continue;

                        //Acha as posições que tem a mesma quantidade de possibilidades
                        var list = range.Where(o => o.PossibleValues.Count == qtdPossibleValues).ToList();

                        //A quantidade de possibilidades deve ser igual a quantidade de posições encontradas
                        if (list.Count() != qtdPossibleValues)
                            continue;

                        //Verifica se as possibilidades são as mesmas
                        var allSameValue = true;
                        for (int a = 0; a < qtdPossibleValues; a++)
                        {
                            var currentValue = list[0].PossibleValues[a];
                            for (int b = 0; b < qtdPossibleValues; b++)
                            {
                                if (currentValue != list[b].PossibleValues[a])
                                    allSameValue = false;
                            }
                        }

                        if (allSameValue)
                        {
                            var others = range.Where(o => !list.Contains(o));
                            foreach (var item in others)
                                item.PossibleValues.RemoveAll(v => range[j].PossibleValues.Contains(v));
                        }

                        //TODO - Retirar essas mesmas possibilidades também da linha, coluna ou bloco desses caras (o que for igual para todos)
                    }
                }
            }

            return RangeItems;
        }

        public List<int> FindPossibleValues(int row, int column)
        {
            var possibleOnRow = FindPossibleValues(GetRange(RangeType.Row, row));
            var possibleOnColumn = FindPossibleValues(GetRange(RangeType.Column, column));
            var possibleOnBlock = FindPossibleValues(GetRange(RangeType.Block, SudokuUtil.GetBlockIndex(row, column)));

            return possibleOnRow.Intersect(possibleOnColumn).Intersect(possibleOnBlock).ToList();
        }

        public List<int> FindPossibleValues(List<RangeItem> range)
        {
            var possibleValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach (var item in range)
                if (possibleValues.Contains(Sudoku[item.Row, item.Column]))
                    possibleValues.Remove(Sudoku[item.Row, item.Column]);

            return possibleValues;
        }

        private void Log(string message)
        {
            _actionLog?.Invoke(message);
        }

        public bool Validate(bool fillResult)
        {
            var valid = true;

            for (int i = 0; i < _rows; i++)
            {
                valid = IsRangeValid(GetRange(RangeType.Row, i), fillResult) && valid;
                valid = IsRangeValid(GetRange(RangeType.Column, i), fillResult) && valid;
                valid = IsRangeValid(GetRange(RangeType.Block, i), fillResult) && valid;
            }
            return valid;
        }

        public bool IsRangeValid(List<RangeItem> range, bool fillResult)
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

        public virtual bool IsPositionValidOnRange(int rowPosition, int columnPosition, List<RangeItem> range)
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

        public List<RangeItem> GetRange(RangeType type, int index)
        {
            var result = new List<RangeItem>();
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

                    var firstBlockIndex = new int[9] { 0, 0, 0, 3, 3, 3, 6, 6, 6 };

                    aBegin = firstBlockIndex[index];
                    aEnd = firstBlockIndex[index] + 3;
                    bBegin = (index - firstBlockIndex[index]) * 3;
                    bEnd = bBegin + 3;

                    break;
            }

            for (int i = aBegin; i < aEnd; i++)
                for (int j = bBegin; j < bEnd; j++)
                    result.Add(RangeItems.Find(o => o.Row == i && o.Column == j));

            return result;
        }
    }
}
