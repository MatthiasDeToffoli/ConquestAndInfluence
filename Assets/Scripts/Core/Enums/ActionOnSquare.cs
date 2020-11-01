namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.Core.Enums
{
    /// <summary>
    /// Enum describe the actions on a square
    /// </summary>
    public enum ActionOnSquare
    {
        /// <summary>
        /// None used for just a move or stay
        /// </summary>
        NONE = 0,
        /// <summary>
        /// Convert an empty square
        /// </summary>
        CONVERT = 1,
        /// <summary>
        /// Attack a square
        /// </summary>
        ATTACK = 2,
        /// <summary>
        /// Negociate for converte a square
        /// </summary>
        NEGOCIATE = 3,
        /// <summary>
        /// Buy a square
        /// </summary>
        BUY = 4,
        /// <summary>
        /// Upgrade a square
        /// </summary>
        UPGRADE = 5
    }
}
