namespace Chess.Engine
{
    using System;
    using System.Collections.Generic;

    using Chess.Board;
    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Engine.Contracts;
    using Chess.Figures.Contracts;
    using Chess.InputProviders.Contracts;
    using Chess.Players;
    using Chess.Players.Contracts;
    using Chess.Renderers.Contracts;

    public class StandartTwoPlayerEngine : IChessEngine
    {
        private IList<IPlayer> players;
        private readonly IRenderer renderer;
        private readonly IInputProvider input;

        private readonly IBoard board;

        private int currentPlayerIndex;

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

            // TODO: If players are changed - board is reversed
            this.players = new List<IPlayer>
            {
                new Player("[Black]Gosho", ChessColor.Black),
                new Player("[White]Pesho", ChessColor.White),
            };

            this.SetFirstPlayerIndex();
            
            // Use this
            //var players = this.input.GetPlayers(GlobalConstants.StandartGameNumberOfPlayers);
            gameInitializationStrategy.Initialize(players, this.board);
            this.renderer.RenderBoard(this.board);
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var player = this.GetNextPlayer();
                    var move = this.input.GetNextPlayerMove(player);
                    var from = move.From;
                    var figure = this.board.GetFigureAtPosition(from);
                    this.CheckIfPlayerOwnsFigure(player, figure, from);


                }
                catch (Exception exception)
                {
                    this.currentPlayerIndex--;
                    this.renderer.PrintErrorMessage(exception.Message);
                }
            }

           
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

        private IPlayer GetNextPlayer()
        {
            this.currentPlayerIndex++;
            if (this.currentPlayerIndex >= this.players.Count)
            {
                this.currentPlayerIndex = 0;
            }

            return this.players[this.currentPlayerIndex];
        }

        private void SetFirstPlayerIndex()
        {
            for (int i = 0; i < this.players.Count; i++)
            {
                if (this.players[i].Color == ChessColor.White)
                {
                    this.currentPlayerIndex = i - 1;
                    return;
                }
            }
        }

        private void CheckIfPlayerOwnsFigure(IPlayer player, IFigure figure, Position from)
        {
            if (figure == null)
            {
                throw new InvalidOperationException(string.Format("Position {0}{1} is empty", from.Col, from.Row));
            }

            if (figure.Color != player.Color)
            {
                throw new InvalidOperationException(string.Format("Figure at this position {0}{1} is not yours", from.Col, from.Row));
            }
        }
    }
}
