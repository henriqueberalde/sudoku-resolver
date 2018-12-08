//using NUnit.Framework;
//using System.Collections.Generic;
//using Moq;
//using static Sudoku.Library.SudokuValidator;

//namespace Sudoku.Library.Test
//{
//    [TestFixture]
//    public class ValidatorTest
//    {
//        //private int[,] _sudokuMatriz;
//        private SudokuValidator _validator;

//        [Test]
//        public void Validate_ValidSudoku_ValidResult()
//        {
//            _validator = new SudokuValidator(new int[9, 9]
//            {
//                { 5, 3, 4, 6, 7, 8, 9, 1, 2 },
//                { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
//                { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
//                { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
//                { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
//                { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
//                { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
//                { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
//                { 3, 4, 5, 2, 8, 6, 1, 7, 9 }
//            });

//            _validator.Validate(true);
//            foreach (var item in _validator.Result)
//                Assert.IsTrue(item.IsValid);
//        }
//        //[Test]
//        //public void IsRowValid_Row0When00IsEqualTo08_00And08IsInvalid()
//        //{
//        //    _validator = new SudokuValidator(new int[9, 9] {
//        //        { 9, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
//        //    });

//        //    Assert.IsFalse(_validator.IsRowValid(0));
//        //    Assert.IsFalse(_validator.Result[0, 0].IsValid);
//        //    Assert.IsTrue(_validator.Result[0, 1].IsValid);
//        //    Assert.IsTrue(_validator.Result[0, 2].IsValid);
//        //    Assert.IsTrue(_validator.Result[0, 3].IsValid);
//        //    Assert.IsTrue(_validator.Result[0, 4].IsValid);
//        //    Assert.IsTrue(_validator.Result[0, 5].IsValid);
//        //    Assert.IsTrue(_validator.Result[0, 6].IsValid);
//        //    Assert.IsTrue(_validator.Result[0, 7].IsValid);
//        //    Assert.IsFalse(_validator.Result[0, 8].IsValid);
//        //}
//        //[Test]
//        //public void IsColumnValid_Column0When00IsEqualTo80_00And80IsInvalid()
//        //{
//        //    _validator = new SudokuValidator(new int[9, 9] {
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 2, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 3, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 4, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 5, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 6, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 7, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 8, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
//        //    });

//        //    Assert.IsFalse(_validator.IsColumnValid(0));
//        //    Assert.IsFalse(_validator.Result[0, 0].IsValid);
//        //    Assert.IsTrue(_validator.Result[1, 0].IsValid);
//        //    Assert.IsTrue(_validator.Result[2, 0].IsValid);
//        //    Assert.IsTrue(_validator.Result[3, 0].IsValid);
//        //    Assert.IsTrue(_validator.Result[4, 0].IsValid);
//        //    Assert.IsTrue(_validator.Result[5, 0].IsValid);
//        //    Assert.IsTrue(_validator.Result[6, 0].IsValid);
//        //    Assert.IsTrue(_validator.Result[7, 0].IsValid);
//        //    Assert.IsFalse(_validator.Result[8, 0].IsValid);
//        //}
//        //[Test]
//        //public void IsBlockValid_Block0When00IsEqualTo22_00And22IsInvalid()
//        //{
//        //    _validator = new SudokuValidator(new int[9, 9] {
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 4, 5, 6, 4, 5, 6, 7, 8, 9 },
//        //        { 7, 8, 1, 4, 5, 6, 7, 8, 9 },
//        //        { 4, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 5, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 6, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 7, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 8, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
//        //    });

//        //    Assert.IsFalse(_validator.IsBlockValid(0));
//        //    Assert.IsFalse(_validator.Result[0, 0].IsValid);
//        //    Assert.IsTrue(_validator.Result[0, 1].IsValid);
//        //    Assert.IsTrue(_validator.Result[0, 2].IsValid);
//        //    Assert.IsTrue(_validator.Result[1, 0].IsValid);
//        //    Assert.IsTrue(_validator.Result[1, 1].IsValid);
//        //    Assert.IsTrue(_validator.Result[1, 2].IsValid);
//        //    Assert.IsTrue(_validator.Result[2, 0].IsValid);
//        //    Assert.IsTrue(_validator.Result[2, 1].IsValid);
//        //    Assert.IsFalse(_validator.Result[2, 2].IsValid);
//        //}
//        //[Test]
//        //public void IsPositionValid_RowInvalid_False()
//        //{
//        //    _validator = new SudokuValidator(new int[9, 9] {
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 1 },
//        //        { 4, 5, 6, 1, 1, 1, 1, 1, 1 },
//        //        { 7, 8, 9, 1, 1, 1, 1, 1, 1 },
//        //        { 2, 1, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 3, 1, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 5, 1, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 6, 1, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 8, 1, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 9, 1, 1, 1, 1, 1, 1, 1, 1 }
//        //    });

