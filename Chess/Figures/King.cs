namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Figures.Contracts;

    public class King : BaseFigure, IFigure
    {
        public King(ChessColor color)
            : base(color)
        {
        }
    }
}
