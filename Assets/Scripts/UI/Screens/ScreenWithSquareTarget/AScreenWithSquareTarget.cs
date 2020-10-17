using fr.matthiasdetoffoli.ConquestAndInfluence.Core;
using fr.matthiasdetoffoli.ConquestAndInfluence.Maps;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.UI.Screens.ScreenWithSquareTarget
{
    /// <summary>
    /// Parent of all screen wich need a square target
    /// </summary>
    /// <seealso cref="AMenuScreen"/>
    public abstract class AScreenWithSquareTarget : AMenuScreen
    {
        #region Fields
        /// <summary>
        /// The square target
        /// </summary>
        protected Square mTarget;
        #endregion Fields

        #region Methods
        /// <summary>
        /// show the screen
        /// </summary>
        /// <param name="pSquare">the square linked to the screen</param>
        public virtual void Open(Square pSquare)
        {
            mTarget = pSquare;
            Open();
        }

        /// <summary>
        /// show the screen
        /// </summary>
        public override void Open()
        {
            //Unactive the controller
            AppManager.instance?.coreGameManager?.SetActiveController(false);
            base.Open();
        }

        /// <summary>
        /// unshow the screen
        /// </summary>
        public override void Close()
        {
            mTarget = null;
            base.Close();
        }
        #endregion Methods
    }
}
