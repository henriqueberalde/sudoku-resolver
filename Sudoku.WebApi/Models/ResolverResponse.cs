using Sudoku.Library;
using Sudoku.Library.Entities;
using System.Collections.Generic;

namespace Sudoku.WebApi.Models
{
    public class ResolverResponse
    {
        public int[,] Matrix { get; set; }
        public List<string> Logs { get; set; }
        public List<RangeItem> RangeItems { get; set; }
        public bool Resolved { get; set; }

    }
}