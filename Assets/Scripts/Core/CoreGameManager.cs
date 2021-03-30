using Fr.Matthiasdetoffoli.ConquestAndInfluence.Core.Characters;
using Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps;
using Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.Screens;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.Core
{
    /// <summary>
    /// Manage all the game
    /// </summary>
    /// <seealso cref="AManagedManager"/>
    public class CoreGameManager : AManagedManager
    {
        #region Events
        /// <summary>
        /// Fire when a GameClock property changed
        /// </summary>
        public event PropertyChangedEventHandler ClockPropertyChanged
        {
            add
            {
                if(mClock != null)
                {
                    mClock.PropertyChanged += value;
                }
            }
            remove
            {
                if(mClock != null)
                {
                    mClock.PropertyChanged -= value;
                }
            }
        }
        #endregion Events

        #region Fields
        /// <summary>
        /// the current game clock
        /// </summary>
        private GameClock mClock;

        /// <summary>
        /// The coroutine count of the clock
        /// </summary>
        private IEnumerator mCount;

        /// <summary>
        /// The game controller
        /// </summary>
        private Controller mController;

        /// <summary>
        /// The main player character
        /// </summary>
        [SerializeField]
        private PlayerCharacter mPlayerCharacter;
        #endregion Fields

        #region Methods
        /// <summary>
        /// Listen all events
        /// </summary>
        protected override void ListenToEvents()
        {
            base.ListenToEvents();
            mClock.PercentOfDayChanged += OnPercentOfDayChanged;
        }

        /// <summary>
        /// Unlisten all evenes
        /// </summary>
        protected override void UnlistenToEvents()
        {
            base.UnlistenToEvents();
            mClock.PercentOfDayChanged -= OnPercentOfDayChanged;
        }
        #region Unity
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            mClock = new GameClock();
        }

        /// <summary>
        /// Start of the behavior
        /// </summary>
        protected override void Start()
        {
            base.Start();

            //At start for be sure the appmanager is created
            mController = new Controller();
        }
        /// <summary>
        /// Behavior loop
        /// </summary>
        protected void Update()
        {
            CheckHit();
        }
        #endregion Unity

        #region Clock
        /// <summary>
        /// Start or pause the current clock
        /// </summary>
        /// <param name="pIsStarting"></param>
        public void StartOrPauseClock(bool pIsStarting)
        {
            //if the state is the same nothing to do
            if(mClock.isStarted == pIsStarting)
            {
                return;
            }

            mClock.isStarted = pIsStarting;

            if (pIsStarting)
            {
                mCount = mClock.Count();
                StartCoroutine(mCount);
            }
            else if(mCount != null)
            {
                StopCoroutine(mCount);
                mCount = null;
            }
        }

        /// <summary>
        /// Change the clock speed
        /// </summary>
        public void ChangeClockSpeed()
        {
            if(mClock != null)
            {
                mClock.ChangeSpeed();
            }
        }

        /// <summary>
        /// Reset the clock
        /// </summary>
        public void ResetClock()
        {
            //stop the current coroutine
            StartOrPauseClock(false);

            mClock.Reset();
        }

        /// <summary>
        /// Call when percent of day changed
        /// </summary>
        /// <param name="pPercent"></param>
        private void OnPercentOfDayChanged(float pPercent)
        {
            if(mPlayerCharacter != null)
                mPlayerCharacter.ClockUpdate(pPercent);
        }
        #endregion Clock

        #region Controller
        /// <summary>
        /// Active or unactive the game controller
        /// </summary>
        /// <param name="pIsActive"></param>
        public void SetActiveController(bool pIsActive)
        {
            if(mController != null)
                mController.isActivated = pIsActive;
        }
        /// <summary>
        /// Check if we hit something with the touch or the mouse
        /// </summary>
        private void CheckHit()
        {
            if (mController.TryHitSquare())
            {
                CheckSquare(mController.squareHit);
            }
        }
        #endregion Controller

        /// <summary>
        /// Start an action on a square
        /// </summary>
        /// <param name="pAction"></param>
        public void CheckSquare(Square pSquare)
        {
            mPlayerCharacter.canMove = false;
            mPlayerCharacter.path = AppManager.instance?.mapManager?.FindPath(mPlayerCharacter.currentPosition.position, pSquare.position);

            if(mPlayerCharacter.path != null)
            {
                string lFeedBackId = AppManager.instance?.visualFeedBakcManager?.ShowMovingCaseVisualFeedback(mPlayerCharacter.path);
                AppManager.instance?.menuManager?.OpenScreen<ValidationPathScreen>(lFeedBackId);
            }
        }

        /// <summary>
        /// Do the action on a square
        /// </summary>
        public void OrderActionOnSquare()
        {
            SetActiveController(true);
            mPlayerCharacter.canMove = true;
        }

        #endregion Methods
    }
}

