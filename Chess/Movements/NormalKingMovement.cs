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

            if ((from.Row == to.Row + 1 && from.Col == to.Col + 1) || // top right
                (from.Row == to.Row + 1 && from.Col == to.Col) || // top center
                (from.Row == to.Row + 1 && from.Col == to.Col - 1) || // top left
                (from.Row == to.Row && from.Col == to.Col - 1) || // left 
                (from.Row == to.Row && from.Col == to.Col + 1) || // right
                (from.Row == to.Row - 1 && from.Col == to.Col + 1) || // bottom right) 
               (from.Row == to.Row - 1 && from.Col == to.Col) || // bottom center
                (from.Row == to.Row - 1 && from.Col == to.Col - 1)) // bottom left;
            {
                if (this.CheckOtherFigureIfValid(board, to, other))
                {
                    return;
                }
            }

            throw new InvalidOperationException(KingInvalidMove);
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
