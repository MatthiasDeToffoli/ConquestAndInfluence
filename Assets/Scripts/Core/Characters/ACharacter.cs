using Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps;
using Fr.Matthiasdetoffoli.GlobalUnityProjectCode.Classes.MonoBehaviors;
using System.Collections.Generic;

namespace Assets.Scripts.Core.Characters
{
    /// <summary>
    /// Abstract class for define a character
    /// </summary>
    public abstract class ACharacter : AMonoBehaviour
    {
        #region Properties
        /// <summary>
        /// The current path the character has to follow
        /// </summary>
        public List<Square> path;

        /// <summary>
        /// The current character position
        /// </summary>
        public Square CurrentPosition;
        #endregion Properties

        #region Methods
        /// <summary>
        /// The movement of the character
        /// </summary>
        public virtual void Move(double pPercentOfDay)
        {
            if(path == null)
            {

            }
        }
        #endregion Methods
    }
}
