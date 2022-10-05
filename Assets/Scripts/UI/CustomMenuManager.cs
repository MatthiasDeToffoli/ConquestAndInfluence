using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;
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
        /// Do the action to open a screen
        /// </summary>
        /// <param name="pScreenToOpen"></param>
        /// <param name="pParams">the parametters of the screen to open</param>
        public override void OpenScreen(AMenuScreen pScreenToOpen, params object[] pParams)
        {
            if (AppManager.instance != null && AppManager.instance.coreGameManager != null)
            {
                AppManager.instance.coreGameManager.SetActiveController(pScreenToOpen is Screens.HUDScreen);
                AppManager.instance.coreGameManager.StartOrPauseClock(false);
            }

            mHUD.startOrPauseClockBTN.isStarted = false;

            base.OpenScreen(pScreenToOpen, pParams);
        }

        /// <summary>
        /// Do the action to switch screens
        /// </summary>
        /// <param name="pScreenToClose"></param>
        /// <param name="pScreenToOpen"></param>
        /// <param name="pScreenToOpenParams">the parametters of the screen to open</param>
        public override void SwitchScreen(AMenuScreen pScreenToClose, AMenuScreen pScreenToOpen, params object[] pScreenToOpenParams)
        {
            if(AppManager.instance != null && AppManager.instance.coreGameManager != null)
            {
                AppManager.instance.coreGameManager.SetActiveController(pScreenToOpen is Screens.HUDScreen);
                AppManager.instance.coreGameManager.StartOrPauseClock(false);
            }
            
            mHUD.startOrPauseClockBTN.isStarted = false;


            base.SwitchScreen(pScreenToClose, pScreenToOpen, pScreenToOpenParams);
        }

        /// <summary>
        /// Update the number of days
        /// </summary>
        /// <param name="pDays">The number of days</param>
        public void UpdateDays(int pDays)
        {
            mHUD.days = pDays;
        }

        /// <summary>
        /// Update the number of powers
        /// </summary>
        /// <param name="pPowers">The powers value</param>
        public void UpdatePowers(int pPowers)
        {
            mHUD.powers = pPowers;
        }

        /// <summary>
        /// Reset HUD Values
        /// </summary>
        public void ResetHUD()
        {
            if(mHUD != null)
            {
                mHUD.days = 0;
                mHUD.powers = 0;
                mHUD.startOrPauseClockBTN.isStarted = false;

                if(AppManager.instance != null && AppManager.instance.coreGameManager != null)
                    mHUD.clockSpeedBTN.ResetText(AppManager.instance.coreGameManager.GetClockSpeedIndex());
            }
            
        }

        /// <summary>
        /// Set the clock previous state (if it was start or pause before opening the validation path screen)
        /// </summary>
        /// <param name="pState"></param>
        public void SetClockPreviousState(bool pState)
        {
            Screens.ValidationPathScreen lValidPathScreen = items.FirstOrDefault(pElm => pElm is Screens.ValidationPathScreen) as Screens.ValidationPathScreen;

            if(lValidPathScreen != null)
            {
                lValidPathScreen.clockPreviousState = pState;
            }
        }
        #endregion Methods
    }
}
