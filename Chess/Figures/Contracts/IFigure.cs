namespace Chess.Figures.Contracts
{
    using System.Collections.Generic;

    using Chess.Common;
    using Chess.Movements.Contracts;

    public interface IFigure
    {
        ChessColor Color { get; }

        ICollection<IMovement> Move(IMovementStrategy movementStrategy);
    }
}
