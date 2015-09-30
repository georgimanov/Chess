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
        private const int Height = 80;
        private const int Width = 100;

        public ConsoleRenderer()
        {
            InitializeConsoleSettings();
        }

        private static void InitializeConsoleSettings()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.Title = ConsoleConstants.ConsoleChessTitle;
            Console.WindowHeight = Height;
            Console.WindowWidth = Width;
            Console.BufferHeight = Height;
            Console.BufferWidth = Width;
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

            string message = string.Format("Player {0} turn", "pesho");
            ConsoleHelpers.SetCursorAtTopCenter(message.Length);
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}
