namespace Chess.Movements
{
    using System;

    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Movements.Contracts;

    public class NormalKingMovement : IMovement
    {
        private const string KingInvalidMove = "King cannot move this way!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var other = figure.Color == ChessColor.White ? ChessColor.White : ChessColor.Black;
            var from = move.From;
            var to = move.To;

            if (CheckUpDownMove(from, to) 
                && this.CheckDiagonalMove(from, to))
            {
                if (this.CheckOtherFigureIfValid(board, to, other))
                {
                    return;
                }
            }

            throw new InvalidOperationException(KingInvalidMove);
        }

        private static bool CheckUpDownMove(Position from, Position to)
        {
            return (from.Row - 1 == to.Row || from.Row + 1 == to.Row);
        }

        private bool CheckDiagonalMove(Position from, Position to)
        {
            return (from.Col + 1 == to.Col || from.Col - 1 == to.Col);
        }

        private bool CheckOtherFigureIfValid(IBoard board, Position to, ChessColor color)
        {
            var otherFigure = board.GetFigureAtPosition(to);
            if (otherFigure != null && otherFigure.Color == color)
            {
                return false;
            }

            return true;
        }
    }
}
