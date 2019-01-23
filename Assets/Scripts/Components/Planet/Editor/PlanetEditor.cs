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
            base.OnInspectorGUI();
            if (check.changed)
            {
                _planet.Generate();
            }
        }
        
        DrawSettingsEditor(_planet.PlanetSettings, _planet.Generate, ref _planetEditor);
        
        if (GUILayout.Button("Generate Planet"))
        {
            _planet.Generate();
        }
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
    }
    
}
