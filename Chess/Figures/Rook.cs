namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Figures.Contracts;

    public class Rook : BaseFigure, IFigure
    {
        public Rook(ChessColor color)
            : base(color)
        {
        }
    }
}
