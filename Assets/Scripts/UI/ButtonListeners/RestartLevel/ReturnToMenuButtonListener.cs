using Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.Screens;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.ButtonListeners.RestartLevel
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
            AppManager.instance?.coreGameManager?.UnactivePlayerCharacter();
            AppManager.instance?.mapManager?.ClearCurrentLevel();
        }
    }
}
