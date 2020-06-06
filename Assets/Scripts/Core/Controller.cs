using fr.matthiasdetoffoli.ConquestAndInfluence.Maps;
using UnityEngine;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.Core
{
    /// <summary>
    /// Manage the mouse or touch control and hit
    /// </summary>
    public class Controller
    {
        #region Fields
        /// <summary>
        /// If we use mouse or touch
        /// </summary>
        private bool mUseMouse;

        /// <summary>
        /// If the mouse left button is down or not
        /// </summary>
        private bool mMouseLeftButtonDown;

        /// <summary>
        /// The map manager
        /// </summary>
        private MapManager mMapManager;
        #endregion Fields

        #region Properties
        /// <summary>
        /// if the controller is activated or not
        /// </summary>
        public bool isActivated;

        /// <summary>
        /// The square which was hit by the touch or the mouse
        /// </summary>
        public Square squareHit
        {
            get;
            private set;
        }
        #endregion Properties

        #region Constructors
        /// <summary>
        /// Initialize an instance of the class <see cref="Controller"/>
        /// </summary>
        /// <param name="pMapManager">the map manager</param>
        public Controller(MapManager pMapManager)
        {
            mMapManager = pMapManager;
            #if UNITY_EDITOR
                mUseMouse = true;
            #elif UNITY_IOS || UNITY_ANDROID
                mUseMouse = false;
            #endif
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Try to hit a square with the mouse or the touch
        /// </summary>
        /// <param name="pSquare">the square we will get if we hit it</param>
        /// <returns><c>true</c> if we hit a square, <c>false</c> otherwise</returns>
        public bool TryHitSquare() 
        {
            if (isActivated)
            {
                //If we up the left mouse button
                if (mUseMouse)
                {
                    if (mMouseLeftButtonDown)
                    {
                        if (Input.GetMouseButtonUp(0))
                        {
                            mMouseLeftButtonDown = false;
                            return TryHitSquare(Input.mousePosition);
                        }
                    }
                    else
                    {
                        mMouseLeftButtonDown = Input.GetMouseButtonDown(0);
                    }
                }
                else if (mUseMouse == false && Input.touchCount > 0)
                {
                    //Take the first touch
                    Touch lTouch = Input.touches[0];

                    //If we end the touch
                    if(lTouch.phase == TouchPhase.Ended)
                    {
                        return TryHitSquare(lTouch.position);
                    }
                }
            }
            
            return false ;
        }

        /// <summary>
        /// Try to hit a square with the mouse or the touch
        /// </summary>
        /// <param name="pSquare">the square we will get if we hit it</param>
        /// <returns><c>true</c> if we hit a square, <c>false</c> otherwise</returns>
        private bool TryHitSquare(Vector3 pPos)
        {
            //Translate the mouse or touch position to a world map formated position
            Vector2 lXY = mMapManager.currentMap.GetFormatedPosition(Camera.main.ScreenToWorldPoint(pPos));

            //If we touch a square
            if (mMapManager.currentMap.map.ContainsKey(lXY.x)
                && mMapManager.currentMap.map[lXY.x].ContainsKey(lXY.y))
            {
                squareHit = mMapManager.currentMap.map[lXY.x][lXY.y];

                return squareHit.CanMoveOn;
            }
            return false;
        }
        /// <summary>
        /// Clear the current hit
        /// </summary>
        public void ClearHit()
        {
            squareHit = null;

            //Activate for can pick another square
            isActivated = true;
        }
        #endregion Methods
    }
}
