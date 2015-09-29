namespace Chess
{
    using System;

    using Chess.Engine;
    using Chess.Engine.Contracts;
    using Chess.Engine.Initializations;
    using Chess.InputProviders;
    using Chess.InputProviders.Contracts;
    using Chess.Renderers;
    using Chess.Renderers.Contracts;

    public static class ChessFacade
    {
        public static void Start()
        {
            IRenderer renderer = new ConsoleRenderer();
            renderer.RenderMainMenu();

            IInputProvider inputProvider = new ConsoleInputProvider();

            IChessEngine chessEngine = new StandartTwoPlayerEngine(renderer, inputProvider);

            IGameInitializationStrategy gameInitializationStrategy = new StandartStartGameInitializationStrategy();

            chessEngine.Initialize(gameInitializationStrategy);

            chessEngine.Start();

            Console.ReadLine();
        }
    }
}
