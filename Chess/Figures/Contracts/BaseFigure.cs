namespace Chess.Figures.Contracts
{
    using Chess.Common;

    public abstract class BaseFigure : IFigure
    {
        protected BaseFigure(ChessColor color)
        {
            this.Color = color;
        }

        public ChessColor Color { get; private set; }
    }
}
