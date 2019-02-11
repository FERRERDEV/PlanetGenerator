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

        SerializedObject planetSettings= new SerializedObject(target);
        
        CustomEditorHelpers.DrawHeader("Planet settings");

        _planetSettings.Resolution = (int)EditorGUILayout.Slider("Resolution", _planetSettings.Resolution, 2, 128);
        _planetSettings.Radius = (int)EditorGUILayout.Slider("Radius", _planetSettings.Radius, 1, 128);
        
        EditorGUILayout.PropertyField(planetSettings.FindProperty("NoiseSettings"));

        CustomEditorHelpers.DrawHeader("Color settings");

        _planetSettings.ColorSettings.Gradient =
            EditorGUILayout.GradientField("Gradient", _planetSettings.ColorSettings.Gradient);
        
        planetSettings.ApplyModifiedProperties();
    }

}
