﻿using fr.matthiasdetoffoli.ConquestAndInfluence.Core;
using fr.matthiasdetoffoli.ConquestAndInfluence.Maps;
using fr.matthiasdetoffoli.ConquestAndInfluence.Pooling;
using fr.matthiasdetoffoli.ConquestAndInfluence.VisualFeeddBacks;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager;

namespace fr.matthiasdetoffoli.ConquestAndInfluence
{
    /// <summary>
    /// Main manager of the app
    /// </summary>
    /// <seealso cref="AMainManager{TMain}"/>
    public class AppManager : AMainManager<AppManager> 
    {
        #region Fields
        /// <summary>
        /// The core game manager
        /// </summary>
        private CoreGameManager mCoreGameManager;

        /// <summary>
        /// The menu manager
        /// </summary>
        private MenuManager mMenuManager;

        /// <summary>
        /// The map manager
        /// </summary>
        private MapManager mMapManager;

        /// <summary>
        /// The pool manager
        /// </summary>
        private PoolManager mPoolManager;

        /// <summary>
        /// The feedback manager
        /// </summary>
        private VisualFeedBacksManager mVisualFeedBakcManager;
        #endregion Fields

        #region Properties
        /// <summary>
        /// The core game manager
        /// </summary>
        public CoreGameManager coreGameManager
        {
            get
            {
                if(mCoreGameManager == null)
                {
                    mCoreGameManager = GetFirstManager<CoreGameManager>();
                }

                return mCoreGameManager;
            }
        }

        /// <summary>
        /// The menu manager
        /// </summary>
        public MenuManager menuManager
        {
            get
            {
                if(mMenuManager == null)
                {
                    mMenuManager = GetFirstManager<MenuManager>();
                }

                return mMenuManager;
            }
        }

        /// <summary>
        /// The map manager
        /// </summary>
        public MapManager mapManager
        {
            get
            {
                if(mMapManager == null)
                {
                    mMapManager = GetFirstManager<MapManager>();
                }

                return mMapManager;
            }
        }

        /// <summary>
        /// The pool manager
        /// </summary>
        public PoolManager poolManager
        {
            get
            {
                if(mPoolManager == null)
                {
                    mPoolManager = GetFirstManager<PoolManager>();
                }

                return mPoolManager;
            }
        }

        /// <summary>
        /// The feedback manager
        /// </summary>
        public VisualFeedBacksManager visualFeedBakcManager
        {
            get
            {
                if(mVisualFeedBakcManager == null)
                {
                    mVisualFeedBakcManager = GetFirstManager<VisualFeedBacksManager>();
                }

                return mVisualFeedBakcManager;
            }
        }
        #endregion Properties
    }
}

