using Sudoku.Library;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using static Sudoku.Library.SudokuResolver;

namespace Sudoku.WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AnalyseController : ApiController
    {
        public List<AnalysisItem> Post([FromBody]int[,] value)
        {
            var resolver = new SudokuResolver(value, m => System.Console.WriteLine(m));
            var result = resolver.Analyse();

            return result;
        }
    }
}
