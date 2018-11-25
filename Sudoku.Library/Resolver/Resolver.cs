using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.Library;
using static Sudoku.Library.SudokuValidator;

namespace Sudoku.Library
{
    public class SudokuResolver
    {
        public int[,] Sudoku { get; set; }
        private Action<string> _actionLog;
        private SudokuValidator _validator;

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

            if (_validator == null)
                _validator = new SudokuValidator(sudoku);

            if(_validator.Validate(false))
                Log("The Sudoku is already resolved");

            Sudoku = sudoku;
        }

        public bool Resolve()
        {
            Log("Resolving");
            bool refresh;

            do
            {
                refresh = false;
                foreach (var item in GetAllBlank())
                    refresh = TryResolve(item) || refresh;
            }
            while (refresh);

            if (!_validator.Validate(false))
            {
                Log("Resolver can't resolve this Sudoku");
                return false;
            }

            Log("The Sudoku is resolved");
            return true;
        }

        public bool TryResolve(SudokuRangeItem item)
        {
            return TryResolve(item.Row, item.Column);
        }

        public bool TryResolve(int row, int column)
        {
            Log($"Try resolve [{row}, {column}]");
            var resolverItem = FindPossibleValues(row, column);
            if (resolverItem.PossibleValues.Length == 1)
            {
                Sudoku[row, column] = resolverItem.PossibleValues[0];
                Log($"Resolved: {Sudoku[row, column]}");
                return true;
            }

            Log($"Not Resolved. Possible values: [{string.Join(", ", resolverItem.PossibleValues)}]");
            return false;
        }

        public List<SudokuRangeItem> GetAllBlank()
        {
            var list = new List<SudokuRangeItem>();
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (Sudoku[i, j] == 0)
                        list.Add(new SudokuRangeItem(i, j));

            if (!list.Any())
                Log("No blank space was found");

            return list;
        }

        public ResolverItem FindPossibleValues(int row, int column)
        {
            var possibleOnRow = FindPossibleValues(SudokuUtil.GetRange(RangeType.Row, row));
            var possibleOnColumn = FindPossibleValues(SudokuUtil.GetRange(RangeType.Column, column));
            var possibleOnBlock = FindPossibleValues(SudokuUtil.GetRange(RangeType.Block,
                                                            SudokuUtil.GetBlockIndex(row, column)));

            return possibleOnRow.Intersect(possibleOnColumn).Intersect(possibleOnBlock);
        }

        public ResolverItem FindPossibleValues(List<SudokuRangeItem> range)
        {
            var possibleValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach (var item in range)
                if (possibleValues.Contains(Sudoku[item.Row, item.Column]))
                    possibleValues.Remove(Sudoku[item.Row, item.Column]);

            return new ResolverItem { PossibleValues = possibleValues.ToArray() };
        }

        private void Log(string message)
        {
            _actionLog?.Invoke(message);
        }

        public class ResolverItem
        {
            public int Value { get; set; }
            public int[] PossibleValues { get; set; }

            public ResolverItem Intersect(ResolverItem second)
            {
                var list1 = PossibleValues.ToList();
                var list2 = second.PossibleValues.ToList();

                return new ResolverItem { PossibleValues = list1.Intersect(list2).ToArray()};
            }
        }
    }
}
