using fr.matthiasdetoffoli.GlobalProjectCode.Interfaces.Pooling;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.VisualFeebacks;
using UnityEngine;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.VisualFeeddBacks
{
    /// <summary>
    /// Show and unshow the feedback when we click on a case
    /// </summary>
    public class MovingCaseFeedBack : AVisualFeedBack
    {
        #region Constants
        /// <summary>
        /// Name of the property lvl in the animator
        /// </summary>
        private const string ANIMATOR_PROPERTY_NAME = "lvl";
        #endregion Constants

        #region Fields
        /// <summary>
        /// The ID of the pool for get the visual feedback
        /// </summary>
        protected override string mPoolID
        {
            get
            {
                return "pathFeedBack";
            }
        }

        /// <summary>
        /// If it's the first, the last or middle case of the path feedback
        /// 0 : first
        /// 1 : middle
        /// 2: last
        /// </summary>
        private int mTypeOfPath;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Initialize an instance of the class <see cref="MovingCaseFeedBack"/>
        /// </summary>
        /// <param name="pTypeOfPath">If it's the first, the last or middle case of the path feedback</param>
        public MovingCaseFeedBack( int pTypeOfPath) : base()
        {
            mTypeOfPath = pTypeOfPath;
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Show the visual feed back
        /// </summary>
        /// <param name="pPoolManager">the pool manager</param>
        /// <param name="pTransform">the transforms contains position size and rotation of the feed back</param>
        /// <remarks>it search a game object in the pool</remarks>
        public override void Show(IPoolManager pPoolManager, Transform pTransform)
        {
            base.Show(pPoolManager, pTransform.localScale,new Vector3(pTransform.position.x,pTransform.position.y,pTransform.position.z - 1),pTransform.rotation);

            if (mObject != null)
            {
                Animator lAnimator = mObject.GetComponent<Animator>();
                lAnimator.SetInteger(ANIMATOR_PROPERTY_NAME, mTypeOfPath);
            }
        }
        #endregion Methods
    }
}

