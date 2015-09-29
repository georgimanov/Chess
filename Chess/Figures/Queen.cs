namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Figures.Contracts;

    public class Queen : BaseFigure, IFigure
    {
        public Queen(ChessColor color)
            : base(color)
        {
        }
    }
}
