using Fr.Matthiasdetoffoli.ConquestAndInfluence;
using Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.ButtonListeners.RestartScreen;
using Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.Screens;

namespace Assets.Scripts.UI.ButtonListeners.RestartScreen
{
    /// <summary>
    /// Button listener for return to menu from a level
    /// </summary>
    /// <seealso cref="ARestartLevelButtonListener{TMenuToOpen}"/>
    public class ReturnToMenuButtonListener : ARestartLevelButtonListener<LevelSelectorScreen>
    {
        /// <summary>
        /// When we click on the button
        /// </summary>
        protected override void OnButtonClicked()
        {
            base.OnButtonClicked();
            AppManager.instance?.mapManager?.ClearCurrentLevel();
        }
    }
}
