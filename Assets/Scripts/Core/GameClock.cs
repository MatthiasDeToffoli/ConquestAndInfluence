﻿using System;
using System.Collections;
using System.ComponentModel;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.Core
{
    /// <summary>
    /// Used for say the percent of day changed
    /// </summary>
    /// <param name="pPercent"></param>
    public delegate void PercentOfDayDelegate(float pPercent);

    /// <summary>
    /// Implement the clock of a game
    /// </summary>
    public class GameClock : INotifyPropertyChanged
    {
        #region Constants
        /// <summary>
        /// the number max of step when the step is equal to it we add one day (5 seconds for 60 frames per seconds)
        /// </summary>
        private const int MAX_STEP = 100;
        #endregion Constants

        #region Events
        /// <summary>
        /// Fire when a property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Fire when the percent of day change
        /// </summary>
        public event PercentOfDayDelegate PercentOfDayChanged;
        #endregion Events

        #region Fields
        /// <summary>
        /// The number of frame counted in the coroutine
        /// </summary>
        private float mStep;

        /// <summary>
        /// The speed of the clock
        /// </summary>
        private float mSpeed;

        /// <summary>
        /// if the timer is started or paused
        /// </summary>
        private bool mIsStarted;

        /// <summary>
        /// the number of day passed until the start of the clock
        /// </summary>
        private int mDays;

        /// <summary>
        /// the possible speeds
        /// </summary>
        private readonly float[] mPossibleSpeeds = new float[5] { 0.25f, 0.5f, 1, 2, 4 };
        #endregion Fields

        #region Properties
        /// <summary>
        /// if the timer is started or paused
        /// </summary>
        public bool isStarted
        {
            get
            {
                return mIsStarted;
            }
            set
            {
                mIsStarted = value;
                NotifyPropertyChanged("isStarted");
            }
        }

        /// <summary>
        /// the number of day passed until the start of the clock
        /// </summary>
        public int days
        {
            get
            {
                return mDays;
            }
            set
            {
                mDays = value;
                NotifyPropertyChanged("days");
            }
        }

        /// <summary>
        /// The speed of the clock
        /// </summary>
        public float speed
        {
            get
            {
                return mSpeed;
            }
            set
            {
                mSpeed = value;
                NotifyPropertyChanged("speed");
            }
        }
        #endregion Properties

        #region Constructors
        /// <summary>
        /// Initialize an instance of the class <see cref="GameClock"/>
        /// </summary>
        public GameClock()
        {
            Reset();
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Count the days in a game (60 frame is one day)
        /// </summary>
        /// <returns></returns>
        public IEnumerator Count()
        {
            while (isStarted)
            {
                NotifyPercentOfDatChanged(mStep / MAX_STEP);

                yield return new WaitForSeconds(0.01f);
                mStep+= 1 * speed;
                
                if (mStep >= MAX_STEP)
                {
                    //For notify a day just finished
                    NotifyPercentOfDatChanged(1);
                    days++;
                    //keep the excess
                    mStep -= MAX_STEP;

                    // For init proporties of listener of days
                    NotifyPercentOfDatChanged(0);
                }
            }

            yield return null;
        }

        /// <summary>
        /// Get the speed index
        /// </summary>
        /// <returns></returns>
        public int GetSpeedIndex()
        {
            return Array.IndexOf(mPossibleSpeeds, speed);
        }

        /// <summary>
        /// change the speed of the clock
        /// </summary>
        /// <returns>The new speed index</returns>
        public int ChangeSpeed()
        {
            int lIndex = Array.IndexOf(mPossibleSpeeds, speed);

            if(lIndex < mPossibleSpeeds.Length - 1)
            {
                lIndex++;
            }
            else
            {
                lIndex = 0;   
            }

            speed = mPossibleSpeeds[lIndex];

            return lIndex;
        }

        /// <summary>
        /// Reset the value of the clock
        /// </summary>
        public void Reset()
        {
            isStarted = false;
            days = 0;
            mStep = 0;
            mSpeed = mPossibleSpeeds[2];
        }

        /// <summary>
        /// Notify the percent of day changed
        /// </summary>
        /// <param name="pPercent"></param>
        private void NotifyPercentOfDatChanged(float pPercent)
        {
            if(PercentOfDayChanged != null)
            {
                PercentOfDayChanged.Invoke(pPercent);
            }
        }
        /// <summary>
        /// Fire the property changed event
        /// </summary>
        /// <param name="pPropertyName">the name of the property</param>
        public void NotifyPropertyChanged(string pPropertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(pPropertyName));
            }
        }
        #endregion Methods
    }
}