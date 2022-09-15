using Fr.Matthiasdetoffoli.ConquestAndInfluence;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.ButtonListeners;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.ButtonListeners
{
    /// <summary>
    /// Button listener for change clock speed
    /// </summary>
    public class ChangeClockSpeedButtonListener : AButtonListener
    {
        #region Fields
        /// <summary>
        /// The text mesh of the button
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI mTextMesh;

        /// <summary>
        /// Text of the text mesh
        /// </summary>
        /// <remarks>Just has a set for set the value of the mesh for dry</remarks>
        private int? mText
        {
            set
            {
                if(mTextMesh != null && value != null)
                {
                    mTextMesh.text = value.ToString();
                }
            }
        }
        #endregion Fields

        #region Methods
        /// <summary>
        /// Start of the behavior
        /// </summary>
        protected override void Start()
        {
            base.Start();
            mText = AppManager.instance?.coreGameManager?.GetClockSpeedIndex();
        }
        /// <summary>
        /// call when we click on the button
        /// </summary>
        protected override void OnButtonClicked()
        {
            mText = AppManager.instance?.coreGameManager?.ChangeClockSpeed();
        }
        #endregion Methods
    }
}
