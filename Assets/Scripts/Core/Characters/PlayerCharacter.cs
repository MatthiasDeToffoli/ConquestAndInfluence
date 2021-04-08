using Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps;
using Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.Core.Characters
{
    /// <summary>
    /// Character the player will control
    /// </summary>
    public class PlayerCharacter : ACharacter
    {
        #region Fields
        /// <summary>
        /// If the player can move or not
        /// </summary>
        private bool mCanMove;

        /// <summary>
        /// If the player converting a square or not
        /// </summary>
        private bool mConvertingASquare;
        #endregion Fields

        #region Properties
        /// <summary>
        /// If the player can move or not
        /// </summary>
        public bool canMove
        {
            get
            {
                return mCanMove;
            }
            set
            {
                mCanMove = value;

                if (value == true)
                    mConvertingASquare = false;
            }
        }
        #endregion //Properties

        #region Methods
        /// <summary>
        /// Update with clock
        /// </summary>
        /// <param name="pPercentOfDay"></param>
        /// <returns><c>true</c> if the player converted a square, <c>false</c> if not</returns>
        public void ClockUpdate(float pPercentOfDay)
        {
            if (canMove)
            {
                Move(pPercentOfDay);
            }
            else if(pPercentOfDay == 0)
            {
                mConvertingASquare = true;
            }
        }

        /// <summary>
        /// Try to add the current position to the squares to convert
        /// </summary>
        /// <param name="pSquaresToConvert">Dictionary contain all squares to convert and the side used to convert them</param>
        public void TryToConvertCurrentPositionSquare(ref Dictionary<Square, SquareSide> pSquaresToConvert)
        {
            if (mConvertingASquare)
            {
                pSquaresToConvert.Add(currentPosition, SquareSide.ALLY);
            }
        }

        /// <summary>
        /// Call when the move of the caracter is finished
        /// </summary>
        protected override void FinishedMove()
        {
            mCanMove = false;
        }
        #endregion //Methods
    }
}
