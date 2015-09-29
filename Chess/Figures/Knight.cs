namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Figures.Contracts;

    public class Knight : BaseFigure, IFigure
    {
        public Knight(ChessColor color)
            : base(color)
        {
        }
    }
}
