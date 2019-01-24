using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{
    private Planet _planet;
    private Editor _planetEditor;
    
    public override void OnInspectorGUI()
    {
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            if (check.changed)
            {
                _planet.Generate();
            }
        }

        EditorGUILayout.BeginHorizontal(CustomEditorStyles.Header);
        GUILayout.Label("Data asset", EditorStyles.boldLabel);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();
        
        EditorGUI.BeginChangeCheck();
        
        _planet.PlanetSettings = EditorGUILayout.ObjectField(_planet.PlanetSettings, typeof(PlanetSettings), false) as PlanetSettings;
       
        if(EditorGUI.EndChangeCheck())
            _planet.Generate();
        
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        
        DrawSettingsEditor(_planet.PlanetSettings, _planet.Generate, ref _planetEditor);
    }
    
    void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, ref Editor editor)
    {
        if (settings != null)
        {
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                CreateCachedEditor(settings, null, ref editor);
                editor.OnInspectorGUI();

                if (check.changed)
                {
                    if (onSettingsUpdated != null)
                    {
                        onSettingsUpdated();
                    }
                }
            }
        }
    }

    private void OnEnable()
    {
        _planet = (Planet)target;
        
        _planet.Generate();
    }
    
}
