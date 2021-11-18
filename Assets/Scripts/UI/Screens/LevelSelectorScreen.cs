using Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps;
using Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.ButtonListeners;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;
using System.Linq;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.Screens
{
    public class LevelSelectorScreen : AMenuScreen
    {
        #region Fields
        /// <summary>
        /// Array of button contained in the screen
        /// </summary>
        private LevelSelectorButtonListener[] mButtons;
        #endregion Fields

        #region Methods
        #region Unity
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            mButtons = gameObject.GetComponentsInChildren<LevelSelectorButtonListener>();
        }
        #endregion Unity

        /// <summary>
        /// Listen all events here
        /// </summary>
        protected override void ListenToEvents()
        {
            base.ListenToEvents();

            if (AppManager.instance.mapManager != null)
            {
                AppManager.instance.mapManager.unlockLevel += OnUnlockLevel;
            }
        }

        /// <summary>
        /// When we're notify to unlock a level
        /// </summary>
        /// <param name="pIndex">the index of the level to unlock</param>
        private void OnUnlockLevel(int pIndex)
        {
            mButtons.FirstOrDefault(pElm => pElm.levelIndexToSelect == pIndex)?.Unlock();
        }

        /// <summary>
        /// unlisten all events here
        /// </summary>
        protected override void UnlistenToEvents()
        {
            base.UnlistenToEvents();
            
            if(AppManager.instance.mapManager != null)
            {
                AppManager.instance.mapManager.unlockLevel -= OnUnlockLevel;
            }
        }

        #endregion Methods
    }
}
