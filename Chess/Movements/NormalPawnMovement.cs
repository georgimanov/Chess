namespace Chess.Movements
{
    using System;

    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Movements.Contracts;

    public class NormalPawnMovement : IMovement
    {
        private const string PawnBackwardsErrorMessage = "Pawns cannot move backwards!";
        private const string PawnInvalidMove = "Pawns cannot move this way!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var color = figure.Color;
            var other = figure.Color == ChessColor.White ? ChessColor.White : ChessColor.Black;
            var from = move.From;
            var to = move.To;


            if (color == ChessColor.White &&
                to.Row < from.Row)
            {
                throw new InvalidOperationException(PawnBackwardsErrorMessage);
            }

            if (color == ChessColor.Black && to.Row > from.Row)
            {
                throw new InvalidOperationException(PawnBackwardsErrorMessage);
            }

            if (color == ChessColor.White)
            {
                if(from.Row + 1 == to.Row && this.CheckDiagonalMove(from, to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, other))
                    {
                        return;
                    }
                }
            }
            else if (color == ChessColor.Black )
            {
                if (from.Row - 1 == to.Row && this.CheckDiagonalMove(from, to))
                {
                    if (this.CheckOtherFigureIfValid(board, to, other))
                    {
                        return;
                    }
                }
            }

            // TODO: remove 2 magic number (const)
            if (from.Row == 2 && color == ChessColor.White)
            {
                if (from.Row + 2 == to.Row &&
                    this.CheckOtherFigureIfValid(board, to, other))
                {
                    return;
                }
            } 
            else if (from.Row == 7 && color == ChessColor.Black)
            {
                if (from.Row - 2 == to.Row &&
                    this.CheckOtherFigureIfValid(board, to, other))
                {
                    return;
                }
            }

            if (from.Row + 1 == to.Row && color == ChessColor.White)
            {
                if (this.CheckOtherFigureIfValid(board, to, other))
                {
                    return;
                }
            }
            else if (from.Row - 1 == to.Row && color == ChessColor.Black)
            {
                if (this.CheckOtherFigureIfValid(board, to, other))
                {
                    return;
                }
            }

            throw new InvalidOperationException(PawnInvalidMove);
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

        private bool CheckDiagonalMove(Position from, Position to)
        {
            return (from.Col + 1 == to.Col || from.Col - 1 == to.Col);
        }
    }
}
