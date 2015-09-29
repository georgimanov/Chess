namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Figures.Contracts;

    class Bishop : BaseFigure, IFigure
    {
        public Bishop(ChessColor color)
            : base(color)
        {
        }
    }
}
