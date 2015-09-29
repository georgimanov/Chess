namespace Chess.Common.Console
{
    using System;

    using Chess.Figures.Contracts;

    public static class ConsoleHelpers
    {
        public static ConsoleColor ToConsoleColor(this ChessColor chessColor)
        {
            switch (chessColor)
            {
                case ChessColor.Black:
                    return ConsoleColor.Black;
                case ChessColor.White:
                    return ConsoleColor.White;
                case ChessColor.Brown:
                    return ConsoleColor.DarkYellow;
                default:
                    throw new InvalidOperationException("Cannot convert Chess Color!");
            }
        }
        
        public static void SetCursorAtCenter(int lenghtOfMessage)
        {
            int centerRow = Console.WindowHeight / 2;

            int centerCol = Console.WindowWidth / 2 - lenghtOfMessage / 2;

            Console.SetCursorPosition(centerCol, centerRow);
        }

        public static void PrintFigure(IFigure figure, ConsoleColor backgroundColor,
             int top, int left)
        {
            if (figure == null)
            {
                PrintEmtySquare(backgroundColor, top, left);
            }
        }

        public static void PrintEmtySquare(ConsoleColor backgroundColor, int top, int left)
        {
            for (int i = 0; i < ConsoleConstants.CharactersPerRowPerBoardSquare; i++)
            {
                for (int j = 0; j < ConsoleConstants.CharactersPerColPerBoardSquare; j++)
                {
                    Console.SetCursorPosition(left + j, top + i);
                    Console.Write(" ");
                }
            }
        }
    }
}
