using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners.CloseScreenButtonListeners.SwitchScreenButtonListeners;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Interfaces;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.ButtonListeners.SwitchScreen
{
    /// <summary>
    /// SwitchScreenButtonListener
    /// </summary>
    /// <typeparam name="TMenuToOpen">Type of the screen to open</typeparam>
    /// <typeparam name="TMenuToClose">Type of the screen to close</typeparam>
    /// <seealso cref="ATypedSwitchScreenButtonListener{TToOpen,TToClose}"/>
    /// <seealso cref="AMenuScreen"/>
    public abstract class ASwitchScreenButtonListener<TMenuToOpen, TMenuToClose> : ATypedSwitchScreenButtonListener<TMenuToOpen,TMenuToClose>
        where TMenuToOpen : AMenuScreen
        where TMenuToClose : AMenuScreen
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
