namespace Chess.Movements
{
    using System;

    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Movements.Contracts;

    public class NormalBishopMovement : IMovement
    {
        private const string BishopInvalidMove = "Bishops cannot move this way!";

        public void ValidateMove(IFigure figure, IBoard board, Move move)
        {
            var rowDistance = Math.Abs(move.From.Row - move.To.Row);
            var colDistance = Math.Abs(move.From.Col - move.To.Col);

            if (rowDistance != colDistance)
            {
                throw new InvalidOperationException(BishopInvalidMove);
            }

            var from = move.From;
            var to = move.To;

            int rowIndex = from.Row;
            char colIndex = from.Col;
            var other = figure.Color == ChessColor.White ? ChessColor.Black : ChessColor.White;

            // top-right
            while (true)
            {
                rowIndex++;
                colIndex++;
                if (to.Row == rowIndex && to.Col == colIndex)
                {
                    var figureAtPosition = board.GetFigureAtPosition(to);
                    if (figureAtPosition != null && figureAtPosition.Color == figure.Color)
                    {
                        throw new InvalidOperationException("There is a figure on the way!");
                    }
                    else
                    {
                        return;
                    }
                }

                var position = Position.FromChessCoordinates(rowIndex, colIndex);
                var figAtPosition = board.GetFigureAtPosition(position);
                if (figAtPosition != null)
                {
                    throw new InvalidOperationException("There is a figure on the way!");
                }
            }

        }
    }
}
