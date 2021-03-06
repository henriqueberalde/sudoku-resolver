﻿using Sudoku.Library;
using Sudoku.Library.Entities;

namespace Sudoku.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var matriz = new int[9, 9] {
                { 7, 0, 8, 0, 0, 4, 3, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 5, 9, 0, 0, 6, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 7 },
                { 0, 0, 7, 0, 0, 9, 0, 3, 0 },
                { 4, 0, 6, 0, 0, 3, 5, 8, 0 },
                { 0, 0, 4, 0, 0, 5, 0, 0, 6 },
                { 0, 0, 0, 8, 1, 7, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 5 }
            };

            //var matriz = new int[9, 9] {
            //    { 1, 0, 0, 6, 0, 5, 0, 8, 0 },
            //    { 0, 0, 0, 0, 0, 0, 3, 4, 0 },
            //    { 7, 8, 3, 0, 0, 2, 0, 1, 6 },
            //    { 3, 1, 5, 9, 4, 6, 2, 0, 8 },
            //    { 0, 0, 0, 0, 0, 0, 4, 6, 0 },
            //    { 4, 7, 0, 0, 1, 0, 0, 5, 0 },
            //    { 0, 3, 2, 0, 0, 0, 0, 9, 7 },
            //    { 0, 0, 0, 1, 0, 3, 0, 0, 0 },
            //    { 0, 0, 0, 0, 0, 0, 8, 0, 5 }
            //};

            var resolver = new SudokuResolver(matriz, m => System.Console.WriteLine(m));
            System.Console.WriteLine("Resolving Matriz:");
            DrawMatriz(matriz);
            resolver.Resolve();
            System.Console.WriteLine("Resolver Result:");
            matriz = resolver.Sudoku;

            DrawMatriz(matriz);

            System.Console.WriteLine("Validating Matriz");
            resolver.Validate(true);
            System.Console.WriteLine("Validating Result:");
            DrawResult(resolver.Result);

            System.Console.Read();
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

        static void DrawResult(ValidatorResult[,] result)
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