//        //    Assert.IsFalse(_validator.IsPositionValid(0, 0));
//        //}
//        //[Test]
//        //public void IsPositionValid_ColumnInvalid_False()
//        //{
//        //    _validator = new SudokuValidator(new int[9, 9] {
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 4, 5, 6, 1, 1, 1, 1, 1, 1 },
//        //        { 7, 8, 9, 1, 1, 1, 1, 1, 1 },
//        //        { 2, 1, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 3, 1, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 5, 1, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 6, 1, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 8, 1, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
//        //    });

//        //    Assert.IsFalse(_validator.IsPositionValid(0, 0));
//        //}
//        //[Test]
//        //public void IsPositionValid_BlockInvalid_False()
//        //{
//        //    _validator = new SudokuValidator(new int[9, 9] {
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 4, 5, 6, 1, 1, 1, 1, 1, 1 },
//        //        { 7, 8, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 2, 1, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 3, 1, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 5, 1, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 6, 1, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 8, 1, 1, 1, 1, 1, 1, 1, 1 },
//        //        { 9, 1, 1, 1, 1, 1, 1, 1, 1 }
//        //    });

//        //    Assert.IsFalse(_validator.IsPositionValid(0, 0));
//        //}
//        //[Test]
//        //public void IsPositionValid_Valid_True()
//        //{
//        //    _validator = new SudokuValidator(new int[9, 9] {
//        //        { 1, 2, 3, 4, 1, 6, 7, 8, 9 },
//        //        { 4, 5, 6, 1, 2, 1, 1, 1, 1 },
//        //        { 7, 8, 1, 1, 3, 1, 1, 1, 1 },
//        //        { 2, 1, 1, 1, 4, 3, 1, 1, 1 },
//        //        { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//        //        { 5, 1, 1, 7, 6, 9, 1, 1, 1 },
//        //        { 6, 1, 1, 1, 7, 1, 1, 1, 1 },
//        //        { 8, 1, 1, 1, 8, 1, 1, 1, 1 },
//        //        { 9, 1, 1, 1, 9, 1, 1, 1, 1 }
//        //    });

//        //    Assert.IsTrue(_validator.IsPositionValid(4, 4));
//        //}

//        [Test]
//        [TestCase(0, 0)]
//        [TestCase(0, 1)]
//        [TestCase(0, 2)]
//        [TestCase(0, 3)]
//        [TestCase(0, 4)]
//        [TestCase(0, 5)]
//        [TestCase(0, 6)]
//        [TestCase(0, 7)]
//        [TestCase(0, 8)]
//        public void IsRangeValid_OneInvalid(int InvalidRow, int InvalidColumn)
//        {
//            var mock = new Mock<SudokuValidator>(new int[9, 9] {
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
//            });

//            mock.Setup(m => m.IsPositionValidOnRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<List<SudokuRangeItem>>())).Returns(true);
//            mock.Setup(m => m.IsPositionValidOnRange(InvalidRow, InvalidColumn, It.IsAny<List<SudokuRangeItem>>())).Returns(false);

//            var list = new List<SudokuRangeItem> {
//                new SudokuRangeItem(0, 0),
//                new SudokuRangeItem(0, 1),
//                new SudokuRangeItem(0, 2),
//                new SudokuRangeItem(0, 3),
//                new SudokuRangeItem(0, 4),
//                new SudokuRangeItem(0, 5),
//                new SudokuRangeItem(0, 6),
//                new SudokuRangeItem(0, 7),
//                new SudokuRangeItem(0, 8),
//            };

//            Assert.IsFalse(mock.Object.IsRangeValid(list, false));
//        }

//        [Test]
//        public void IsRangeValid_AllInvalid()
//        {
//            var mock = new Mock<SudokuValidator>(new int[9, 9] {
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
//            });

//            mock.Setup(m => m.IsPositionValidOnRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<List<SudokuRangeItem>>())).Returns(false);

//            var list = new List<SudokuRangeItem> {
//                new SudokuRangeItem(0, 0),
//                new SudokuRangeItem(0, 1),
//                new SudokuRangeItem(0, 2),
//                new SudokuRangeItem(0, 3),
//                new SudokuRangeItem(0, 4),
//                new SudokuRangeItem(0, 5),
//                new SudokuRangeItem(0, 6),
//                new SudokuRangeItem(0, 7),
//                new SudokuRangeItem(0, 8),
//            };

//            Assert.IsFalse(mock.Object.IsRangeValid(list, false));
//        }

//        [Test]
//        public void IsRangeValid_AllValid()
//        {
//            var mock = new Mock<SudokuValidator>(new int[9, 9] {
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
//            });

//            mock.Setup(m => m.IsPositionValidOnRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<List<SudokuRangeItem>>())).Returns(true);

