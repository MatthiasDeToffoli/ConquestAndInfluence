using fr.matthiasdetoffoli.ConquestAndInfluence.Maps;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager;
namespace Assets.Scripts.Maps
{
    /// <summary>
    /// Manager used for managed all the maps
    /// </summary>
    public class MapManager : AManagerWithList<MapHandler>
    {
        #region Fields
        /// <summary>
        /// the index of the map chosen
        /// </summary>
        private uint mMapChosenIndex;
        #endregion Fields

        #region Methods

        #region Unity
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

        #endregion Methods
    }
}
