using Sudoku.Library;
using Sudoku.Library.Entities;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Sudoku.WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AnalyseController : ApiController
    {
        public List<RangeItem> Post([FromBody]int[,] value)
        {
            var resolver = new SudokuResolver(value, m => System.Console.WriteLine(m));
            var result = resolver.Analyse();

            return result;
        }
    }
}
