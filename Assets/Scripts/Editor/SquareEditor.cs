using fr.matthiasdetoffoli.ConquestAndInfluence.Core.Levels.Squares;
using fr.matthiasdetoffoli.ConquestAndInfluence.Utils;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.PersonalEditor;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Utils;
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
        /// the title sprites part
        /// </summary>
        private const string SPRITES_PART = "Sprites part :";
        /// <summary>
        /// the title Datas part
        /// </summary>
        private const string DATAS_PART = "Datas part :";

        /// <summary>
        /// string of the variale mSpritePathIndex
        /// </summary>
        private const string SPRITE_PATH = "mSpritePathIndex";

        /// <summary>
        /// the title show in inspector for the SpritePath property
        /// </summary>
        private const string SPRITE_PATH_TITLE = "Path of the sprite";

        /// <summary>
        /// string of the variale mSpritePrefixIndex
        /// </summary>
        private const string SPRITE_PREFIX = "mSpritePrefixIndex";

        /// <summary>
        /// the title show in inspector for the SpritePrefix property
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
        /// The sprite path serialized property
        /// </summary>
        private SerializedProperty mSpritePathProperty;

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
            mSpritePathProperty = serializedObject.FindProperty(SPRITE_PATH);
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
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(mCanMoveOnProperty, new GUIContent(CAN_MOVE_ON_TITLE));

            //if we can't move on so we keep the current sprite and don't need to change the datas
            if (mCanMoveOnProperty.boolValue)
            {
                //let a blank
                EditorGUILayout.LabelField(string.Empty);

                //The sprites part
                EditorGUILayout.LabelField(SPRITES_PART, GuiStyles.titleStyle);
                //the dropdown for the sprites paths
                mSpritePathProperty.intValue = 
                    EditorGUILayout.Popup(SPRITE_PATH_TITLE, mSpritePathProperty.intValue,SpriteNameBuilder.resourcesSquarePaths);
                //The dropdown for the UI paths
                mSpritePrefixProperty.intValue =
                    EditorGUILayout.Popup(SPRITE_PREFIX_TITLE, mSpritePrefixProperty.intValue, SpriteNameBuilder.squaresSpritesPrefix);
                //Separate the two parts
                EditorGUILayout.LabelField(Constants.CustomEditor.SEPARATOR);

                //let a blank
                EditorGUILayout.LabelField(string.Empty);
                //The datas part
                EditorGUILayout.LabelField(DATAS_PART, GuiStyles.titleStyle);

                mLevelProperty.intValue = EditorGUILayout.IntSlider(LEVEL_TITLE,mLevelProperty.intValue, 0, 3);

                //At level 0 the side is always neutral
                if(mLevelProperty.intValue > 0)
                {
                    mSideProperty.enumValueIndex = (int)(SquareSide)EditorGUILayout.EnumPopup(SIDE_TITLE, (SquareSide)mSideProperty.enumValueIndex);
                }
                else
                {
                    mSideProperty.enumValueIndex = (int)SquareSide.NEUTRAL;
                }
            }

            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();
        }
        #endregion Methods
    }
}

