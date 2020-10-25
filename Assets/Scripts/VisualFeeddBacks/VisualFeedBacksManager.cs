using fr.matthiasdetoffoli.ConquestAndInfluence.Maps;
using fr.matthiasdetoffoli.ConquestAndInfluence.Pooling;
using fr.matthiasdetoffoli.GlobalProjectCode.Interfaces.Pooling;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.VisualFeebacks;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.VisualFeeddBacks
{
    /// <summary>
    /// Manage all AVisual Feedbacks
    /// </summary>
    public class VisualFeedBacksManager : AVisualFeedBacksManager
    {
        #region Fields
        /// <summary>
        /// The pool manager
        /// </summary>
        protected override IPoolManager mPoolManager
        {
            get
            {
                return AppManager.instance?.poolManager;
            }
        }

        /// <summary>
        /// Contain all path show
        /// </summary>
        private Dictionary<string, List<string>> mPathFeedbacks;
        #endregion Fields

        #region Methods
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            mPathFeedbacks = new Dictionary<string, List<string>>();
        }
        /// <summary>
        /// Initialize the manager
        /// </summary>
        public override void Init()
        {
            base.Init();
        }

        /// <summary>
        /// Show a moving case visual feedback
        /// </summary>
        /// <param name="pTransform">the transform for place the feed back</param>
        /// <returns>the unic id of the feedback</returns>
        public string ShowMovingCaseVisualFeedback(List<Square> pSquares)
        {
            int lType = 0;
            List<string> lPathsReferences = new List<string>();
            string lID = Guid.NewGuid().ToString();
            for(int i = 0, l = pSquares.Count; i < l; i++)
            {
                if(i > 0 && i < l - 1 && lType != 1)
                {
                    lType = 1;
                } 
                else if(i == l - 1)
                {
                    lType = 2;
                }

                lPathsReferences.Add(ShowFeedBack(new MovingCaseFeedBack(lType), pSquares[i].transform));
            }

            mPathFeedbacks.Add(lID, lPathsReferences);

            return lID;
        }

        /// <summary>
        /// Unshow the moving cas visual feedback
        /// </summary>
        /// <param name="pRef">the id of the feedback</param>
        public void UnshowMovingCaseVisualFeedback(string pRef)
        {
            if (string.IsNullOrEmpty(pRef) == false &&  mPathFeedbacks.ContainsKey(pRef))
            {
                foreach(string lFeedBackRef in mPathFeedbacks[pRef])
                {
                    UnshowFeedBack(lFeedBackRef);
                }
            }

            mPathFeedbacks.Remove(pRef);
        }
        #endregion Methods
    }
}
