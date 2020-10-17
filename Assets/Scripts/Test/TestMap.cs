using fr.matthiasdetoffoli.ConquestAndInfluence.Core;
using fr.matthiasdetoffoli.ConquestAndInfluence.Maps;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using System.Collections.Generic;
using UnityEngine;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.Test
{
    /// <summary>
    /// Class used for test map features
    /// </summary>
    /// <seealso cref="AMonoBehaviour"/>
    public class TestMap : AMonoBehaviour
    {
        #region Properties
        /// <summary>
        /// the start square
        /// </summary>
        public Square startSquare;

        /// <summary>
        /// the target square
        /// </summary>
        public Square targetSquare;
        #endregion Properties

        #region Methods
        /// <summary>
        /// Test the selection of a map
        /// </summary>
        /// <param name="pIndex">the index to select</param>
        public void TestSelectMap(int pIndex)
        {
            AppManager.instance?.mapManager?.SelectMap(pIndex);
            Debug.Log(string.Format("map {0} selected", pIndex));

            //Active the controller for interact with the squares
            AppManager.instance?.coreGameManager?.SetActiveController(true);
        }

        /// <summary>
        /// Test the path  finding
        /// </summary>
        /// <param name="pStartPos">the square to start</param>
        /// <param name="pTargetPos">the square target</param>
        public void TestPathFinding()
        {
            if(startSquare == null || targetSquare == null)
            {
                Debug.LogError("Set start and target squares");
                return;
            }

            MapManager lMapManager = AppManager.instance?.mapManager;

            if (lMapManager != null)
            {
                List<Square> lList = lMapManager.FindPath(startSquare.position, targetSquare.position);

                if(lList == null)
                {
                    Debug.Log("Can't find a path");
                }
                else
                {
                    foreach(Square lSquare in lList)
                    {
                        Debug.Log(string.Format("{0} : {1}", lSquare.gameObject.name, lSquare.position));
                    }
                }
            }
        }
        #endregion Methods
    }
}
