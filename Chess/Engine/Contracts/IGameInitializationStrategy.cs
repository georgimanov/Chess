namespace Chess.Engine.Contracts
{
    using System.Collections.Generic;

    using Chess.Board.Contracts;
    using Chess.Players.Contracts;

    public interface IGameInitializationStrategy
    {
        void Initialize(IList<IPlayer> players, IBoard board);
    }
}
