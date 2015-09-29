namespace Chess.Board
{
    using System;

    using Chess.Board.Contracts;
    using Chess.Common;
    using Chess.Figures.Contracts;

    public class Board : IBoard
    {
        private readonly IFigure[,] board;

        public Board(
            int rows = GlobalConstants.StandartGameTotalBoardRows,
            int cols = GlobalConstants.StandartGameTotalBoardCols)
        {
            this.TotalRows = rows;
            this.TotalCols = cols;
            this.board = new IFigure[rows, cols];
        }

        public int TotalRows { get; private set; }
       
        public int TotalCols { get; private set; }

        public void AddFigure(IFigure figure, Position position)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);

            this.CheckIfPositionIsValid(position);

            int arrRow = this.GetArrayRow(position.Row);
            int arrCol = this.GetArrayCol(position.Col);
            this.board[arrRow, arrCol] = figure;
        }

        public void RemoveFigure(Position position)
        {
            this.CheckIfPositionIsValid(position);

            int arrRow = this.GetArrayRow(position.Row);
            int arrCol = this.GetArrayCol(position.Col);
            this.board[arrRow, arrCol] = null;
        }

        public IFigure GetFigureAtPosition(Position position)
        {
            int arrRow = this.GetArrayRow(position.Row);
            int arrCol = this.GetArrayCol(position.Col);

            return this.board[arrRow, arrCol];
        }

        private int GetArrayRow(int chessRow)
        {
            return this.TotalRows - chessRow;
        }

        private int GetArrayCol(char chessCol)
        {
            // TODO: lower & uppercase
            return chessCol - 'a';
        }

        private void CheckIfPositionIsValid(Position position)
        {
            if (position.Row < GlobalConstants.MinimumRowValueOnBoard || 
                position.Row > GlobalConstants.MaximumRowValueOnBoard)
            {
                throw new IndexOutOfRangeException("Selected row position is not valid");
            }

            if (position.Col < GlobalConstants.MinimumColValueOnBoard || 
                position.Col > GlobalConstants.MaximumColValueOnBoard)
            {
                throw new IndexOutOfRangeException("Selected col position is not valid");
            }
        }
    }
}
