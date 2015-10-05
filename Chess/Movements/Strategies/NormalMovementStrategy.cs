namespace Chess.Movements.Strategies
{
    using System.Collections.Generic;

    using Chess.Movements.Contracts;

    public class NormalMovementStrategy : IMovementStrategy
    {
        private readonly IDictionary<string, IList<IMovement>> movements = new Dictionary<string, IList<IMovement>>()
        {
            {"Pawn", new List<IMovement>()
                        {
                            new NormalPawnMovement()
                        }},
                                                                                       
            {"Bishop", new List<IMovement>()
                        {
                            new NormalBishopMovement()
                        }},
            {"King", new List<IMovement>()
                        {
                            new NormalKingMovement()
                        }},
        };
        public IList<IMovement> GetMovements(string figure)
        {
            return this.movements[figure];
        }
    }
}
