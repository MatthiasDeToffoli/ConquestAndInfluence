using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Interfaces;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.ButtonListeners.OpenScreen
{
    /// <summary>
    /// Button listener which open a screen
    /// </summary>
    /// <typeparam name="TToOpen">Type of the screen to open</typeparam>
    /// <seealso cref="GlobalUnityProjectCode.Classes.Menu.ButtonListeners.OpenScreenButtonListeners.AOpenScreenButtonListener{T}"/>
    /// <seealso cref="AMenuScreen"/>
    public abstract class AOpenScreenButtonListener<TToOpen>: GlobalUnityProjectCode.Classes.Menu.ButtonListeners.OpenScreenButtonListeners.AOpenScreenButtonListener<TToOpen>
        where TToOpen : AMenuScreen
    {
        #region Fields
        /// <summary>
        /// Get the main manager
        /// </summary>
        protected override IMainManager mMainManager
        {
            get
            {
                return AppManager.instance;
            }
        }
        #endregion Fields
    }
}
