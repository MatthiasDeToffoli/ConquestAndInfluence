using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners.CloseScreenButtonListeners.SwitchScreenButtonListeners;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.Screens
{
    public class MainScreen : AMenuScreen
    {
        #region Fields
        /// <summary>
        /// The multi button
        /// </summary>
        [SerializeField]
        private SwitchScreenButtonListener mMultiButton;
        #endregion Fields

        #region Methods
        /// <summary>
        /// Start of the behaviour
        /// </summary>
        protected override void Start()
        {
            base.Start();

            if (mMultiButton != null)
            {
                mMultiButton.Isinteractable = false;
            }
        }
        #endregion Methods
    }
}
