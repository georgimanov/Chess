namespace Chess.Engine.Contracts
{
    using System.Collections.Generic;

    using Chess.Players.Contracts;

    public interface IChessEngine
    {
        IEnumerable<IPlayer> Players { get; }
 
        void Initialize();

        void Start();

        void WinnginConditions();
    }
}
