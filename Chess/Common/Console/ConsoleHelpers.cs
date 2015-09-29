namespace Chess.Common.Console
{
    using System;

    public static class ConsoleHelpers
    {
        public static void SetCursorAtCenter(int lenghtOfMessage)
        {
            int centerRow = Console.WindowHeight / 2;

            int centerCol = Console.WindowWidth / 2 - lenghtOfMessage / 2;

            Console.SetCursorPosition(centerCol, centerRow);
        }
    }
}
