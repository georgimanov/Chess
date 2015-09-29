﻿namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Figures.Contracts;

    public class Pawn : BaseFigure, IFigure
    {
        public Pawn(ChessColor color)
            : base(color)
        {
        }
    }
}