//            var list = new List<SudokuRangeItem> {
//                new SudokuRangeItem(0, 0),
//                new SudokuRangeItem(0, 1),
//                new SudokuRangeItem(0, 2),
//                new SudokuRangeItem(0, 3),
//                new SudokuRangeItem(0, 4),
//                new SudokuRangeItem(0, 5),
//                new SudokuRangeItem(0, 6),
//                new SudokuRangeItem(0, 7),
//                new SudokuRangeItem(0, 8),
//            };

//            Assert.IsTrue(mock.Object.IsRangeValid(list, false));
//        }

//        [Test]
//        [TestCase(-1, false)]
//        [TestCase(-13498, false)]
//        [TestCase(10, false)]
//        [TestCase(13498, false)]
//        public void IsPositionValidOnRange_passingValue_False(int value, bool expected)
//        {
//            _validator = new SudokuValidator(new int[9, 9] {
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
//            });

//            for (int row = 0; row < 9; row++)
//                for (int column = 0; column < 9; column++)
//                {
//                    _validator.Sudoku[row, column] = value;
//                    Assert.AreEqual(expected, _validator.IsPositionValidOnRange(row, column, new List<SudokuRangeItem>()));
//                    Assert.IsFalse(_validator.IsPositionValidOnRange(-1, column, new List<SudokuRangeItem>()));
//                    Assert.IsFalse(_validator.IsPositionValidOnRange(row, -1, new List<SudokuRangeItem>()));
//                    Assert.IsFalse(_validator.IsPositionValidOnRange(9, column, new List<SudokuRangeItem>()));
//                    Assert.IsFalse(_validator.IsPositionValidOnRange(row, 9, new List<SudokuRangeItem>()));
//                }
//        }
//        [Test]
//        [TestCase(0, 0, 9, false)]
//        [TestCase(0, 1, 9, false)]
//        [TestCase(0, 2, 9, false)]
//        [TestCase(0, 3, 9, false)]
//        [TestCase(0, 4, 9, false)]
//        [TestCase(0, 5, 9, false)]
//        [TestCase(0, 6, 9, false)]
//        [TestCase(0, 7, 9, false)]
//        [TestCase(0, 8, 1, false)]

//        [TestCase(1, 0, 9, false)]
//        [TestCase(1, 1, 9, false)]
//        [TestCase(1, 2, 9, false)]
//        [TestCase(1, 3, 9, false)]
//        [TestCase(1, 4, 9, false)]
//        [TestCase(1, 5, 9, false)]
//        [TestCase(1, 6, 9, false)]
//        [TestCase(1, 7, 9, false)]
//        [TestCase(1, 8, 1, false)]

//        [TestCase(2, 0, 9, false)]
//        [TestCase(2, 1, 9, false)]
//        [TestCase(2, 2, 9, false)]
//        [TestCase(2, 3, 9, false)]
//        [TestCase(2, 4, 9, false)]
//        [TestCase(2, 5, 9, false)]
//        [TestCase(2, 6, 9, false)]
//        [TestCase(2, 7, 9, false)]
//        [TestCase(2, 8, 1, false)]

//        [TestCase(3, 0, 9, false)]
//        [TestCase(3, 1, 9, false)]
//        [TestCase(3, 2, 9, false)]
//        [TestCase(3, 3, 9, false)]
//        [TestCase(3, 4, 9, false)]
//        [TestCase(3, 5, 9, false)]
//        [TestCase(3, 6, 9, false)]
//        [TestCase(3, 7, 9, false)]
//        [TestCase(3, 8, 1, false)]

//        [TestCase(4, 0, 9, false)]
//        [TestCase(4, 1, 9, false)]
//        [TestCase(4, 2, 9, false)]
//        [TestCase(4, 3, 9, false)]
//        [TestCase(4, 4, 9, false)]
//        [TestCase(4, 5, 9, false)]
//        [TestCase(4, 6, 9, false)]
//        [TestCase(4, 7, 9, false)]
//        [TestCase(4, 8, 1, false)]

//        [TestCase(5, 0, 9, false)]
//        [TestCase(5, 1, 9, false)]
//        [TestCase(5, 2, 9, false)]
//        [TestCase(5, 3, 9, false)]
//        [TestCase(5, 4, 9, false)]
//        [TestCase(5, 5, 9, false)]
//        [TestCase(5, 6, 9, false)]
//        [TestCase(5, 7, 9, false)]
//        [TestCase(5, 8, 1, false)]

//        [TestCase(6, 0, 9, false)]
//        [TestCase(6, 1, 9, false)]
//        [TestCase(6, 2, 9, false)]
//        [TestCase(6, 3, 9, false)]
//        [TestCase(6, 4, 9, false)]
//        [TestCase(6, 5, 9, false)]
//        [TestCase(6, 6, 9, false)]
//        [TestCase(6, 7, 9, false)]
//        [TestCase(6, 8, 1, false)]

