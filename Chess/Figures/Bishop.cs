namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Movements.Contracts;
    using System.Collections.Generic;

    class Bishop : BaseFigure, IFigure
    {
        public Bishop(ChessColor color)
            : base(color)
        {
        }

        public override ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            throw new System.NotImplementedException();
        }
    }
}
