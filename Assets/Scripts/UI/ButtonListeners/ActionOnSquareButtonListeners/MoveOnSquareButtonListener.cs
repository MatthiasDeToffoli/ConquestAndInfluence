using fr.matthiasdetoffoli.ConquestAndInfluence.Core.Enums;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.UI.ButtonListeners.ActionOnSquareButtonListener
{
    /// <summary>
    /// Button listener for move on square action
    /// </summary>
    /// <seealso cref="AActionOnSquareButtonListener"/>
    public class MoveOnSquareButtonListener : AActionOnSquareButtonListener
    {
        #region Properties
        /// <summary>
        /// The action we will want to do
        /// </summary>
        public override ActionOnSquare action
        {
            get
            {
                return ActionOnSquare.NONE;
            }
        }
        #endregion Properties
    }
}
