using fr.matthiasdetoffoli.ConquestAndInfluence.Core.Enums;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.UI.ButtonListeners.ActionOnSquareButtonListener
{
    /// <summary>
    /// delegate called when we click on the button link to the AActionOnSquareListener
    /// </summary>
    /// <param name="pSender">the sender of the delegate</param>
    public delegate void StartActionDelegate(AActionOnSquareButtonListener pSender);

    /// <summary>
    /// parents of all action on square button listener
    /// </summary>
    ///<seealso cref="AButtonListener"/>
    public abstract class AActionOnSquareButtonListener : AButtonListener
    {
        #region Properties
        /// <summary>
        /// Event fired when we click on the button
        /// </summary>
        public event StartActionDelegate startActionEvent;

        /// <summary>
        /// The action we will want to do
        /// </summary>
        public abstract ActionOnSquare action
        {
            get;
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// When we click on the button linked
        /// </summary>
        protected override void OnButtonClicked()
        {
            if (startActionEvent != null)
            {
                startActionEvent.Invoke(this);
            }
        }
        #endregion Methods

    }
}

