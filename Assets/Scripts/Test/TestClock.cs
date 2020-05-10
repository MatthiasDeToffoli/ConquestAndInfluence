using fr.matthiasdetoffoli.ConquestAndInfluence;
using fr.matthiasdetoffoli.ConquestAndInfluence.Core;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.Test
{
    /// <summary>
    /// unity event for test the start and the stop of a clock
    /// </summary>
    [Serializable]
    public class StartPauseUnityEvent : UnityEvent<bool> { };
    /// <summary>
    /// used for unit test of the clock
    /// </summary>
    public class TestClock : AMonoBehaviour
    {
        #region Events
        /// <summary>
        /// call for test the start or stop of the clock
        /// </summary>
        public StartPauseUnityEvent StartPauseClockEvent;

        /// <summary>
        /// used for test the speed changement of the clock
        /// </summary>
        public UnityEvent ChangeClockSpeedEvent;

        /// <summary>
        /// Used for test the reset of the clock
        /// </summary>
        public UnityEvent ResetClockEvent;
        #endregion Events

        #region Methods
        protected override void AfterStart()
        {
            base.AfterStart();
            CoreGameManager lCoreGameManager = AppManager.instance.GetFirstManager<CoreGameManager>();

            if (lCoreGameManager != null)
            {
                lCoreGameManager.ClockPropertyChanged += OnClockPropertyChanged;
            }
        }
        /// <summary>
        /// Start or stop the clock
        /// </summary>
        public void StartStopClock()
        {
            if (StartPauseClockEvent != null)
            {
                StartPauseClockEvent.Invoke(true);
            }
        }

        /// <summary>
        /// fire the change clock speed event
        /// </summary>
        public void ChangeClockSpeed()
        {
            if(ChangeClockSpeedEvent != null)
            {
                ChangeClockSpeedEvent.Invoke();
            }
        }
        
        /// <summary>
        /// fire the reset clock event
        /// </summary>
        public void ResetClock()
        {
            if(ResetClockEvent != null)
            {
                ResetClockEvent.Invoke();
            }
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

