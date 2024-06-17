using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CustomAttributes
{
    [CustomPropertyDrawer(typeof(OnBuildGetComponentAttribute))]
    public class PrebuildGetComponentPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}

