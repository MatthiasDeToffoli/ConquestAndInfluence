using fr.matthiasdetoffoli.ConquestAndInfluence.Maps;
using fr.matthiasdetoffoli.ConquestAndInfluence.UI.Screens.ScreenWithSquareTarget;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.Managers.ManagedManager;
using System.Linq;
using UnityEngine;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.UI
{
    /// <summary>
    /// Manage all menu
    /// </summary>
    /// <seealso cref="AMenuManager"/>
    public class MenuManager : AMenuManager
    {
        #region Constants
        /// <summary>
        /// Error used when we interact with the square interaction screen and it's null
        /// </summary>
        private const string ERROR_SQUARE_INTERRACTION_SCREEN_NULL = "Square Interaction Screen not found";
        #endregion Constants

        #region Methods
        /// <summary>
        /// Open the square interacion screen
        /// </summary>
        /// <param name="pSquare">the square to interact with</param>
        public void OpenSquareInteractionScreen(Square pSquare)
        {
            SquareInteractionScreen lScreen = items.FirstOrDefault(pElm => pElm is SquareInteractionScreen) as SquareInteractionScreen;

            if(lScreen == null)
            {
                Debug.LogError(ERROR_SQUARE_INTERRACTION_SCREEN_NULL);
            }
            else
            {
                lScreen.Open(pSquare);
            }
        }
        #endregion Methods
    }
}
