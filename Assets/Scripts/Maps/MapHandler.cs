using fr.matthiasdetoffoli.ConquestAndInfluence.Maps.Squares;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Attributes;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.Maps
{
    /// <summary>
    /// Class for 
    /// </summary>
    public class MapHandler : AMonoBehaviour
    {
        #region Constants
        /// <summary>
        /// Error show when we try to add a square  where another square is
        /// </summary>
        private const string ERROR_SQUARE_ALREADY_SAVED = 
            "Can't save the square at the position x:{0} y:{0} because another square is saved at this position";
        #endregion Constants

        #region Properties
        /// <summary>
        /// the current map [x][y]
        /// </summary>
        public Dictionary<float,Dictionary<float,Square>> map;

        /// <summary>
        /// the step difference between every square on x and y
        /// </summary>
        [RangeWithStep(0.5f, 2f,0.5f)]
        public float stepBetweenSquares = 1;
        #endregion Properties

        #region Methods

        #region Unity
        protected override void Awake()
        {
            base.Awake();
            map = new Dictionary<float, Dictionary<float, Square>>();

            //Add all the square in the level
            foreach(Square lSquare in gameObject.GetComponentsInChildren<Square>(true))
            {
                //Format the position before add it in the map
                lSquare.transform.position = GetFormatedPosition(lSquare.transform.position);
                //Add the square in the map
                Add(lSquare);
            }

        }
        #endregion Unity

        /// <summary>
        /// Formate the position with the step and get it
        /// </summary>
        /// <param name="pPosition">the position to format</param>
        /// <returns>the position formated</returns>
        private Vector3 GetFormatedPosition(Vector3 pPosition)
        {
            float lFormatedX = pPosition.x;
            float lFormatedY = pPosition.y;

            //Replace the X
            if (lFormatedX % stepBetweenSquares != 0)
            {
                lFormatedX = (float)(Math.Round(lFormatedX / stepBetweenSquares) * stepBetweenSquares);
            }

            //Replace the Y
            if (lFormatedY % stepBetweenSquares != 0)
            {
                lFormatedY = (float)(Math.Round(lFormatedY / stepBetweenSquares) * stepBetweenSquares);
            }

            //If we change a value reset them
            if (lFormatedX != pPosition.x || lFormatedY != pPosition.y)
            {
                pPosition.Set(lFormatedX, lFormatedY, pPosition.z);
            }

            return pPosition;
        }

        /// <summary>
        /// Add a square in the current map
        /// </summary>
        /// <param name="pSquare">the Square to add</param>
        private void Add(Square pSquare)
        {
            float lSquareX = pSquare.transform.position.x;
            float lSquareY = pSquare.transform.position.y;

            //If the line don't exist create it
            if (map.ContainsKey(pSquare.transform.position.x) == false)
            {
                map.Add(lSquareX, new Dictionary<float, Square>());
            }

            //If something is already in log an error
            if (map[lSquareX].ContainsKey(lSquareY))
            {
                Debug.LogError(string.Format(ERROR_SQUARE_ALREADY_SAVED,lSquareX,lSquareY));
            }
            else
            {
                //Add in the map
                map[lSquareX].Add(lSquareY, pSquare);
            }
        }
        #endregion Methods
    }
}