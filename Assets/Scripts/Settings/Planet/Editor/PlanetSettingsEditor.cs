using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlanetSettings))]
public class PlanetSettingsEditor : Editor
{
    [SerializeField]
    private PlanetSettings _planetSettings;
    private Editor _planetSettingsEditor;
    
    public override void OnInspectorGUI()
    {
        _planetSettings = (PlanetSettings)target;

        SerializedObject obj = new SerializedObject(target);
        SerializedProperty prop = obj.FindProperty("NoiseSettings");
        
        CustomEditorHelpers.DrawHeader("Planet settings");

        _planetSettings.Resolution = (int)EditorGUILayout.Slider("Resolution", _planetSettings.Resolution, 2, 128);
        _planetSettings.Radius = (int)EditorGUILayout.Slider("Radius", _planetSettings.Radius, 2, 128);
        
        EditorGUILayout.PropertyField(obj.FindProperty("NoiseSettings"));
        obj.ApplyModifiedProperties();
    }

}
