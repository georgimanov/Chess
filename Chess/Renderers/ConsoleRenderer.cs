namespace Chess.Renderers
{
    using System;
    using System.Threading;

    using Chess.Board.Contracts;
    using Chess.Common.Console;
    using Chess.Renderers.Contracts;

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "Just Chess";
        private const int CharactersPerRowPerBoardSquare = 9;
        private const int CharactersPerColPerBoardSquare = 9;
        private const ConsoleColor DarskSquareConsoleColor = ConsoleColor.DarkGray;
        private const ConsoleColor LightSquareConsoleColor = ConsoleColor.Gray;

        private const int ConsoleHeight = 80;

        private const int ConsoleWidth = 100;

        public void RenderMainMenu()
        {
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);
            Console.WriteLine(Logo);
            Thread.Sleep(1000);
        }

        public void RenderBoard(IBoard board)
        {
            Console.WindowHeight = ConsoleHeight;
            Console.WindowWidth = ConsoleWidth;

            // TODO: Validate Console Dimension
            var startRowPrint = Console.WindowHeight / 2 - (board.TotalRows / 2) * CharactersPerRowPerBoardSquare;
            var startColPrint = Console.WindowWidth / 2 - (board.TotalCols / 2) * CharactersPerColPerBoardSquare;

            int currentRowPrint = startRowPrint;
            int currentColPrint = startColPrint;

            int counter = 0;

            for (int top = 0; top < board.TotalCols; top++)
            {
                for (int left = 0; left < board.TotalRows; left++)
                {
                    currentRowPrint = startRowPrint + left * CharactersPerColPerBoardSquare;
                    currentColPrint = startColPrint + top * CharactersPerRowPerBoardSquare;

                    if (counter % 2 == 0)
                    {
                        Console.BackgroundColor = DarskSquareConsoleColor;
                    }
                    else
                    {
                        Console.BackgroundColor = LightSquareConsoleColor;
                    }

                    //Console.SetCursorPosition(currentColPrint, currentRowPrint);
                    //Console.Write(" ");

                    for (int i = 0; i < CharactersPerRowPerBoardSquare; i++)
                    {
                        for (int j = 0; j < CharactersPerColPerBoardSquare; j++)
                        {
                            Console.SetCursorPosition(currentColPrint + j, currentRowPrint + i);
                            Console.Write(" ");
                        }
                    }

                    counter++;
                }
                counter++;

            }

            Console.ReadLine();

        }
    }
}
