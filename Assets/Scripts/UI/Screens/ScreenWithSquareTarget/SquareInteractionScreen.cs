using Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps;
using Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps.Enums;
using Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.ButtonListeners.ActionOnSquareButtonListener;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.Attributes;
using System.Linq;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.UI.Screens.ScreenWithSquareTarget
{
    /// <summary>
    /// Screen open for chose an interaction with a square
    /// </summary>
    /// <seealso cref="AScreenWithSquareTarget"/>
    public class SquareInteractionScreen : AScreenWithSquareTarget
    {
        #region Fields
        /// <summary>
        /// The attack square button listener
        /// </summary>
        [CustomLabel("Attack square")]
        [SerializeField]
        private AttackSquareButtonListener mAttackSquare;

        /// <summary>
        /// The buy square button listener
        /// </summary>
        [CustomLabel("Buy square")]
        [SerializeField]
        private BuySquareButtonListener mBuySquare;

        /// <summary>
        /// The convert square button listener
        /// </summary>
        [CustomLabel("Convert square")]
        [SerializeField]
        private ConvertSquareButtonListener mConvertSquare;

        /// <summary>
        /// The move on square button listener
        /// </summary>
        [CustomLabel("Move on square")]
        [SerializeField]
        private MoveOnSquareButtonListener mMoveOnSquare;

        /// <summary>
        /// The negociate for square button listener
        /// </summary>
        [CustomLabel("Negociate for square")]
        [SerializeField]
        private NegociateForSquareButtonListener mNegociateForSquare;

        /// <summary>
        /// the upgrade square button listener
        /// </summary>
        [CustomLabel("Upgrade square")]
        [SerializeField]
        private UpgradeSquareButtonListener mUpgradeSquare;
        #endregion Fields

        #region Methods
        /// <summary>
        /// Listen all events here
        /// </summary>
        protected override void ListenToEvents()
        {
            base.ListenToEvents();

            mAttackSquare.startActionEvent += StartActionOnSquare;
            mBuySquare.startActionEvent += StartActionOnSquare;
            mConvertSquare.startActionEvent += StartActionOnSquare;
            mMoveOnSquare.startActionEvent += StartActionOnSquare;
            mNegociateForSquare.startActionEvent += StartActionOnSquare;
            mUpgradeSquare.startActionEvent += StartActionOnSquare;
        }

        /// <summary>
        /// When we try to start an action on a square
        /// </summary>
        /// <param name="pSender">the sender of the event</param>
        private void StartActionOnSquare(AActionOnSquareButtonListener pSender)
        {
            if( mTarget != null)
            {
                Square lTarget = mTarget;
                Close();
                AppManager.instance?.coreGameManager?.CheckActionOnSquare(lTarget, pSender.action);
            }
        }

        /// <summary>
        /// show the screen
        /// </summary>
        /// <param name="pParams">the parameters of the screen</param>
        public override void Open(params object[] pParams)
        {
            mTarget = null;

            if (pParams != null && pParams.Length > 0)
                mTarget = pParams.FirstOrDefault(pElm => pElm is Square) as Square;

            if (mTarget != null)
            {
                //Active the buttons in functions of the square side
                switch (mTarget.side)
                {
                    case SquareSide.ALLY:
                        mUpgradeSquare.gameObject.SetActive(true);
                        mAttackSquare.gameObject.SetActive(false);
                        mBuySquare.gameObject.SetActive(false);
                        mNegociateForSquare.gameObject.SetActive(false);
                        mConvertSquare.gameObject.SetActive(false);
                        break;

                    case SquareSide.NEUTRAL:
                        mUpgradeSquare.gameObject.SetActive(false);
                        mAttackSquare.gameObject.SetActive(false);
                        mBuySquare.gameObject.SetActive(false);
                        mNegociateForSquare.gameObject.SetActive(false);
                        mConvertSquare.gameObject.SetActive(true);
                        break;

                    case SquareSide.ENEMY:
                        mUpgradeSquare.gameObject.SetActive(false);
                        mAttackSquare.gameObject.SetActive(true);
                        mBuySquare.gameObject.SetActive(true);
                        mNegociateForSquare.gameObject.SetActive(true);
                        mConvertSquare.gameObject.SetActive(false);
                        break;
                }

                
            }

            base.Open(pParams);
        }

        /// <summary>
        /// unlisten all events here
        /// </summary>
        protected override void UnlistenToEvents()
        {
            base.UnlistenToEvents();

            mAttackSquare.startActionEvent -= StartActionOnSquare;
            mBuySquare.startActionEvent -= StartActionOnSquare;
            mConvertSquare.startActionEvent -= StartActionOnSquare;
            mMoveOnSquare.startActionEvent -= StartActionOnSquare;
            mNegociateForSquare.startActionEvent -= StartActionOnSquare;
            mUpgradeSquare.startActionEvent -= StartActionOnSquare;
        }
        #endregion Methods
    }
}
