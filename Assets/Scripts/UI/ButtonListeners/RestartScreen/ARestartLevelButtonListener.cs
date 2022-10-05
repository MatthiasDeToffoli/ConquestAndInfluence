using Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.ButtonListeners.SwitchScreen;
using Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.Screens;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.ButtonListeners.RestartScreen
{
    /// <summary>
    /// Button listener for restart a level
    /// </summary>
    /// <seealso cref="ASwitchScreenButtonListener{TMenuToOpen, TMenuToClose}"/>
    public class ARestartLevelButtonListener<TMenuToOpen> : ASwitchScreenButtonListener<TMenuToOpen, PauseScreen>
        where TMenuToOpen : AMenuScreen
    {
        /// <summary>
        /// When we click on the button
        /// </summary>
        protected override void OnButtonClicked()
        {
            if (AppManager.instance != null)
            {
                AppManager.instance.mapManager?.ResetMap();
                AppManager.instance.customMenuManager?.ResetHUD();
            }
            base.OnButtonClicked();
        }
    }
}
