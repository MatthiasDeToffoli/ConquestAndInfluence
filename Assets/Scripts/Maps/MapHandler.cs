using fr.matthiasdetoffoli.ConquestAndInfluence.Maps.Squares;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Attributes;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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

        /// <summary>
        /// Get the better path for go from a position square to another
        /// </summary>
        /// <param name="pStartPos">the start position</param>
        /// <param name="pTargetPos">the position to go</param>
        /// <returns>the shorter path</returns>
        public List<Square> GetBetterPath(Vector3 pStartPos, Vector3 pTargetPos)
        {
            //If start or target positions are not valid the character can't go
            if(!CheckIfPositionIsValid(pStartPos) || !CheckIfPositionIsValid(pStartPos))
            {
                Debug.LogError("positions invalid impossible to find a path");
            }
            //If the start position and the target positions are same so we have nothing to do
            else if (pStartPos != pTargetPos)
            {
               //Get all possible paths which atteign the target position
                List<List<Square>> lPossiblesPaths = 
                    GetPossiblesPaths(pStartPos, pTargetPos, new List<List<Square>>(), true);

                //Sort by the size of the list
                lPossiblesPaths.Sort((pElmA, pElmB) => SortByCount(pElmA, pElmB));
                //Return the shorter path (it is the first because of the sort)
                return lPossiblesPaths.FirstOrDefault();
            }
            return null;
        }

        /// <summary>
        /// Get all the possible paths for go from a square's position to another one
        /// </summary>
        /// <param name="pPosToCheck">the current position to check</param>
        /// <param name="pTargetPos">the position to go</param>
        /// <param name="pPossiblePaths">the possible paths</param>
        /// <param name="pIsFirstCall">if it's the first call of the fonction</param>
        /// <returns>a list of possible path</returns>
        private List<List<Square>> GetPossiblesPaths(Vector3 pPosToCheck, Vector3 pTargetPos, List<List<Square>> pPossiblePaths, bool pIsFirstCall = false)
        {
            if(CheckIfPositionIsValid(pPosToCheck.x,pPosToCheck.y) == false)
            {
                //Remove if the path is not valid
                pPossiblePaths.RemoveAt(pPossiblePaths.Count - 1);
            }
            else
            {
                //Add a new list if the PossiblePaths has no datas
                if(pPossiblePaths.Count == 0)
                {
                    pPossiblePaths.Add(new List<Square>());
                }

                //If it's not the first square add it in the current possible path
                if(pIsFirstCall == false)
                {
                    pPossiblePaths[pPossiblePaths.Count - 1].Add(map[pPosToCheck.x][pPosToCheck.y]);
                }

                //If a path shorter was already found no need to continue
                if (TestIfPathShorterAlreadyFound(pPossiblePaths))
                {
                    pPossiblePaths.RemoveAt(pPossiblePaths.Count - 1);
                    return pPossiblePaths;
                }

                //If the position is the target position we have nothing else to do
                if (pPosToCheck.x == pTargetPos.x && pPosToCheck.y == pTargetPos.y)
                {
                    return pPossiblePaths;
                }

                List<Square> lLastList = GetNewPath(pPossiblePaths.Last());

                //Check Left only if we never checked this square
                if (CheckIfSquareWasAlreadyChecked(lLastList, pPosToCheck.x + 1, pPosToCheck.y) == false)
                {
                    pPossiblePaths = GetPossiblesPaths(new Vector3(pPosToCheck.x + 1, pPosToCheck.y), pTargetPos, pPossiblePaths);

                    //Add the old valid square in the new path
                    pPossiblePaths.Add(GetNewPath(lLastList));
                }
                    

                //Check Bottom only if we never checked this square
                if (CheckIfSquareWasAlreadyChecked(lLastList, pPosToCheck.x, pPosToCheck.y - 1) == false)
                {
                    pPossiblePaths = GetPossiblesPaths(new Vector3(pPosToCheck.x, pPosToCheck.y - 1), pTargetPos, pPossiblePaths);

                    //Add the old valid square in the new path
                    pPossiblePaths.Add(GetNewPath(lLastList));
                }

                
                //Check Right only if we never checked this square
                if (CheckIfSquareWasAlreadyChecked(lLastList, pPosToCheck.x - 1, pPosToCheck.y) == false)
                {
                    pPossiblePaths = GetPossiblesPaths(new Vector3(pPosToCheck.x - 1, pPosToCheck.y), pTargetPos, pPossiblePaths);

                    //Add the old valid square in the new path
                    pPossiblePaths.Add(GetNewPath(lLastList));
                }
                    
                //Check Top only if we never checked this square
                if (CheckIfSquareWasAlreadyChecked(lLastList, pPosToCheck.x, pPosToCheck.y + 1) == false)
                {
                    pPossiblePaths = GetPossiblesPaths(new Vector3(pPosToCheck.x, pPosToCheck.y + 1), pTargetPos, pPossiblePaths);
                }
                else
                {
                    //if we can't check this square so the current path will never atteign the target position
                    pPossiblePaths.RemoveAt(pPossiblePaths.Count - 1);
                }
            }
            //Return the current possible path
            return pPossiblePaths;
        }

        /// <summary>
        /// Test if the last path we build is longer than a path we found
        /// </summary>
        /// <param name="pPossiblePath">the list of path</param>
        /// <returns><c>true</c> if a path shorter was found, <c>false</c> otherwhise</returns>
        private bool TestIfPathShorterAlreadyFound(List<List<Square>> pPossiblePath)
        {
            List<Square> lLast = pPossiblePath.Last();

            if(pPossiblePath.Count == 0)
            {
                return false;
            }
            return pPossiblePath.FirstOrDefault(pElm => pElm != lLast && pElm.Count < lLast.Count) != null;
        }
        /// <summary>
        /// Check if the next square to check was already checked before
        /// </summary>
        /// <param name="pPosChecked">all squares already checked</param>
        /// <param name="pXToCheck">the new x to check</param>
        /// <param name="pYToCheck">the new y to check</param>
        /// <returns><c>true</c> if the square was checked,<c>false</c> if not</returns>
        private bool CheckIfSquareWasAlreadyChecked(List<Square> pPosChecked, float pXToCheck, float pYToCheck)
        {
            foreach(Square lSquare in pPosChecked)
            {
                if (lSquare.position.x == pXToCheck && lSquare.position.y == pYToCheck)
                    return true;
            }

            return false;
        }
        /// <summary>
        /// Get  a new possible path
        /// </summary>
        /// <param name="pPathToAdd">list of square with squares we have to add in the new path</param>
        /// <returns></returns>
        private List<Square> GetNewPath(List<Square> pPathToAdd)
        {
            //add a new list
            List<Square> lList = new List<Square>();

            //If the previous path has elements add it on the new one
            if (pPathToAdd.Count > 0)
                lList.AddRange(pPathToAdd);

            return lList;
        }
        /// <summary>
        /// Sort a List<list<Square>> by it size"
        /// </summary>
        /// <param name="pElmA"></param>
        /// <param name="pElmB"></param>
        /// <returns></returns>
        private int SortByCount(List<Square> pElmA, List<Square> pElmB)
        {
            if(pElmA.Count < pElmB.Count)
            {
                return -1;
            } 
            
            if(pElmA.Count == pElmB.Count)
            {
                return 0;
            }

            return 1;
        }

        /// <summary>
        /// Check if we can move on the next position
        /// </summary>
        /// <param name="pPos">the position to check</param>
        /// <returns>if we can move on or not</returns>
        public bool CheckIfPositionIsValid(Vector3 pPos)
        {
            return CheckIfPositionIsValid(pPos.x, pPos.y);
        }

        /// <summary>
        /// Check if we can move on the next position
        /// </summary>
        /// <param name="pX">the x axe position</param>
        /// <param name="pY">the y axe position</param>
        /// <returns>if we can move on or not</returns>
        public bool CheckIfPositionIsValid(float pX, float pY)
        {
            if (map.ContainsKey(pX) && map[pX].ContainsKey(pY))
            {
                return map[pX][pY].CanMoveOn;
            }

            return false;
        }
        #endregion Methods
    }
}