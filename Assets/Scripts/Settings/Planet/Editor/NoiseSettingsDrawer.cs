using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(NoiseSettings))]
public class NoiseSettingsDrawer : PropertyDrawer
{
    private Editor _editor = null;
 
    public override void OnGUI ( Rect position, SerializedProperty property, GUIContent label )
    {

        CustomEditorHelpers.DrawHeader("Noise settings");
        
        EditorGUI.BeginProperty(position, label, property);
 
        var strengthProperty = property.FindPropertyRelative("Strength");
        var baseRoughtnessProperty = property.FindPropertyRelative("BaseRoughness");
        var roughnessProperty = property.FindPropertyRelative("Roughness");
        var persistenceProperty = property.FindPropertyRelative("Persistence");
        var layersProperty = property.FindPropertyRelative("Layers");
        var minHeightProperty = property.FindPropertyRelative("MinHeight");
       
        EditorGUI.BeginChangeCheck();
        
        var strenghtValue = EditorGUILayout.Slider("Strenght", strengthProperty.floatValue, 0, 1);
        var baseRoughtnessValue = EditorGUILayout.Slider("Base roughtness",baseRoughtnessProperty.floatValue, 0, 5);
        var roughtnessValue = EditorGUILayout.Slider("Roughtness",roughnessProperty.floatValue, 0, 5);
        var persistenceValue = EditorGUILayout.Slider("Persistence", persistenceProperty.floatValue, 0, 1);
        var layersValue = (int)EditorGUILayout.Slider("Layers", layersProperty.intValue, 1, 8);
        var minHeightValue = EditorGUILayout.Slider("MinHeight", minHeightProperty.floatValue, 0, 5);
        
        
        if (EditorGUI.EndChangeCheck())
        {
            strengthProperty.floatValue = strenghtValue;
            baseRoughtnessProperty.floatValue = baseRoughtnessValue;
            roughnessProperty.floatValue = roughtnessValue;
            persistenceProperty.floatValue = persistenceValue;
            layersProperty.intValue = layersValue;
            minHeightProperty.floatValue = minHeightValue;
        }
 
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        
        EditorGUI.EndProperty();
    }
}