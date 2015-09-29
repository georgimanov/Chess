﻿namespace Chess.InputProviders.Contracts
{
    using System.Collections.Generic;

    using Chess.Players.Contracts;

    public interface IInputProvider
    {
        IList<IPlayer> GetPlayers(int numberOfPlayers);
    }
}
