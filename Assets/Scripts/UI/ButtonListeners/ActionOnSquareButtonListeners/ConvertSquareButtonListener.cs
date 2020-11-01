using Fr.Matthiasdetoffoli.ConquestAndInfluence.Core.Enums;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.ButtonListeners.ActionOnSquareButtonListener
{
    /// <summary>
    /// Button listener for convert square action
    /// </summary>
    /// <seealso cref="AActionOnSquareButtonListener"/>
    public class ConvertSquareButtonListener : AActionOnSquareButtonListener
    {
        #region Properties
        /// <summary>
        /// The action we will want to do
        /// </summary>
        public override ActionOnSquare action
        {
            get
            {
                return ActionOnSquare.CONVERT;
            }
        }
        #endregion Properties
    }
}
