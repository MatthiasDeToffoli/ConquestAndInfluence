using System;
using System.Collections;
using System.ComponentModel;
using UnityEngine;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.Core
{
    /// <summary>
    /// Implement the clock of a game
    /// </summary>
    public class GameClock : INotifyPropertyChanged
    {
        #region Constants
        /// <summary>
        /// the number max of step when the step is equal to it we add one day
        /// </summary>
        private const int MAX_STEP = 120;
        #endregion Constants

        #region Events
        /// <summary>
        /// Fire when a property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
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
                yield return new WaitForEndOfFrame();
                mStep+= 1 * speed;
                
                if (mStep >= MAX_STEP)
                {
                    days++;
                    //keep the excess
                    mStep -= MAX_STEP;
                }
            }

            yield return null;
        }

        /// <summary>
        /// change the speed of the clock
        /// </summary>
        public void ChangeSpeed()
        {
            int lIndex = Array.IndexOf(mPossibleSpeeds, speed);

            if(lIndex < mPossibleSpeeds.Length - 1)
            {
                speed = mPossibleSpeeds[lIndex + 1];
            }
            else
            {
                speed = mPossibleSpeeds[0];
            }
        }

        /// <summary>
        /// Reset the value of the clock
        /// </summary>
        public void Reset()
        {
            isStarted = false;
            days = 0;
            mStep = 0;
            mSpeed = 1;
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