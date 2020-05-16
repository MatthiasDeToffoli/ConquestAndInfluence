using fr.matthiasdetoffoli.ConquestAndInfluence.Core.Levels.Squares;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.PersonalEditor;
using UnityEditor;
using UnityEngine;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.PersonalEditor
{
    /// <summary>
    /// Custom editor for the square class
    /// </summary>
    /// <seealso cref="Editor"/>
    /// <seealso cref="Square"/>"/>
    [CustomEditor(typeof(Square), true)]
    public class SquareEditor : Editor
    {
        #region Constants
        /// <summary>
        /// string of the variale mLevel
        /// </summary>
        private const string SPRITE_PREFIX = "mSpritePrefix";

        /// <summary>
        /// the title show in inspector for the level property
        /// </summary>
        private const string SPRITE_PREFIX_TITLE = "Sprite prefix";

        /// <summary>
        /// string of the variale mLevel
        /// </summary>
        private const string LEVEL = "mLevel";

        /// <summary>
        /// the title show in inspector for the level property
        /// </summary>
        private const string LEVEL_TITLE = "Level";

        /// <summary>
        /// string of the variale mSide
        /// </summary>
        private const string SIDE = "mSide";

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
        #endregion Constants

        #region Fields
        /// <summary>
        /// The sprite prefix is parent serialized property
        /// </summary>
        private SerializedProperty mSpritePrefixProperty;
        /// <summary>
        /// The level is parent serialized property
        /// </summary>
        private SerializedProperty mLevelProperty;

        /// <summary>
        /// The side serialized property
        /// </summary>
        private SerializedProperty mSideProperty;

        /// <summary>
        /// The Can Move On serialized property
        /// </summary>
        private SerializedProperty mCanMoveOnProperty;
        #endregion Fields

        #region Methods
        /// <summary>
        /// When the GUI is enable
        /// </summary>
        private void OnEnable()
        {
            //we get the property
            mSpritePrefixProperty = serializedObject.FindProperty(SPRITE_PREFIX);
            mLevelProperty = serializedObject.FindProperty(LEVEL);
            mSideProperty = serializedObject.FindProperty(SIDE);
            mCanMoveOnProperty = serializedObject.FindProperty(CAN_MOVE_ON);
        }
        /// <summary>
        /// When the inspector is updated
        /// </summary>
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Graphics :",GuiStyles.titleStyle);
            EditorGUILayout.PropertyField(mSpritePrefixProperty, new GUIContent(SPRITE_PREFIX_TITLE));
            EditorGUILayout.LabelField("___________________");
            EditorGUILayout.LabelField("");
            EditorGUILayout.LabelField("Datas :", GuiStyles.titleStyle);
            EditorGUILayout.PropertyField(mCanMoveOnProperty, new GUIContent(CAN_MOVE_ON_TITLE));

            EditorGUI.BeginChangeCheck();

            //we show the screen to close in function of the boolean value
            if (mCanMoveOnProperty.boolValue)
            {
                mLevelProperty.intValue = EditorGUILayout.IntSlider(LEVEL_TITLE,mLevelProperty.intValue, 0, 3);

                if(mLevelProperty.intValue > 0)
                {
                    mSideProperty.enumValueIndex = (int)(SquareSide)EditorGUILayout.EnumPopup(SIDE_TITLE, (SquareSide)mSideProperty.enumValueIndex);
                }
            }

            serializedObject.ApplyModifiedProperties();


        }
        #endregion Methods
    }
}

