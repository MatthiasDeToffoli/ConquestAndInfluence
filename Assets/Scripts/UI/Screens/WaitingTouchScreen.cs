using Fr.Matthiasdetoffoli.ConquestAndInfluence;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;

namespace Assets.Scripts.UI.Screens
{
    /// <summary>
    /// Screen waiting the user touch the screen
    /// </summary>
    public class WaitingTouchScreen : AWaitingUserActionScreen
    {
        #region Methods
        /// <summary>
        /// Call when the loading ended
        /// </summary>
        /// <param name="pSucceed"><c>True</c> if the loading succeed, <c>False</c> otherwise</param>
        protected override void LoadingEnded(bool pSucceed)
        {
            if (pSucceed)
            {
                AppManager.instance?.menuManager?.CloseScreen<WaitingTouchScreen>();
                //AppManager.instance?.menuManager?.SwitchScreen<WaitingTouchScreen,>();
            }
        }
        #endregion Methods
    }
}