//        [TestCase(7, 0, 9, false)]
//        [TestCase(7, 1, 9, false)]
//        [TestCase(7, 2, 9, false)]
//        [TestCase(7, 3, 9, false)]
//        [TestCase(7, 4, 9, false)]
//        [TestCase(7, 5, 9, false)]
//        [TestCase(7, 6, 9, false)]
//        [TestCase(7, 7, 9, false)]
//        [TestCase(7, 8, 1, false)]

//        [TestCase(8, 0, 9, false)]
//        [TestCase(8, 1, 9, false)]
//        [TestCase(8, 2, 9, false)]
//        [TestCase(8, 3, 9, false)]
//        [TestCase(8, 4, 9, false)]
//        [TestCase(8, 5, 9, false)]
//        [TestCase(8, 6, 9, false)]
//        [TestCase(8, 7, 9, false)]
//        [TestCase(8, 8, 1, false)]
//        public void IsPositionValidOnRangeRow_False(int row, int column, int value, bool expected)
//        {
//            _validator = new SudokuValidator(new int[9, 9] {
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
//            });

//            _validator.Sudoku[row, column] = value;

//            Assert.AreEqual(expected, _validator.IsPositionValidOnRange(row, column, SudokuUtil.GetRange(RangeType.Row, row)));
//        }
//        [Test]
//        [TestCase(0, 0)]
//        [TestCase(0, 1)]
//        [TestCase(0, 2)]
//        [TestCase(0, 3)]
//        [TestCase(0, 4)]
//        [TestCase(0, 5)]
//        [TestCase(0, 6)]
//        [TestCase(0, 7)]
//        [TestCase(0, 8)]
                      
//        [TestCase(1, 0)]
//        [TestCase(1, 1)]
//        [TestCase(1, 2)]
//        [TestCase(1, 3)]
//        [TestCase(1, 4)]
//        [TestCase(1, 5)]
//        [TestCase(1, 6)]
//        [TestCase(1, 7)]
//        [TestCase(1, 8)]
                      
//        [TestCase(2, 0)]
//        [TestCase(2, 1)]
//        [TestCase(2, 2)]
//        [TestCase(2, 3)]
//        [TestCase(2, 4)]
//        [TestCase(2, 5)]
//        [TestCase(2, 6)]
//        [TestCase(2, 7)]
//        [TestCase(2, 8)]
                      
//        [TestCase(3, 0)]
//        [TestCase(3, 1)]
//        [TestCase(3, 2)]
//        [TestCase(3, 3)]
//        [TestCase(3, 4)]
//        [TestCase(3, 5)]
//        [TestCase(3, 6)]
//        [TestCase(3, 7)]
//        [TestCase(3, 8)]
                      
//        [TestCase(4, 0)]
//        [TestCase(4, 1)]
//        [TestCase(4, 2)]
//        [TestCase(4, 3)]
//        [TestCase(4, 4)]
//        [TestCase(4, 5)]
//        [TestCase(4, 6)]
//        [TestCase(4, 7)]
//        [TestCase(4, 8)]

//        [TestCase(5, 0)]
//        [TestCase(5, 1)]
//        [TestCase(5, 2)]
//        [TestCase(5, 3)]
//        [TestCase(5, 4)]
//        [TestCase(5, 5)]
//        [TestCase(5, 6)]
//        [TestCase(5, 7)]
//        [TestCase(5, 8)]

//        [TestCase(6, 0)]
//        [TestCase(6, 1)]
//        [TestCase(6, 2)]
//        [TestCase(6, 3)]
//        [TestCase(6, 4)]
//        [TestCase(6, 5)]
//        [TestCase(6, 6)]
//        [TestCase(6, 7)]
//        [TestCase(6, 8)]

//        [TestCase(7, 0)]
//        [TestCase(7, 1)]
//        [TestCase(7, 2)]
//        [TestCase(7, 3)]
//        [TestCase(7, 4)]
//        [TestCase(7, 5)]
//        [TestCase(7, 6)]
//        [TestCase(7, 7)]
//        [TestCase(7, 8)]

//        [TestCase(8, 0)]
//        [TestCase(8, 1)]
//        [TestCase(8, 2)]
//        [TestCase(8, 3)]
//        [TestCase(8, 4)]
//        [TestCase(8, 5)]
//        [TestCase(8, 6)]
//        [TestCase(8, 7)]
//        [TestCase(8, 8)]
//        public void IsPositionValidOnRangeRow_True(int row, int column)
//        {
//            _validator = new SudokuValidator(new int[9, 9] {
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
//                { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
//            });
//            Assert.IsTrue(_validator.IsPositionValidOnRange(row, column, SudokuUtil.GetRange(RangeType.Row, row)));
//        }

