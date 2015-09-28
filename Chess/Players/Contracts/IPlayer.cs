namespace Chess.Players.Contracts
{
    using Chess.Common;
    using Chess.Figures.Contracts;

    public interface IPlayer
    {
        string Name { get; }

        ChessColor Color { get; }

        void AddFigure(IFigure figure);

        void RemoveFigure(IFigure figure);
    }
}
