using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager;
using System.Linq;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI
{
    /// <summary>
    /// Custom menu manager
    /// </summary>
    public class CustomMenuManager : MenuManager
    {
        #region Fields
        /// <summary>
        /// The HUD
        /// </summary>
        private Screens.HUDScreen mHUD;
        #endregion Fields

        #region Methods
        /// <summary>
        /// Start the behavior
        /// </summary>
        protected override void Start()
        {
            base.Start();

            if (mHUD == null)
            {
                mHUD = this.items.FirstOrDefault(pElm => pElm is Screens.HUDScreen) as Screens.HUDScreen;
            }

            if (mHUD == null)
            {
                Debug.LogError("HUD Not found");
            }
        }
        /// <summary>
        /// Update the number of days
        /// </summary>
        public void UpdateDays()
        {
            mHUD.days++;
        }

        /// <summary>
        /// Update the number of powers
        /// </summary>
        public void UpdatePowers()
        {
            mHUD.powers++;
        }

        /// <summary>
        /// Reset HUD Values
        /// </summary>
        public void ResetHUD()
        {
            mHUD.days = 0;
            mHUD.powers = 0;
            mHUD.startOrPauseClockBTN.isStarted = false;
        }
        #endregion Methods
    }
}
