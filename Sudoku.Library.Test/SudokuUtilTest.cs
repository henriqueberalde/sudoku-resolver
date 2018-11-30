using NUnit.Framework;
using System;
using System.Collections.Generic;
using static Sudoku.Library.SudokuValidator;

namespace Sudoku.Library.Test
{
    [TestFixture]
    public class SudokuUtilTest
    {
        private int[,] _sudokuMatriz;

        [SetUp]
        public void SetUp()
        {
            _sudokuMatriz = new int[9, 9];
        }

        [Test]
        [TestCase(SudokuValidator.RangeType.Row, 0)]
        [TestCase(SudokuValidator.RangeType.Row, 1)]
        [TestCase(SudokuValidator.RangeType.Row, 2)]
        [TestCase(SudokuValidator.RangeType.Row, 3)]
        [TestCase(SudokuValidator.RangeType.Row, 4)]
        [TestCase(SudokuValidator.RangeType.Row, 5)]
        [TestCase(SudokuValidator.RangeType.Row, 6)]
        [TestCase(SudokuValidator.RangeType.Row, 7)]
        [TestCase(SudokuValidator.RangeType.Row, 8)]
        [TestCase(SudokuValidator.RangeType.Column, 0)]
        [TestCase(SudokuValidator.RangeType.Column, 1)]
        [TestCase(SudokuValidator.RangeType.Column, 2)]
        [TestCase(SudokuValidator.RangeType.Column, 3)]
        [TestCase(SudokuValidator.RangeType.Column, 4)]
        [TestCase(SudokuValidator.RangeType.Column, 5)]
        [TestCase(SudokuValidator.RangeType.Column, 6)]
        [TestCase(SudokuValidator.RangeType.Column, 7)]
        [TestCase(SudokuValidator.RangeType.Column, 8)]
        [TestCase(SudokuValidator.RangeType.Block, 0)]
        [TestCase(SudokuValidator.RangeType.Block, 1)]
        [TestCase(SudokuValidator.RangeType.Block, 2)]
        [TestCase(SudokuValidator.RangeType.Block, 3)]
        [TestCase(SudokuValidator.RangeType.Block, 4)]
        [TestCase(SudokuValidator.RangeType.Block, 5)]
        [TestCase(SudokuValidator.RangeType.Block, 6)]
        [TestCase(SudokuValidator.RangeType.Block, 7)]
        [TestCase(SudokuValidator.RangeType.Block, 8)]
        public void GetRange(SudokuValidator.RangeType type, int index)
        {
            var arrBlock = new List<string>[9] {
                new List<string>{"00", "01", "02", "10", "11", "12", "20", "21", "22"},
                new List<string>{"03", "04", "05", "13", "14", "15", "23", "24", "25"},
                new List<string>{"06", "07", "08", "16", "17", "18", "26", "27", "28"},
                new List<string>{"30", "31", "32", "40", "41", "42", "50", "51", "52"},
                new List<string>{"33", "34", "35", "43", "44", "45", "53", "54", "55"},
                new List<string>{"36", "37", "38", "46", "47", "48", "56", "57", "58"},
                new List<string>{"60", "61", "62", "70", "71", "72", "80", "81", "82"},
                new List<string>{"63", "64", "65", "73", "74", "75", "83", "84", "85"},
                new List<string>{"66", "67", "68", "76", "77", "78", "86", "87", "88"},
            };

            var result = SudokuUtil.GetRange(type, index);

            Assert.Greater(result.Count, 0);
            for (int i = 0; i < result.Count; i++)
            {
                switch (type)
                {
                    case RangeType.Row:
                        Assert.AreEqual(result[i].Row, index);
                        Assert.AreEqual(result[i].Column, i);
                        break;
                    case RangeType.Column:
                        Assert.AreEqual(result[i].Row, i);
                        Assert.AreEqual(result[i].Column, index);
                        break;
                    case RangeType.Block:
                        Assert.AreEqual(result[i].Row, (int)Char.GetNumericValue(arrBlock[index][i][0]));
                        Assert.AreEqual(result[i].Column, (int)Char.GetNumericValue(arrBlock[index][i][1]));
                        break;
                }
            }
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 0)]
        [TestCase(0, 2, 0)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 0)]
        [TestCase(1, 2, 0)]
        [TestCase(2, 0, 0)]
        [TestCase(2, 1, 0)]
        [TestCase(2, 2, 0)]

        [TestCase(0, 3, 1)]
        [TestCase(0, 4, 1)]
        [TestCase(0, 5, 1)]
        [TestCase(1, 3, 1)]
        [TestCase(1, 4, 1)]
        [TestCase(1, 5, 1)]
        [TestCase(2, 3, 1)]
        [TestCase(2, 4, 1)]
        [TestCase(2, 5, 1)]

        [TestCase(0, 6, 2)]
        [TestCase(0, 7, 2)]
        [TestCase(0, 8, 2)]
        [TestCase(1, 6, 2)]
        [TestCase(1, 7, 2)]
        [TestCase(1, 8, 2)]
        [TestCase(2, 6, 2)]
        [TestCase(2, 7, 2)]
        [TestCase(2, 8, 2)]

        [TestCase(3, 0, 3)]
        [TestCase(3, 1, 3)]
        [TestCase(3, 2, 3)]
        [TestCase(4, 0, 3)]
        [TestCase(4, 1, 3)]
        [TestCase(4, 2, 3)]
        [TestCase(5, 0, 3)]
        [TestCase(5, 1, 3)]
        [TestCase(5, 2, 3)]

        [TestCase(3, 3, 4)]
        [TestCase(3, 4, 4)]
        [TestCase(3, 5, 4)]
        [TestCase(4, 3, 4)]
        [TestCase(4, 4, 4)]
        [TestCase(4, 5, 4)]
        [TestCase(5, 3, 4)]
        [TestCase(5, 4, 4)]
        [TestCase(5, 5, 4)]

        [TestCase(3, 6, 5)]
        [TestCase(3, 7, 5)]
        [TestCase(3, 8, 5)]
        [TestCase(4, 6, 5)]
        [TestCase(4, 7, 5)]
        [TestCase(4, 8, 5)]
        [TestCase(5, 6, 5)]
        [TestCase(5, 7, 5)]
        [TestCase(5, 8, 5)]

        [TestCase(6, 0, 6)]
        [TestCase(6, 1, 6)]
        [TestCase(6, 2, 6)]
        [TestCase(7, 0, 6)]
        [TestCase(7, 1, 6)]
        [TestCase(7, 2, 6)]
        [TestCase(8, 0, 6)]
        [TestCase(8, 1, 6)]
        [TestCase(8, 2, 6)]

        [TestCase(6, 3, 7)]
        [TestCase(6, 4, 7)]
        [TestCase(6, 5, 7)]
        [TestCase(7, 3, 7)]
        [TestCase(7, 4, 7)]
        [TestCase(7, 5, 7)]
        [TestCase(8, 3, 7)]
        [TestCase(8, 4, 7)]
        [TestCase(8, 5, 7)]

        [TestCase(6, 6, 8)]
        [TestCase(6, 7, 8)]
        [TestCase(6, 8, 8)]
        [TestCase(7, 6, 8)]
        [TestCase(7, 7, 8)]
        [TestCase(7, 8, 8)]
        [TestCase(8, 6, 8)]
        [TestCase(8, 7, 8)]
        [TestCase(8, 8, 8)]
        public void GetBlockIndex(int rowIndex, int columnIndex, int expected)
        {
            var result = SudokuUtil.GetBlockIndex(rowIndex, columnIndex);
            Assert.AreEqual(expected, result);
            
        }
    }
}
