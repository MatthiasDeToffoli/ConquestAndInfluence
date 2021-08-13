using Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps;
using Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.Screens;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.ButtonListeners
{
    /// <summary>
    /// Button listener used for select a level
    /// </summary>
    public class LevelSelectorButtonListener : AButtonListener
    {
        #region Properties
        /// <summary>
        /// The level to select with this button
        /// </summary>
        [SerializeField]
        public int levelIndexToSelect;
        #endregion Properties

        #region Methods
        /// <summary>
        /// Unlock the button for can start the next level
        /// </summary>
        public void Unlock()
        {
            mButton.interactable = true;
        }
        /// <summary>
        /// call when we click on the button
        /// </summary>
        protected override void OnButtonClicked()
        {
            AppManager.instance.GetFirstManager<MapManager>()?.SelectLevel(levelIndexToSelect);
            gameObject.GetComponentInParent<LevelSelectorScreen>()?.Close();
        }
        #endregion Methods
    }
}
