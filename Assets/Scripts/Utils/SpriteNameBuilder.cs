using fr.matthiasdetoffoli.ConquestAndInfluence.Core.Levels.Squares;
using System.IO;
using UnityEngine;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.Utils
{
    /// <summary>
    /// static class for keep and write the squares sprite full name
    /// </summary>
    public static class SpriteNameBuilder
    {
        #region Properties
        /// <summary>
        /// The path of the file sprite name builder
        /// </summary>
        public static string path
        {
            get
            {
                return string.Format(@"{0}/Scripts/Utils/SpriteNameBuilder.cs",Application.dataPath);
            }
        }
        /// <summary>
        /// All path possible path for the resources square
        /// </summary>
        public static string[] resourcesSquarePaths = 
            new string[1]
            {
                "Sprites/Roads",
            };

        /// <summary>
        /// All path possible path for the resources square
        /// </summary>
        public static string[] squaresSpritesPrefix = 
            new string[1]
            {
                "Road",
            };
        #endregion Properties

        #region Methods
        /// <summary>
        /// Get the sprite name in the folder resource
        /// </summary>
        /// <param name="pPathIndex"></param>
        /// <param name="pPrefixIndex"></param>
        /// <param name="pSide"></param>
        /// <param name="pLevel"></param>
        /// <returns></returns>
        public static string GetSpriteResourceName(int pPathIndex, int pPrefixIndex, SquareSide pSide, int pLevel)
        {
            return 
                string.Format
                (
                    @"{0}/{1}_{2}_{3}", 
                    resourcesSquarePaths[pPathIndex], 
                    squaresSpritesPrefix[pPrefixIndex], 
                    pSide, 
                    pLevel
                );
        }
        #endregion Methods
    }
}
