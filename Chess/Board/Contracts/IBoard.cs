namespace Chess.Board.Contracts
{
    using Chess.Common;
    using Chess.Figures.Contracts;

    public interface IBoard
    {
        int TotalRows { get; }
        
        int TotalCols { get; }

        void AddFigure(IFigure figure, Position position);

        void RemoveFigure(Position position);

        IFigure GetFigureAtPosition(Position position);
    }
}