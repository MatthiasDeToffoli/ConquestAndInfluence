using fr.matthiasdetoffoli.ConquestAndInfluence.Maps.Squares;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager;
using System.Collections.Generic;
using UnityEngine;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.Maps
{
    /// <summary>
    /// Manager used for managed all the maps
    /// </summary>
    public class MapManager : AManagerWithList<MapHandler>
    {
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

        #region Unity
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            //Unactive all map at the start of the project
            foreach(MapHandler lMapHandler in items)
            {
                lMapHandler.gameObject.SetActive(false);
            }
        }
        #endregion Unity

        /// <summary>
        /// Select the map
        /// </summary>
        /// <param name="pIndex">the index of the map to select</param>
        public void SelectMap(int pIndex)
        {
            if(items.Count - 1 < pIndex)
            {
                Debug.LogError(ERROR_SELECT_WRONG_MAP);
            }
            else
            {
                currentMap = items[pIndex];

                if(currentMap == null)
                {
                    Debug.LogError(ERROR_SELECT_WRONG_MAP);
                }
                else
                {
                    currentMap.gameObject.SetActive(true);
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
        #endregion Methods
    }
}
