namespace Chess.InputProviders
{
    using System;
    using System.Collections.Generic;

    using Chess.Common;
    using Chess.Common.Console;
    using Chess.InputProviders.Contracts;
    using Chess.Players;
    using Chess.Players.Contracts;

    public class ConsoleInputProvider : IInputProvider
    {
        private const string PlayerNameText = "Enter player {0} name: ";

        public IList<IPlayer> GetPlayers(int numberOfPlayers)
        {
            var players = new List<IPlayer>();
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.Clear();
                ConsoleHelpers.SetCursorAtCenter(PlayerNameText.Length);
                Console.Write(string.Format(PlayerNameText, i));
                string name = Console.ReadLine();
                var player = new Player(name, (ChessColor)i - 1);
                players.Add(player);
            }

            return players;
        }

        /// <summary>
        /// Command is in format 
        ///     a5-c5
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public Move GetNextPlayerMove(IPlayer player)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            var message = string.Format("{0} is next: ", player.Name);
            
            ConsoleHelpers.SetCursorTopCenter(message.Length);
            Console.WriteLine(message);
            ConsoleHelpers.SetCursorReadyToAcceptCommands(message.Length);
            
            var positionAsString = Console.ReadLine().Trim().ToLower();
            var move = ConsoleHelpers.CreateMoveFromCommand(positionAsString);
           
            return move;
        }
    }
}