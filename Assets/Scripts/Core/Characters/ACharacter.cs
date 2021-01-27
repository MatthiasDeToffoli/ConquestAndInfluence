using Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using System.Collections.Generic;
using System.Numerics;

namespace Assets.Scripts.Core.Characters
{
    /// <summary>
    /// Abstract class for define a character
    /// </summary>
    public abstract class ACharacter : AMonoBehaviour
    {
        #region Fields
        /// <summary>
        /// the current movement the character do
        /// </summary>
        private Vector3 mCurrentMovement;

        /// <summary>
        /// The square where the player want to go
        /// </summary>
        private Square mTargetSquare;
        #endregion Fields

        #region Properties
        /// <summary>
        /// The current path the character has to follow
        /// </summary>
        public List<Square> path;

        /// <summary>
        /// The current character position
        /// </summary>
        public Square currentPosition;
        #endregion Properties

        #region Methods
        /// <summary>
        /// The movement of the character
        /// </summary>
        public virtual void Move(float pPercentOfDay)
        {
            if(mTargetSquare == null && path != null && path.Count > 0)
            {
                mTargetSquare = path[0];
                mCurrentMovement = new Vector3(mTargetSquare.position.x - currentPosition.position.x, mTargetSquare.position.y - currentPosition.position.y, transform.position.z);
            }

            if(mCurrentMovement != Vector3.Zero && mTargetSquare != null)
            {
                if(pPercentOfDay != 1)
                {
                    transform.position.Set(currentPosition.position.x + mCurrentMovement.X * pPercentOfDay, currentPosition.position.y + mCurrentMovement.Y * pPercentOfDay, transform.position.z);
                    path.RemoveAt(0);
                }
                else
                {
                    transform.position.Set(mTargetSquare.position.x, mTargetSquare.position.y, transform.position.z);
                    mCurrentMovement = Vector3.Zero;
                    mTargetSquare = null;
                }
            }
            
        }
        #endregion Methods
    }
}
