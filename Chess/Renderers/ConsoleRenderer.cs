namespace Chess.Renderers
{
    using System;
    using System.Threading;

    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Common.Console;
    using Chess.Renderers.Contracts;

    public class ConsoleRenderer : IRenderer
    {
        private const string Logo = "Just Chess";
        private const ConsoleColor DarskSquareConsoleColor = ConsoleColor.DarkGray;
        private const ConsoleColor LightSquareConsoleColor = ConsoleColor.Gray;
        private const int ConsoleHeight = 80;
        private const int ConsoleWidth = 100;

        public ConsoleRenderer()
        {
            Console.WindowHeight = ConsoleHeight;
            Console.WindowWidth = ConsoleWidth;
            Console.BufferHeight = ConsoleHeight;
            Console.BufferWidth = ConsoleWidth;
        }

        public void RenderMainMenu()
        {
            ConsoleHelpers.SetCursorAtCenter(Logo.Length);
            Console.WriteLine(Logo);
            Thread.Sleep(1000);
        }

        public void RenderBoard(IBoard board)
        {
            // TODO: Validate Console Dimension
            var startRowPrint = Console.WindowWidth / 2 - (board.TotalRows / 2) * ConsoleConstants.CharactersPerRowPerBoardSquare;
            var startColPrint = Console.WindowHeight / 2 - (board.TotalCols / 2) * ConsoleConstants.CharactersPerColPerBoardSquare;

            int currentRowPrint = startRowPrint;
            int currentColPrint = startColPrint;

            int counter = 0;

            for (int top = 0; top < board.TotalCols; top++)
            {
                for (int left = 0; left < board.TotalRows; left++)
                {
                    currentColPrint = startRowPrint + left * ConsoleConstants.CharactersPerColPerBoardSquare;
                    currentRowPrint = startColPrint + top * ConsoleConstants.CharactersPerRowPerBoardSquare;

                    ConsoleColor backgroundColor;

                    if (counter % 2 == 0)
                    {
                        backgroundColor = DarskSquareConsoleColor;
                        Console.BackgroundColor = DarskSquareConsoleColor;
                    }
                    else
                    {
                        backgroundColor = LightSquareConsoleColor;
                        Console.BackgroundColor = LightSquareConsoleColor;
                    }

                    var position = Position.FromArrayCoordinates(top, left, board.TotalRows);

                    var figure = board.GetFigureAtPosition(position);
                    ConsoleHelpers.PrintFigure(figure, backgroundColor, currentRowPrint, currentColPrint);

                    counter++;
                }
                counter++;

            }

            Console.ReadLine();

        }
    }
}
