namespace Chess.Engine
{
    using System.Collections.Generic;

    using Chess.Engine.Contracts;
    using Chess.Players.Contracts;

    public class StandartTwoPlayerEngine : IChessEngine
    {
        private readonly IEnumerable<IPlayer> players; 

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void Start()
        {
            throw new System.NotImplementedException();
        }

        public void WinnginConditions()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IPlayer> Players
        {
            get
            {
                return new List<IPlayer>(this.players);
            }
        }
    }
}
