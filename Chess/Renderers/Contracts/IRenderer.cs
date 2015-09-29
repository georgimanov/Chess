namespace Chess.Renderers.Contracts
{
    using Chess.Board.Contracts;

    public interface IRenderer
    {
        void RenderMainMenu();

        void RenderBoard(IBoard board);
    }
}
