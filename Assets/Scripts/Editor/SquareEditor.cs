using Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps;
using Fr.Matthiasdetoffoli.ConquestAndInfluence.Maps.Enums;
using UnityEditor;
using UnityEngine;

namespace Fr.Matthiasdetoffoli.ConquestAndInfluence.PersonalEditor
{
    /// <summary>
    /// Custom editor for the square class
    /// </summary>
    /// <seealso cref="Editor"/>
    /// <seealso cref="Square"/>"/>
    [CustomEditor(typeof(Square), true)]
    internal class SquareEditor : Editor
    {
        #region Constants
        /// <summary>
        /// the title show in inspector for the level property
        /// </summary>
        private const string LEVEL_TITLE = "Level";

        /// <summary>
        /// the title show in inspector for the side property
        /// </summary>
        private const string SIDE_TITLE = "Side";

        /// <summary>
        /// string of the variale CanMoveOn
        /// </summary>
        private const string CAN_MOVE_ON = "CanMoveOn";

        /// <summary>
        /// the title show in inspector for the Can Move On property
        /// </summary>
        private const string CAN_MOVE_ON_TITLE = "Can we move on it ?";

        /// <summary>
        /// The min lvl of a square
        /// </summary>
        private const int MIN_LVL = 0;

        /// <summary>
        /// The max lvl of a square
        /// </summary>
        private const int MAX_LVL = 3;
        #endregion Constants

        #region Fields
        /// <summary>
        /// The Can Move On serialized property
        /// </summary>
        private SerializedProperty mCanMoveOnProperty;

        /// <summary>
        /// The typed target
        /// </summary>
        private Square mTypedTarget;
        #endregion Fields

        #region Methods
        
        /// <summary>
        /// When the GUI is enable
        /// </summary>
        private void OnEnable()
        {
            //we get the property
            mCanMoveOnProperty = serializedObject.FindProperty(CAN_MOVE_ON);

            mTypedTarget = target as Square;
        }
        /// <summary>
        /// When the inspector is updated
        /// </summary>
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(mCanMoveOnProperty, new GUIContent(CAN_MOVE_ON_TITLE));

            //if we can't move on so we keep the current sprite and don't need to change the datas
            if (mCanMoveOnProperty.boolValue)
            {
                //let a blank
                EditorGUILayout.Space();

                mTypedTarget.level = EditorGUILayout.IntSlider(LEVEL_TITLE, mTypedTarget.level, MIN_LVL, MAX_LVL);

                if (mTypedTarget.level > 0)
                {
                    mTypedTarget.side = (SquareSide)EditorGUILayout.EnumPopup(SIDE_TITLE, mTypedTarget.side);
                }
                else
                {
                    //At level 0 the side is always neutral
                    mTypedTarget.side = SquareSide.NEUTRAL;
                }
            }

            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
        }
        #endregion Methods
    }
}

