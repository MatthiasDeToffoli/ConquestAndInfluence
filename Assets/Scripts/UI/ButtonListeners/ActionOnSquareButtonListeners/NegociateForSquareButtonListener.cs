using Fr.Matthiasdetoffoli.ConquestAndInfluence.Core.Enums;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.ButtonListeners.ActionOnSquareButtonListener
{
    /// <summary>
    /// Button listener for negociate for a square
    /// </summary>
    /// <seealso cref="AActionOnSquareButtonListener"/>
    public class NegociateForSquareButtonListener : AActionOnSquareButtonListener
    {
        #region Properties
        /// <summary>
        /// The action we will want to do
        /// </summary>
        public override ActionOnSquare action
        {
            get
            {
                return ActionOnSquare.NEGOCIATE;
            }
        }
        #endregion Properties
    }
}
