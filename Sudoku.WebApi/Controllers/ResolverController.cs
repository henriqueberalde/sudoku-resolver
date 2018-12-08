using Sudoku.Library;
using Sudoku.WebApi.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Sudoku.WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ResolverController : ApiController
    {
        public ResolverResponse Post([FromBody]int[,] value)
        {
            var logs = new List<string>();
            var resolver = new SudokuResolver(value, m => logs.Add(m));
            var result = resolver.Resolve();

            var response = new ResolverResponse
            {
                Matrix = value,
                Logs = logs,
                Resolved = result,
                RangeItems = resolver.RangeItems
            };
            return response;
        }
    }
}
