using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.Screens
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
                AppManager.instance?.menuManager?.SwitchScreen<WaitingTouchScreen, MainScreen>();
            }
        }
        #endregion Methods
    }
}
