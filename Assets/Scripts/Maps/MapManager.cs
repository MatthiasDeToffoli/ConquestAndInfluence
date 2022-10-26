using Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps.Enums;
using Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.Screens;
using Fr.Matthiasdetoffoli.GlobalProjectCode.Classes.Utils;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager;
using System.Collections.Generic;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps
{
    /// <summary>
    /// Delegate fire for unlock a level
    /// </summary>
    /// <param name="pLevelIndex">the index of the level to unlock</param>
    public delegate void UnlockLevelDelegate(int pLevelIndex);

    /// <summary>
    /// Manager used for managed all the maps
    /// </summary>
    /// <seealso cref="AManagerWithList{T}"/>
    public class MapManager : ALevelsManager<MapHandler>
    {
        #region Events
        /// <summary>
        /// Event fire for unlock a level
        /// </summary>
        public event UnlockLevelDelegate unlockLevel;
        #endregion Events

        #region Constants
        /// <summary>
        /// Error when we try to select a map which not exist
        /// </summary>
        private const string ERROR_SELECT_WRONG_MAP = "you try to select a map which not exist";
        #endregion Constants

        #region Properties
        /// <summary>
        /// The current selected map
        /// </summary>
        public MapHandler currentMap
        {
            get;
            private set;
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Select a level and unselect another one
        /// </summary>
        /// <param name="pIndex"></param>
        public override void SelectLevel(int pIndex)
        {
            currentMap = null;

            if (items.Count - 1 < pIndex)
            {
                Debug.LogError(ERROR_SELECT_WRONG_MAP);
            }
            else
            {
                base.SelectLevel(pIndex);

                MapHandler lCurrentMap = null;
                if(items.TryToGetValue(pIndex, out lCurrentMap))
                {
                    if(lCurrentMap == null)
                    {
                        Debug.LogError(ERROR_SELECT_WRONG_MAP);
                    }
                    else
                    {
                        currentMap = lCurrentMap;
                        AppManager.instance.coreGameManager?.MapSelected(lCurrentMap.PlayerStartPosition);
                    }
                }
                else
                {
                    Debug.LogError(ERROR_SELECT_WRONG_MAP);
                }
            }
        }

        /// <summary>
        /// Find the best path from a start position to a target position
        /// </summary>
        /// <param name="pStartPos">the start position</param>
        /// <param name="pTargetPos">the target position</param>
        /// <returns>the shorter path found</returns>
        public List<Square> FindPath(Vector3 pStartPos, Vector3 pTargetPos)
        {
            if(currentMap != null)
            {
                return currentMap.GetBetterPath(pStartPos, pTargetPos);
            }
            return null;
        }

        public Dictionary<Square, SquareSide> UpdateSquares(IEnumerable<string> pIgnoredSquaresId, Dictionary<Square, SquareSide> pSquaresToConvert)
        {
            if(currentMap != null)
            {
                bool lLevelIsWin = this.currentMap.UpdateSquares(pIgnoredSquaresId, ref pSquaresToConvert);

                if (lLevelIsWin)
                {
                    int lLevelIndex = items.IndexOf(currentMap);

                    if (lLevelIndex < items.Count - 1)
                    {
                        this.NotifyUnlockLevel(lLevelIndex + 1);
                    }

                    AppManager.instance.menuManager.SwitchScreen<HUDScreen, VictoryScreen>();
                }
            }
            else
            {
                Debug.LogError("currentMap is null can't update squares");
            }
            return pSquaresToConvert;
        }

        /// <summary>
        /// Notify the unlock level event
        /// </summary>
        /// <param name="pLevelIndex"></param>
        public void NotifyUnlockLevel(int pLevelIndex)
        {
            if(unlockLevel != null)
            {
                unlockLevel.Invoke(pLevelIndex);
            }
        }

        /// <summary>
        /// Reset side and level of all squares of the current map
        /// </summary>
        public void ResetMap()
        {
            if(currentMap != null)
            {
                currentMap.ResetSquares();
                AppManager.instance?.coreGameManager?.ResetPlayerAndClock(currentMap.PlayerStartPosition);
            }
            
        }

        /// <summary>
        /// Clear the current map
        /// </summary>
        public override void ClearCurrentLevel()
        {
            base.ClearCurrentLevel();
            currentMap = null;
        }
        #endregion Methods
    }
}
