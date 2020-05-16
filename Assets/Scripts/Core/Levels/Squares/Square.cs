using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using UnityEngine;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.Core.Levels.Squares
{
    public class Square : AMonoBehaviour
    {
        #region Fields
        /// <summary>
        /// The sprite prefix for find the good sprite in function of the square
        /// </summary>
        [SerializeField]
        private string mSpritePrefix;
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
            }
        }
        #endregion Properties
    }
}