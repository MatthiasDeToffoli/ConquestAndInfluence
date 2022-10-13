using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;
using System.Linq;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.Screens
{
    /// <summary>
    /// Screen open for validate an action
    /// </summary>
    public class ValidationPathScreen : AValidationScreen
    {
        #region Fields
        /// <summary>
        /// The id of the path feedback
        /// </summary>
        private string mFeedBackId;
        #endregion Fields

        #region Properties
        /// <summary>
        /// State of the clock before opening the validation path screen
        /// </summary>
        public bool clockPreviousState;
        #endregion Properties

        #region Methods
        /// <summary>
        /// Open the screen
        /// </summary>
        /// <param name="pParams">parameters of the screen</param>
        public override void Open(params object[] pParams)
        {
            mFeedBackId = string.Empty;

            if (pParams != null && pParams.Length > 0)
                mFeedBackId = (string)pParams.FirstOrDefault(pElm => pElm is string);

            base.Open(pParams);
        }
        /// <summary>
        /// When a validation button was clicked
        /// </summary>
        /// <param name="pState"></param>
        protected override void OnValidation(bool pState)
        {
            AppManager.instance?.coreGameManager?.StartOrPauseClock(clockPreviousState);
            AppManager.instance?.visualFeedBacksManager?.UnshowMovingCaseVisualFeedback(mFeedBackId);

            if (pState)
            {
                AppManager.instance?.coreGameManager?.OrderActionOnSquare();
            }
            else
            {
                AppManager.instance?.coreGameManager?.SetActiveController(true);
            }

            AppManager.instance?.customMenuManager?.CloseScreen(this);
        }
        #endregion Methods
    }
}