//        [Test]
//        [TestCase(0, 0, 9, false)]
//        [TestCase(1, 0, 9, false)]
//        [TestCase(2, 0, 9, false)]
//        [TestCase(3, 0, 9, false)]
//        [TestCase(4, 0, 9, false)]
//        [TestCase(5, 0, 9, false)]
//        [TestCase(6, 0, 9, false)]
//        [TestCase(7, 0, 9, false)]
//        [TestCase(8, 0, 1, false)]

//        [TestCase(0, 1, 9, false)]
//        [TestCase(1, 1, 9, false)]
//        [TestCase(2, 1, 9, false)]
//        [TestCase(3, 1, 9, false)]
//        [TestCase(4, 1, 9, false)]
//        [TestCase(5, 1, 9, false)]
//        [TestCase(6, 1, 9, false)]
//        [TestCase(7, 1, 9, false)]
//        [TestCase(8, 1, 1, false)]

//        [TestCase(0, 2, 9, false)]
//        [TestCase(1, 2, 9, false)]
//        [TestCase(2, 2, 9, false)]
//        [TestCase(3, 2, 9, false)]
//        [TestCase(4, 2, 9, false)]
//        [TestCase(5, 2, 9, false)]
//        [TestCase(6, 2, 9, false)]
//        [TestCase(7, 2, 9, false)]
//        [TestCase(8, 2, 1, false)]

//        [TestCase(0, 3, 9, false)]
//        [TestCase(1, 3, 9, false)]
//        [TestCase(2, 3, 9, false)]
//        [TestCase(3, 3, 9, false)]
//        [TestCase(4, 3, 9, false)]
//        [TestCase(5, 3, 9, false)]
//        [TestCase(6, 3, 9, false)]
//        [TestCase(7, 3, 9, false)]
//        [TestCase(8, 3, 1, false)]

//        [TestCase(0, 4, 9, false)]
//        [TestCase(1, 4, 9, false)]
//        [TestCase(2, 4, 9, false)]
//        [TestCase(3, 4, 9, false)]
//        [TestCase(4, 4, 9, false)]
//        [TestCase(5, 4, 9, false)]
//        [TestCase(6, 4, 9, false)]
//        [TestCase(7, 4, 9, false)]
//        [TestCase(8, 4, 1, false)]

//        [TestCase(0, 5, 9, false)]
//        [TestCase(1, 5, 9, false)]
//        [TestCase(2, 5, 9, false)]
//        [TestCase(3, 5, 9, false)]
//        [TestCase(4, 5, 9, false)]
//        [TestCase(5, 5, 9, false)]
//        [TestCase(6, 5, 9, false)]
//        [TestCase(7, 5, 9, false)]
//        [TestCase(8, 5, 1, false)]

//        [TestCase(0, 6, 9, false)]
//        [TestCase(1, 6, 9, false)]
//        [TestCase(2, 6, 9, false)]
//        [TestCase(3, 6, 9, false)]
//        [TestCase(4, 6, 9, false)]
//        [TestCase(5, 6, 9, false)]
//        [TestCase(6, 6, 9, false)]
//        [TestCase(7, 6, 9, false)]
//        [TestCase(8, 6, 1, false)]

//        [TestCase(0, 7, 9, false)]
//        [TestCase(1, 7, 9, false)]
//        [TestCase(2, 7, 9, false)]
//        [TestCase(3, 7, 9, false)]
//        [TestCase(4, 7, 9, false)]
//        [TestCase(5, 7, 9, false)]
//        [TestCase(6, 7, 9, false)]
//        [TestCase(7, 7, 9, false)]
//        [TestCase(8, 7, 1, false)]

//        [TestCase(0, 8, 9, false)]
//        [TestCase(1, 8, 9, false)]
//        [TestCase(2, 8, 9, false)]
//        [TestCase(3, 8, 9, false)]
//        [TestCase(4, 8, 9, false)]
//        [TestCase(5, 8, 9, false)]
//        [TestCase(6, 8, 9, false)]
//        [TestCase(7, 8, 9, false)]
//        [TestCase(8, 8, 1, false)]
//        public void IsPositionValidOnRangeColumn_False(int row, int column, int value, bool expected)
//        {
//            _validator = new SudokuValidator(new int[9, 9] {
//                { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
//                { 2, 2, 2, 2, 2, 2, 2, 2, 2 },
//                { 3, 3, 3, 3, 3, 3, 3, 3, 3 },
//                { 4, 4, 4, 4, 4, 4, 4, 4, 4 },
//                { 5, 5, 5, 5, 5, 5, 5, 5, 5 },
//                { 6, 6, 6, 6, 6, 6, 6, 6, 6 },
//                { 7, 7, 7, 7, 7, 7, 7, 7, 7 },
//                { 8, 8, 8, 8, 8, 8, 8, 8, 8 },
//                { 9, 9, 9, 9, 9, 9, 9, 9, 9 }
//            });
//            _validator.Sudoku[row, column] = value;

