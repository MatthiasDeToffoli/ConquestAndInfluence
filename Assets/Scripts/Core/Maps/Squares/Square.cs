using fr.matthiasdetoffoli.ConquestAndInfluence.Utils;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using UnityEngine;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.Core.Levels.Squares
{
    /// <summary>
    /// the square behaviour
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class Square : AMonoBehaviour
    {
        #region Fields
        /// <summary>
        /// the level of the square
        /// </summary>
        [SerializeField]
        private int mLevel;
        /// <summary>
        /// the side of the square
        /// </summary>
        [SerializeField]
        private SquareSide mSide;

        /// <summary>
        /// The index to use in the sprite path array
        /// </summary>
        [SerializeField]
        private int mSpritePathIndex = 0;

        /// <summary>
        /// The index for get the sprite prefix
        /// </summary>
        [SerializeField]
        private int mSpritePrefixIndex = 0;
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

                if(mLevel == 0)
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

            //Actualise the sprite with the datas at the start of the level
            ActualiseSprite();
        }
        #endregion Unity

        /// <summary>
        /// Change the sprite of the square
        /// </summary>
        private void ActualiseSprite()
        {
            if (CanMoveOn)
            {
                //Get the sprite in the resource folder
                Sprite lSprite = 
                    Resources.Load<Sprite>(SpriteNameBuilder.GetSpriteResourceName(mSpritePathIndex,mSpritePrefixIndex,side,level));

                //set the sprite in the sprite renderer
                if (lSprite != null)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = lSprite;
                }
            }
        }
        #endregion Methods
    }
}