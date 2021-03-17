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
        #region Properties
        /// <summary>
        /// If the player can move or not
        /// </summary>
        public bool canMove;
        #endregion //Properties

        #region Methods
        /// <summary>
        /// The movement of the character
        /// </summary>
        public override void Move(float pPercentOfDay)
        {
            if(canMove)
                base.Move(pPercentOfDay);
        }
        #endregion //Methods
    }
}
