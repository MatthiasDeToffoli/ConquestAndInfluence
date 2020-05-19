using Boo.Lang;
using fr.matthiasdetoffoli.ConquestAndInfluence.Core;
using fr.matthiasdetoffoli.ConquestAndInfluence.Utils;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Classes.PersonalEditor;
using fr.matthiasdetoffoli.GlobalUnityProjectCode.Utils;
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace fr.matthiasdetoffoli.ConquestAndInfluence.PersonalEditor
{
    /// <summary>
    /// Custom editor for the CoreGameManager class
    /// </summary>
    /// <seealso cref="Editor"/>
    /// <seealso cref="CoreGameManager"/>"/>
    [CustomEditor(typeof(CoreGameManager), true)]
    public class CoreGameManagerEditor : Editor
    {
        #region Constants
        /// <summary>
        /// the title sprites part
        /// </summary>
        private const string MAPS_PART = "Maps part :";

        /// <summary>
        /// The manager part title
        /// </summary>
        private const string MANAGER_PART = "Manager part :";

        /// <summary>
        /// the title show in inspector for the Resources Square Paths property
        /// </summary>
        private const string RESOURCES_SQUARES_PATHS_TITLE = "Paths of folders containing the square's sprites";

        /// <summary>
        /// the title show in inspector for the Squares sprites prefix property
        /// </summary>
        private const string SQUARES_SPRITES_PREFIX_TITLE = "Squares sprites prefix";
        #endregion Constants

        #region Fields
        /// <summary>
        /// The arrow toggle for the array ResourcesSquaresPaths
        /// </summary>
        private bool mShowResourcesSquaresPathsArray;

        /// <summary>
        /// The arrow toggle for the array SquaresSpritePrefix
        /// </summary>
        private bool mShowSquaresSpritePrefixArray;
        #endregion Fields

        #region Methods
        /// <summary>
        /// When the inspector is updated
        /// </summary>
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField(MANAGER_PART, GuiStyles.titleStyle);
            //Draw the default inspector
            DrawDefaultInspector();
            //Separate the two parts
            EditorGUILayout.LabelField(Constants.CustomEditor.SEPARATOR);
            //Let a blank
            EditorGUILayout.LabelField(string.Empty);
            //The sprite parts
            EditorGUILayout.LabelField(MAPS_PART, GuiStyles.titleStyle);

            EditorGUI.BeginChangeCheck();

            //Write the resources square paths array
            SpriteNameBuilder.resourcesSquarePaths = 
                UpdateArrayWithGUI(SpriteNameBuilder.resourcesSquarePaths,RESOURCES_SQUARES_PATHS_TITLE,ref mShowResourcesSquaresPathsArray);

            SpriteNameBuilder.squaresSpritesPrefix =
                UpdateArrayWithGUI(SpriteNameBuilder.squaresSpritesPrefix,SQUARES_SPRITES_PREFIX_TITLE, ref mShowSquaresSpritePrefixArray);

            if (EditorGUI.EndChangeCheck())
                serializedObject.ApplyModifiedProperties();

            //Rewrite the Sprite name builder class for save the changements
            if (GUILayout.Button("Save SpriteNameBuilder.cs"))
            {
                SaveSpriteNameBuilder();
            }
        }

        /// <summary>
        /// Save the script SpriteNameBuilder.cs with the arrays datas
        /// </summary>
        private void SaveSpriteNameBuilder()
        {
            //Read the current file
            string[] lOldSpriteNameBuilderFile = File.ReadAllLines(SpriteNameBuilder.path);

            List<string> lNewSpriteNameBuilderFile = new List<string>();
            string lOldLine = string.Empty;

            for (int i = 0, l = lOldSpriteNameBuilderFile.Length; i < l; i++)
            {
                //Search the declaration of the string array
                if (lOldLine.Contains("public static string[]"))
                {
                    //Do action online at the end of the declarations of the array
                    if (lOldSpriteNameBuilderFile[i].Contains("};"))
                    {
                        if (lOldLine.Contains("resourcesSquarePaths"))
                        {
                            //Save the new resourcesSquarePaths array values
                            lNewSpriteNameBuilderFile =
                                BuildArrayForSaving(lNewSpriteNameBuilderFile, SpriteNameBuilder.resourcesSquarePaths);
                        } 
                        else if (lOldLine.Contains("squaresSpritesPrefix"))
                        {
                            //Save the new squaresSpritesPrefix array values
                            lNewSpriteNameBuilderFile =
                                BuildArrayForSaving(lNewSpriteNameBuilderFile, SpriteNameBuilder.squaresSpritesPrefix);
                        }
                        //set the old line for restart to save the other lines of the script
                        lOldLine = "};";
                    }
                }
                else
                {
                    //Get the old line for check it in the next iteration
                    lOldLine = lOldSpriteNameBuilderFile[i];
                    //Add the line because it didn't need to be modified
                    lNewSpriteNameBuilderFile.Add(lOldLine);
                }
            }
            //Save the file SpriteNameBuilder.cs
            File.WriteAllLines(SpriteNameBuilder.path, lNewSpriteNameBuilderFile);
        }

        /// <summary>
        /// Build the arrays for saved them in the SpriteNameBuilder file
        /// </summary>
        /// <param name="pNewFile">the list contain all the line of the file</param>
        /// <param name="pArrayToSave">the array to save</param>
        /// <returns>the list with the arrays datas in</returns>
        private List<string> BuildArrayForSaving(List<string> pNewFile, string[] pArrayToSave)
        {
            //Instantiate the string
            pNewFile.Add(string.Format("            new string[{0}]", pArrayToSave.Length));
            //Open the bracket for set all the value
            pNewFile.Add("            {");
            //Set all the values
            foreach (string lItem in pArrayToSave)
            {
                pNewFile.Add(string.Format("                \"{0}\",", lItem));
            }
            //close the bracket
            pNewFile.Add("            };");
            return pNewFile;
        }
        /// <summary>
        /// Create a gui array and update the target's array
        /// </summary>
        /// <param name="pArray">the target's array</param>
        /// <param name="pArrayName">the name of the array</param>
        /// <param name="pShow">the arrow for hide or show the array</param>
        /// <returns>the array updated</returns>
        private string[] UpdateArrayWithGUI(string[] pArray,string pArrayName, ref bool pShow)
        {
            //Create the arrow
            pShow = EditorGUILayout.Foldout(pShow, pArrayName);

            //if the arrow is open
            if (pShow)
            {
                //Create the size part
                int lLength = EditorGUILayout.IntField(Constants.CustomEditor.ARRAY_SIZE, pArray.Length);
                //Create a new array we will take the values
                string[] lResourcesSquarePaths = new string[lLength];

                //If the length <= 0 don't show the lements
                if (lLength > 0)
                {
                    string lOldValue;
                    for (int i = 0; i < lLength; i++)
                    {
                        //get the old value or string.empty
                        if (i < pArray.Length)
                        {
                            lOldValue = pArray[i];
                        }
                        else
                        {
                            lOldValue = string.Empty;
                        }
                        //create the elements
                        lResourcesSquarePaths[i] =
                            EditorGUILayout.TextField(string.Format(Constants.CustomEditor.ARRAY_ELEMENT, i), lOldValue);
                    }
                }
                //the aray updated
                return lResourcesSquarePaths;
            }
            //return the old array if the arrow is closed
            return pArray;
        }
        #endregion Methods
    }
}