namespace fr.matthiasdetoffoli.ConquestAndInfluence.Core.Levels.Squares
{
    /// <summary>
    /// Enume for define the side of a square
    /// </summary>
    public enum SquareSide
    {
        /// <summary>
        /// Squares with no side are neutral
        /// </summary>
        NEUTRAL = 0,
        /// <summary>
        /// Squares took by the player
        /// </summary>
        ALLY = 1,
        /// <summary>
        /// Squares took by the opponent
        /// </summary>
        ENEMY = -1
    }
}

