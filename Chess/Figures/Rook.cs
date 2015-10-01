namespace Chess.Figures
{
    using System.Collections.Generic;

    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Movements.Contracts;

    public class Rook : BaseFigure, IFigure
    {
        public Rook(ChessColor color)
            : base(color)
        {
        }
        public override ICollection<IMovement> Move(IMovementStrategy strategy)
        {
            throw new System.NotImplementedException();
        }
    }
}
