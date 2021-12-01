using Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.Core.Characters
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
        /// <param name="pPercentOfDay">the percent of the day, move to one square per day</param>
        public virtual void Move(float pPercentOfDay)
        {
            if(mTargetSquare == null && path != null && path.Count > 0 && pPercentOfDay == 0)
            {
                mTargetSquare = path[0];
                mCurrentMovement = new Vector3(mTargetSquare.position.x - currentPosition.position.x, mTargetSquare.position.y - currentPosition.position.y, transform.position.z);
            }

            if(mCurrentMovement != Vector3.Zero && mTargetSquare != null)
            {
                float lCurrentPersentMove = Math.Abs(pPercentOfDay);

                if(lCurrentPersentMove < 1)
                {
                    transform.position = new UnityEngine.Vector3(currentPosition.position.x + mCurrentMovement.X * lCurrentPersentMove, currentPosition.position.y + mCurrentMovement.Y * lCurrentPersentMove, transform.position.z);
                }
                else
                {
                    transform.position.Set(mTargetSquare.position.x, mTargetSquare.position.y, transform.position.z);
                    mCurrentMovement = Vector3.Zero;
                    path.RemoveAt(0);
                    currentPosition = mTargetSquare;
                    mTargetSquare = null;

                    if(path.Count == 0)
                    {
                        FinishedMove();
                    }
                }
            }
            
        }

        /// <summary>
        /// set the character position
        /// </summary>
        /// <param name="pPosition">the position square</param>
        public void SetPosition(Square pPosition)
        {
            currentPosition = pPosition;
            transform.position.Set(pPosition.transform.position.x, pPosition.transform.position.y, transform.position.z);
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Call when the move of the caracter is finished
        /// </summary>
        protected abstract void FinishedMove();
        #endregion Methods
    }
}
