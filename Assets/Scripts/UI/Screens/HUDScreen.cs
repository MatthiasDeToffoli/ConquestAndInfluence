using Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.ButtonListeners;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Menu.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.Screens
{
    public class HUDScreen : AMenuScreen
    {
        #region Constants
        /// <summary>
        /// Day text
        /// </summary>
        private const string DAY = "Day";

        /// <summary>
        /// Power text
        /// </summary>
        private const string POWER = "Power";

        /// <summary>
        /// Plurial
        /// </summary>
        private const char PLURIAL = 's';
        #endregion Constants

        #region Fields
        /// <summary>
        /// The Day text handler
        /// </summary>
        [SerializeField]
        private Text mDaysTextHandler;

        /// <summary>
        /// The power text handler
        /// </summary>
        [SerializeField]
        private Text mPowersTextHandler;

        /// <summary>
        /// The numbers of days
        /// </summary>
        private int mDays;

        /// <summary>
        /// The numbers of powers
        /// </summary>
        private int mPowers;
        #endregion Fields

        #region Properties
        /// <summary>
        /// The number of days
        /// </summary>
        public int days
        {
            get
            {
                return mDays;
            }
            set
            {
                mDays = value;
                SetDaysText(value);
            }
        }

        /// <summary>
        /// The number of powers
        /// </summary>
        public int powers
        {
            get
            {
                return mPowers;
            }
            set
            {
                mPowers = value;
                SetPowersText(value);
            }
        }

        /// <summary>
        /// Button listener for start or pause the clock
        /// </summary>
        public StartPauseClockButtonListener startOrPauseClockBTN;
        #endregion Properties

        #region Methods
        /// <summary>
        /// Set the days text
        /// </summary>
        /// <param name="pNbOfDays"></param>
        private void SetDaysText(int pNbOfDays)
        {
            SetText(mDaysTextHandler, pNbOfDays, DAY, "{0:00} {1}");
        }

        /// <summary>
        /// Set the powers text
        /// </summary>
        /// <param name="pNbOfPowers"></param>
        private void SetPowersText(int pNbOfPowers)
        {
            SetText(mPowersTextHandler, pNbOfPowers, POWER, "{1} : {0:000}");
        }

        /// <summary>
        /// Set a text in a text handler
        /// </summary>
        /// <param name="pHandler">the text handler</param>
        /// <param name="pNb">the nb of days or powers</param>
        /// <param name="pTextName">the text name to set (days or powers)</param>
        /// <param name="pFinalFormat">the final format of the text</param>
        private void SetText(Text pHandler, int pNb, string pTextName, string pFinalFormat)
        {
            string lFormatedText = pTextName;

            if (pNb > 1)
            {
                lFormatedText = string.Format("{0}s", pTextName);
            }
            SetText(pHandler, string.Format(pFinalFormat, pNb, lFormatedText));
        }

        /// <summary>
        /// Set a text in a text handler
        /// </summary>
        /// <param name="pHandler">the text handler</param>
        /// <param name="pText">the text to set</param>
        private void SetText(Text pHandler, string pText)
        {
            if(pHandler != null)
            {
                pHandler.text = pText;
            }
        }
        #endregion Methods
    }
}
