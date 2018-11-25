using Sudoku.Library;

namespace Sudoku.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var matriz = new int[9, 9] {
                { 1, 0, 0, 6, 0, 5, 0, 8, 0 },
                { 0, 0, 0, 0, 0, 0, 3, 4, 0 },
                { 7, 8, 3, 0, 0, 2, 0, 1, 6 },
                { 3, 1, 5, 9, 4, 6, 2, 0, 8 },
                { 0, 0, 0, 0, 0, 0, 4, 6, 0 },
                { 4, 7, 0, 0, 1, 0, 0, 5, 0 },
                { 0, 3, 2, 0, 0, 0, 0, 9, 7 },
                { 0, 0, 0, 1, 0, 3, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 8, 0, 5 }
            };

            Resolve(ref matriz);
            DrawMatriz(matriz);
            Validate(ref matriz);
            System.Console.Read();
        }

        static void Resolve(ref int[,] matriz)
        {
            var resolver = new SudokuResolver(matriz, m => System.Console.WriteLine(m));
            System.Console.WriteLine("Resolving Matriz:");
            DrawMatriz(matriz);

            resolver.Resolve();

            System.Console.WriteLine("Resolver Result:");
            matriz = resolver.Sudoku;
        }

        static void Validate(ref int[,] matriz)
        {
            var validator = new SudokuValidator(matriz);
            System.Console.WriteLine("Validating Matriz");
            //DrawMatriz(matriz);
            validator.Validate(true);
            System.Console.WriteLine("Validating Result:");
            DrawResult(validator.Result);
        }

        static void DrawMatriz(int[,] matriz)
        {
            System.Console.WriteLine("##################");
            for (int i = 0; i < 9; i++)
            {
                var rowStr = "";

                for (int j = 0; j < 9; j++)
                    rowStr += " " + matriz[i, j];

                System.Console.WriteLine(rowStr);
            }
            System.Console.WriteLine("##################");
        }

        static void DrawResult(SudokuValidator.ValidatorResult[,] result)
        {
            System.Console.WriteLine("######RESULT######");
            for (int i = 0; i < 9; i++)
            {
                var rowStr = "";

                for (int j = 0; j < 9; j++)
                {
                    if (result[i, j] != null)
                        rowStr += " " + (result[i, j].IsValid ? 1 : 0);
                    else
                        rowStr += " #";
                }

                System.Console.WriteLine(rowStr);
            }
            System.Console.WriteLine("######RESULT######");
        }
    }
}
