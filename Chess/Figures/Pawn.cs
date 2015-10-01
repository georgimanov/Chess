namespace Chess.Figures
{
    using System.Collections.Generic;

    using Chess.Common;
    using Chess.Figures.Contracts;
    using Chess.Movements;
    using Chess.Movements.Contracts;

    public class Pawn : BaseFigure, IFigure
    {
        public Pawn(ChessColor color)
            : base(color)
        {
        }

        public override ICollection<IMovement> Move()
        {
            // TODO: Get this list from another class!
            return new List<IMovement>
                {
                    new NormalPawnMovement()
                };
        }
    }
}
