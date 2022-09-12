using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.Core.Characters.Enemies
{
    /// <summary>
    /// First enemy, he just don't move and wait
    /// </summary>
    public class Enemy1 : AEnemy
    {
        #region Methods
        /// <summary>
        /// The movement of the character
        /// </summary>
        /// <param name="pPercentOfDay">the percent of the day, move to one square per day</param>
        public override void Move(float pPercentOfDay)
        {
            //Do nothing
        }

        /// <summary>
        /// Call when the move of the caracter is finished
        /// </summary>
        protected override void FinishedMove()
        {
            //Do nothing
        }
        #endregion Methods
    }
}