//            Assert.AreEqual(expected, _validator.IsPositionValidOnRange(row, column, SudokuUtil.GetRange(RangeType.Column, column)));
//        }
//        [Test]
//        [TestCase(0, 0)]
//        [TestCase(1, 0)]
//        [TestCase(2, 0)]
//        [TestCase(3, 0)]
//        [TestCase(4, 0)]
//        [TestCase(5, 0)]
//        [TestCase(6, 0)]
//        [TestCase(7, 0)]
//        [TestCase(8, 0)]

//        [TestCase(0, 1)]
//        [TestCase(1, 1)]
//        [TestCase(2, 1)]
//        [TestCase(3, 1)]
//        [TestCase(4, 1)]
//        [TestCase(5, 1)]
//        [TestCase(6, 1)]
//        [TestCase(7, 1)]
//        [TestCase(8, 1)]

//        [TestCase(0, 2)]
//        [TestCase(1, 2)]
//        [TestCase(2, 2)]
//        [TestCase(3, 2)]
//        [TestCase(4, 2)]
//        [TestCase(5, 2)]
//        [TestCase(6, 2)]
//        [TestCase(7, 2)]
//        [TestCase(8, 2)]

//        [TestCase(0, 3)]
//        [TestCase(1, 3)]
//        [TestCase(2, 3)]
//        [TestCase(3, 3)]
//        [TestCase(4, 3)]
//        [TestCase(5, 3)]
//        [TestCase(6, 3)]
//        [TestCase(7, 3)]
//        [TestCase(8, 3)]

//        [TestCase(0, 4)]
//        [TestCase(1, 4)]
//        [TestCase(2, 4)]
//        [TestCase(3, 4)]
//        [TestCase(4, 4)]
//        [TestCase(5, 4)]
//        [TestCase(6, 4)]
//        [TestCase(7, 4)]
//        [TestCase(8, 4)]

//        [TestCase(0, 5)]
//        [TestCase(1, 5)]
//        [TestCase(2, 5)]
//        [TestCase(3, 5)]
//        [TestCase(4, 5)]
//        [TestCase(5, 5)]
//        [TestCase(6, 5)]
//        [TestCase(7, 5)]
//        [TestCase(8, 5)]

//        [TestCase(0, 6)]
//        [TestCase(1, 6)]
//        [TestCase(2, 6)]
//        [TestCase(3, 6)]
//        [TestCase(4, 6)]
//        [TestCase(5, 6)]
//        [TestCase(6, 6)]
//        [TestCase(7, 6)]
//        [TestCase(8, 6)]

//        [TestCase(0, 7)]
//        [TestCase(1, 7)]
//        [TestCase(2, 7)]
//        [TestCase(3, 7)]
//        [TestCase(4, 7)]
//        [TestCase(5, 7)]
//        [TestCase(6, 7)]
//        [TestCase(7, 7)]
//        [TestCase(8, 7)]

//        [TestCase(0, 8)]
//        [TestCase(1, 8)]
//        [TestCase(2, 8)]
//        [TestCase(3, 8)]
//        [TestCase(4, 8)]
//        [TestCase(5, 8)]
//        [TestCase(6, 8)]
//        [TestCase(7, 8)]
//        [TestCase(8, 8)]
//        public void IsPositionValidOnRangeColumn_True(int row, int column)
//        {
//            _validator = new SudokuValidator(new int[9, 9] {
//                { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
//                { 2, 2, 2, 2, 2, 2, 2, 2, 2 },
//                { 3, 3, 3, 3, 3, 3, 3, 3, 3 },
//                { 4, 4, 4, 4, 4, 4, 4, 4, 4 },
//                { 5, 5, 5, 5, 5, 5, 5, 5, 5 },
//                { 6, 6, 6, 6, 6, 6, 6, 6, 6 },
//                { 7, 7, 7, 7, 7, 7, 7, 7, 7 },
//                { 8, 8, 8, 8, 8, 8, 8, 8, 8 },
//                { 9, 9, 9, 9, 9, 9, 9, 9, 9 }
//            });
//            Assert.IsTrue(_validator.IsPositionValidOnRange(row, column, SudokuUtil.GetRange(RangeType.Column, column)));
//        }
//        [Test]
//        [TestCase(0, 0, 9, false)]
//        [TestCase(0, 1, 9, false)]
//        [TestCase(0, 2, 9, false)]
//        [TestCase(1, 0, 9, false)]
//        [TestCase(1, 1, 9, false)]
//        [TestCase(1, 2, 9, false)]
//        [TestCase(2, 0, 9, false)]
//        [TestCase(2, 1, 9, false)]
//        [TestCase(2, 2, 1, false)]

//        [TestCase(0, 3, 9, false)]
//        [TestCase(0, 4, 9, false)]
//        [TestCase(0, 5, 9, false)]
//        [TestCase(1, 3, 9, false)]
//        [TestCase(1, 4, 9, false)]
//        [TestCase(1, 5, 9, false)]
//        [TestCase(2, 3, 9, false)]
//        [TestCase(2, 4, 9, false)]
//        [TestCase(2, 5, 1, false)]

