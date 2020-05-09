using System.Collections;
using UnityEngine;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.Core
{
    /// <summary>
    /// Implement the clock of a game
    /// </summary>
    public class GameClock
    {
        #region Fields
        /// <summary>
        /// The number of frame counted in the coroutine
        /// </summary>
        private int mFrame;
        #endregion Fields

        #region Properties
        /// <summary>
        /// if the timer is started or paused
        /// </summary>
        public bool isStarted;

        /// <summary>
        /// the number of day passed until the start of the clock
        /// </summary>
        public int days;
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
                mFrame++;
                //60 frame is one day
                if (mFrame % 60 == 0)
                {
                    days++;
                    //reset the frame for not keep a big number
                    mFrame = 0;
                }
            }

            yield return null;
        }

        /// <summary>
        /// Reset the value of the clock
        /// </summary>
        public void Reset()
        {
            isStarted = false;
            days = 0;
            mFrame = 0;
        }
        #endregion Methods
    }
}