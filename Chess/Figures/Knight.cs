namespace Chess.Figures
{
    using System.Collections.Generic;

    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Movements.Contracts;

    public class Knight : BaseFigure, IFigure
    {
        public Knight(ChessColor color)
            : base(color)
        {
        }

        public override ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            throw new System.NotImplementedException();
        }
    }
}
