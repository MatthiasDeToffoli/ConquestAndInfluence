﻿using Fr.Matthiasdetoffoli.ConquestAndInfluence.Core;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using System.ComponentModel;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.Test
{
    /// <summary>
    /// used for unit test of the clock
    /// </summary>
    /// <seealso cref="AMonoBehaviour"/>
    public class TestClock : AMonoBehaviour
    {
        #region Methods
        protected override void AfterStart()
        {
            base.AfterStart();
            CoreGameManager lCoreGameManager = AppManager.instance?.coreGameManager;

            if (lCoreGameManager != null)
            {
                lCoreGameManager.ClockPropertyChanged += OnClockPropertyChanged;
            }
        }
        /// <summary>
        /// Start or stop the clock
        /// </summary>
        /// <param name="pStartOrPause">if we start or pause the ckicj</param>
        public void StartStopClock(bool pStartOrPause)
        {
            AppManager.instance?.coreGameManager?.StartOrPauseClock(pStartOrPause);
        }

        /// <summary>
        /// fire the change clock speed event
        /// </summary>
        public void ChangeClockSpeed()
        {
            AppManager.instance?.coreGameManager?.ChangeClockSpeed();
        }
        
        /// <summary>
        /// fire the reset clock event
        /// </summary>
        public void ResetClock()
        {
            AppManager.instance?.coreGameManager?.ResetClock();
        }
        /// <summary>
        /// When a clock property changed
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pEventArgs"></param>
        private void OnClockPropertyChanged(object pSender, PropertyChangedEventArgs pEventArgs)
        {
            if (pSender is GameClock)
            {
                GameClock lClock = pSender as GameClock;

                switch (pEventArgs.PropertyName)
                {
                    case "isStarted":
                        if (lClock.isStarted)
                        {
                            Debug.Log("Clock started");
                        }
                        else
                        {
                            Debug.Log("Clock paused");
                        }
                        break;
                    case "speed":
                        Debug.Log(string.Format("Speed : x{0}", lClock.speed));
                        break;
                    case "days":
                        Debug.Log(string.Format("{0} day(s)",lClock.days));
                        break;
                }
                
            }
        }
        #endregion Methods
    }
}

