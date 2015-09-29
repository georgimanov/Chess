namespace Chess.Engine
{
    using System.Collections.Generic;

    using Chess.Board;
    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Engine.Contracts;
    using Chess.InputProviders.Contracts;
    using Chess.Players;
    using Chess.Players.Contracts;
    using Chess.Renderers.Contracts;

    public class StandartTwoPlayerEngine : IChessEngine
    {
        private readonly IList<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;

        private readonly IBoard board;


        public StandartTwoPlayerEngine(IRenderer renderer, IInputProvider inputProvider  )
        {
            this.renderer = renderer;
            this.input = inputProvider;
            this.board = new Board();
        }

        public void Initialize(IGameInitializationStrategy gameInitializationStrategy)
        {
            // TODO: Remove
            // using Chess.Players;
            // Added for development purposes only 
            var players = new List<IPlayer>
            {
                new Player("Pesho", ChessColor.Black),
                new Player("Gosho", ChessColor.White),
            };

            // Use this
            //var players = this.input.GetPlayers(GlobalConstants.StandartGameNumberOfPlayers);
            gameInitializationStrategy.Initialize(players, this.board);
            this.renderer.RenderBoard(this.board);
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
