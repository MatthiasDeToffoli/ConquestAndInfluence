using Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps.Enums;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using System;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps
{
    /// <summary>
    /// the square behaviour
    /// </summary>
    /// <seealso cref="AMonoBehaviour"/>
    /// <seealso cref="Animator"/>
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

        /// <summary>
        /// The min lvl of a square
        /// </summary>
        public const int MIN_LVL = 0;

        /// <summary>
        /// The max lvl of a square
        /// </summary>
        public const int MAX_LVL = 3;
        #endregion Constants

        #region Fields
        /// <summary>
        /// the level of the square
        /// </summary>
        [SerializeField]
        private int mLevel;

        /// <summary>
        /// Base level of the square used for reset it
        /// </summary>
        private int mBaseLevel;

        /// <summary>
        /// the side of the square
        /// </summary>
        [SerializeField]
        private SquareSide mSide;

        /// <summary>
        /// Base side of the square used for reset it
        /// </summary>
        private SquareSide mBaseSide;

        /// <summary>
        /// The animator of the gameobject
        /// </summary>
        private Animator mAnimator;
        #endregion Fields

        #region Properties
        /// <summary>
        /// The unic ID of the square
        /// </summary>
        public string unicId
        {
            get;
            private set;
        }
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

                if (mLevel == MIN_LVL)
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

        /// <summary>
        /// the position of the square
        /// </summary>
        [HideInInspector]
        public Vector3 position
        {
            get
            {
                return transform.position;
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

            mBaseLevel = mLevel;
            mBaseSide = mSide;

            //get the animator
            mAnimator = gameObject.GetComponent<Animator>();

            //Actualise the sprite with the datas at the start of the level
            ActualiseSprite();

            unicId = string.Format("Square.{0}", Guid.NewGuid().ToString());
        }

        /// <summary>
        /// When the square is enable
        /// </summary>
        private void OnEnable()
        {
            //Reactualise sprite for resort the good values
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

        /// <summary>
        /// Add a level if the square is Neutral or on the same side as pSide, remove a level if not and change automaticaly the side
        /// </summary>
        /// <param name="pSide">reference side</param>
        /// <param name="pLevel">number of level to add</param>
        public void AddLevelSide(SquareSide pSide, int pLevel = 1)
        {
            if (CanMoveOn)
            {
                if (pLevel == 0)
                {
                    Debug.LogWarning("You try to add 0 level to a square it's useless !");
                    return;
                }

                int lNewLevel = 0;

                //In this case we substract pLevel
                if ((pSide == SquareSide.ALLY && side == SquareSide.ENEMY) || (pSide == SquareSide.ENEMY && side == SquareSide.ALLY))
                {
                    pLevel *= -1;
                }

                lNewLevel = level + pLevel;

                if (lNewLevel < MIN_LVL || side == SquareSide.NEUTRAL)
                {
                    side = pSide;
                }

                level = Math.Min(Math.Abs(lNewLevel), MAX_LVL);
            }
        }

        /// <summary>
        /// Reset side and level to base values
        /// </summary>
        public void ResetProperties()
        {
            level = mBaseLevel;
            side = mBaseSide;
        }
        #endregion Methods
    }
}