//        [TestCase(0, 6, 9, false)]
//        [TestCase(0, 7, 9, false)]
//        [TestCase(0, 8, 9, false)]
//        [TestCase(1, 6, 9, false)]
//        [TestCase(1, 7, 9, false)]
//        [TestCase(1, 8, 9, false)]
//        [TestCase(2, 6, 9, false)]
//        [TestCase(2, 7, 9, false)]
//        [TestCase(2, 8, 1, false)]

//        [TestCase(3, 0, 9, false)]
//        [TestCase(3, 1, 9, false)]
//        [TestCase(3, 2, 9, false)]
//        [TestCase(4, 0, 9, false)]
//        [TestCase(4, 1, 9, false)]
//        [TestCase(4, 2, 9, false)]
//        [TestCase(5, 0, 9, false)]
//        [TestCase(5, 1, 9, false)]
//        [TestCase(5, 2, 1, false)]

//        [TestCase(3, 3, 9, false)]
//        [TestCase(3, 4, 9, false)]
//        [TestCase(3, 5, 9, false)]
//        [TestCase(4, 3, 9, false)]
//        [TestCase(4, 4, 9, false)]
//        [TestCase(4, 5, 9, false)]
//        [TestCase(5, 3, 9, false)]
//        [TestCase(5, 4, 9, false)]
//        [TestCase(5, 5, 1, false)]

//        [TestCase(3, 6, 9, false)]
//        [TestCase(3, 7, 9, false)]
//        [TestCase(3, 8, 9, false)]
//        [TestCase(4, 6, 9, false)]
//        [TestCase(4, 7, 9, false)]
//        [TestCase(4, 8, 9, false)]
//        [TestCase(5, 6, 9, false)]
//        [TestCase(5, 7, 9, false)]
//        [TestCase(5, 8, 1, false)]

//        [TestCase(6, 0, 9, false)]
//        [TestCase(6, 1, 9, false)]
//        [TestCase(6, 2, 9, false)]
//        [TestCase(7, 0, 9, false)]
//        [TestCase(7, 1, 9, false)]
//        [TestCase(7, 2, 9, false)]
//        [TestCase(8, 0, 9, false)]
//        [TestCase(8, 1, 9, false)]
//        [TestCase(8, 2, 1, false)]

//        [TestCase(6, 3, 9, false)]
//        [TestCase(6, 4, 9, false)]
//        [TestCase(6, 5, 9, false)]
//        [TestCase(7, 3, 9, false)]
//        [TestCase(7, 4, 9, false)]
//        [TestCase(7, 5, 9, false)]
//        [TestCase(8, 3, 9, false)]
//        [TestCase(8, 4, 9, false)]
//        [TestCase(8, 5, 1, false)]

//        [TestCase(6, 6, 9, false)]
//        [TestCase(6, 7, 9, false)]
//        [TestCase(6, 8, 9, false)]
//        [TestCase(7, 6, 9, false)]
//        [TestCase(7, 7, 9, false)]
//        [TestCase(7, 8, 9, false)]
//        [TestCase(8, 6, 9, false)]
//        [TestCase(8, 7, 9, false)]
//        [TestCase(8, 8, 1, false)]
//        public void IsPositionValidOnRangeBlock_False(int row, int column, int value, bool expected)
//        {
//            _validator = new SudokuValidator(new int[9, 9] {
//                { 1, 2, 3, 1, 2, 3, 1, 2, 3 },
//                { 4, 5, 6, 4, 5, 6, 4, 5, 6 },
//                { 7, 8, 9, 7, 8, 9, 7, 8, 9 },
//                { 1, 2, 3, 1, 2, 3, 1, 2, 3 },
//                { 4, 5, 6, 4, 5, 6, 4, 5, 6 },
//                { 7, 8, 9, 7, 8, 9, 7, 8, 9 },
//                { 1, 2, 3, 1, 2, 3, 1, 2, 3 },
//                { 4, 5, 6, 4, 5, 6, 4, 5, 6 },
//                { 7, 8, 9, 7, 8, 9, 7, 8, 9 }
//            });
//            _validator.Sudoku[row, column] = value;

//            Assert.AreEqual(expected, _validator.IsPositionValidOnRange(row, column, SudokuUtil.GetRange(RangeType.Block, SudokuUtil.GetBlockIndex(row, column))));
//        }

//        [Test]
//        [TestCase(0, 0, 9, false)]
//        [TestCase(0, 1, 9, false)]
//        [TestCase(0, 2, 9, false)]
//        [TestCase(1, 0, 9, false)]
//        [TestCase(1, 1, 9, false)]
//        [TestCase(1, 2, 9, false)]
//        [TestCase(2, 0, 9, false)]
//        [TestCase(2, 1, 9, false)]
//        [TestCase(2, 2, 1, false)]

