using Fr.Matthiasdetoffoli.ConquestAndInfluence.Core;
using Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;
using System.Linq;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.Screens.ScreenWithSquareTarget
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
        /// <param name="pParams">the parameters of the sceen</param>
        public override void Open(params object[] pParams)
        {
            //mTarget as to be set in the child
            if(mTarget != null)
            {
                //Unactive the controller
                AppManager.instance?.coreGameManager?.SetActiveController(false);
                base.Open();
            }
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
