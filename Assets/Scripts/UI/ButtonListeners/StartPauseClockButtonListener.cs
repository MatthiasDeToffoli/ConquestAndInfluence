using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners;
using System;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.ButtonListeners
{
    /// <summary>
    /// Button listener for start or pause the game clock
    /// </summary>
    public class StartPauseClockButtonListener : AButtonListener
    {
        #region Properties
        /// <summary>
        /// If the clock is started or not
        /// </summary>
        [NonSerialized]
        public bool isStarted = false;
        #endregion Properties

        #region Methods
        /// <summary>
        /// call when we click on the button
        /// </summary>
        protected override void OnButtonClicked()
        {
            isStarted = !isStarted;
            AppManager.instance?.coreGameManager?.StartOrPauseClock(isStarted);
        }
        #endregion Methods
    }
}