//        [TestCase(0, 3, 9, false)]
//        [TestCase(0, 4, 9, false)]
//        [TestCase(0, 5, 9, false)]
//        [TestCase(1, 3, 9, false)]
//        [TestCase(1, 4, 9, false)]
//        [TestCase(1, 5, 9, false)]
//        [TestCase(2, 3, 9, false)]
//        [TestCase(2, 4, 9, false)]
//        [TestCase(2, 5, 1, false)]

//        [TestCase(0, 6, 9, false)]
//        [TestCase(0, 7, 9, false)]
//        [TestCase(0, 8, 9, false)]
//        [TestCase(1, 6, 9, false)]
//        [TestCase(1, 7, 9, false)]
//        [TestCase(1, 8, 9, false)]
//        [TestCase(2, 6, 9, false)]
//        [TestCase(2, 7, 9, false)]
//        [TestCase(2, 8, 1, false)]

//        [TestCase(3, 0, 9, false)]
//        [TestCase(3, 1, 9, false)]
//        [TestCase(3, 2, 9, false)]
//        [TestCase(4, 0, 9, false)]
//        [TestCase(4, 1, 9, false)]
//        [TestCase(4, 2, 9, false)]
//        [TestCase(5, 0, 9, false)]
//        [TestCase(5, 1, 9, false)]
//        [TestCase(5, 2, 1, false)]

//        [TestCase(3, 3, 9, false)]
//        [TestCase(3, 4, 9, false)]
//        [TestCase(3, 5, 9, false)]
//        [TestCase(4, 3, 9, false)]
//        [TestCase(4, 4, 9, false)]
//        [TestCase(4, 5, 9, false)]
//        [TestCase(5, 3, 9, false)]
//        [TestCase(5, 4, 9, false)]
//        [TestCase(5, 5, 1, false)]

//        [TestCase(3, 6, 9, false)]
//        [TestCase(3, 7, 9, false)]
//        [TestCase(3, 8, 9, false)]
//        [TestCase(4, 6, 9, false)]
//        [TestCase(4, 7, 9, false)]
//        [TestCase(4, 8, 9, false)]
//        [TestCase(5, 6, 9, false)]
//        [TestCase(5, 7, 9, false)]
//        [TestCase(5, 8, 1, false)]

//        [TestCase(6, 0, 9, false)]
//        [TestCase(6, 1, 9, false)]
//        [TestCase(6, 2, 9, false)]
//        [TestCase(7, 0, 9, false)]
//        [TestCase(7, 1, 9, false)]
//        [TestCase(7, 2, 9, false)]
//        [TestCase(8, 0, 9, false)]
//        [TestCase(8, 1, 9, false)]
//        [TestCase(8, 2, 1, false)]

//        [TestCase(6, 3, 9, false)]
//        [TestCase(6, 4, 9, false)]
//        [TestCase(6, 5, 9, false)]
//        [TestCase(7, 3, 9, false)]
//        [TestCase(7, 4, 9, false)]
//        [TestCase(7, 5, 9, false)]
//        [TestCase(8, 3, 9, false)]
//        [TestCase(8, 4, 9, false)]
//        [TestCase(8, 5, 1, false)]

//        [TestCase(6, 6, 9, false)]
//        [TestCase(6, 7, 9, false)]
//        [TestCase(6, 8, 9, false)]
//        [TestCase(7, 6, 9, false)]
//        [TestCase(7, 7, 9, false)]
//        [TestCase(7, 8, 9, false)]
//        [TestCase(8, 6, 9, false)]
//        [TestCase(8, 7, 9, false)]
//        [TestCase(8, 8, 1, false)]
//        public void IsPositionValidOnRangeBlock_True(int row, int column, int value, bool expected)
//        {
//            _validator = new SudokuValidator(new int[9, 9] {
//                { 1, 2, 3, 1, 2, 3, 1, 2, 3 },
//                { 4, 5, 6, 4, 5, 6, 4, 5, 6 },
//                { 7, 8, 9, 7, 8, 9, 7, 8, 9 },
//                { 1, 2, 3, 1, 2, 3, 1, 2, 3 },
//                { 4, 5, 6, 4, 5, 6, 4, 5, 6 },
//                { 7, 8, 9, 7, 8, 9, 7, 8, 9 },
//                { 1, 2, 3, 1, 2, 3, 1, 2, 3 },
//                { 4, 5, 6, 4, 5, 6, 4, 5, 6 },
//                { 7, 8, 9, 7, 8, 9, 7, 8, 9 }
//            });

//            Assert.IsTrue(_validator.IsPositionValidOnRange(row, column, SudokuUtil.GetRange(RangeType.Block, SudokuUtil.GetBlockIndex(row, column))));
//        }
//    }
//}