using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using UnityEngine;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.Maps.Squares
{
    /// <summary>
    /// the square behaviour
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class Square : AMonoBehaviour
    {
        #region Constants
        /// <summary>
        /// The name of the property side in the animator
        /// </summary>
        private string ANIMATOR_SIDE_PROPERTY = "Side";

        /// <summary>
        /// The name of the property level in the animator
        /// </summary>
        private string ANIMATOR_LEVEL_PROPERTY = "Level";
        #endregion Constants

        #region Fields
        /// <summary>
        /// the level of the square
        /// </summary>
        private int mLevel;

        /// <summary>
        /// the side of the square
        /// </summary>
        private SquareSide mSide;

        /// <summary>
        /// The animator of the gameobject
        /// </summary>
        private Animator mAnimator;
        #endregion Fields

        #region Properties
        /// <summary>
        /// If we can move on or not
        /// </summary>
        public bool CanMoveOn = true;

        /// <summary>
        /// the level of the square
        /// </summary>
        public int level
        {
            get
            {
                return mLevel;
            }
            set
            {
                mLevel = value;

                if (mLevel == 0)
                    mSide = SquareSide.NEUTRAL;

                ActualiseSprite();
            }
        }

        /// <summary>
        /// the side of the square
        /// </summary>
        public SquareSide side
        {
            get
            {
                return mSide;
            }
            set
            {
                mSide = value;
                ActualiseSprite();
            }
        }
        #endregion Properties

        #region Methods

        #region Unity
        /// <summary>
        /// Awake of the behaviour
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            //get the animator
            mAnimator = gameObject.GetComponent<Animator>();

            //Actualise the sprite with the datas at the start of the level
            ActualiseSprite();
        }
        #endregion Unity

        /// <summary>
        /// Change the sprite of the square
        /// </summary>
        private void ActualiseSprite()
        {
            if (CanMoveOn && mAnimator != null)
            {
                mAnimator.SetInteger(ANIMATOR_SIDE_PROPERTY, (int)side);
                mAnimator.SetInteger(ANIMATOR_LEVEL_PROPERTY, level);
            }
        }
        #endregion Methods
    }
}