using UnityEngine;
using UnityEditor;

/// <summary>
/// Static class to handle Styling structures
/// </summary>
public static class CustomEditorStyles
{
    static Color Grey(float amount)
    {
        return new Color(amount, amount, amount, 1f);
    }

    static CustomEditorStyling _personalCustomEditorStyling = new CustomEditorStyling(
        Grey(0.65f),
        Grey(0.725f),
        Grey(0.8f));


    static CustomEditorStyling _professionalCustomEditorStyling = new CustomEditorStyling(
        Grey(0.32f),
        Grey(0.2f),
        Grey(0.175f));
    
    static CustomEditorStyling Style = EditorGUIUtility.isProSkin ? _professionalCustomEditorStyling : _personalCustomEditorStyling;

    /// <summary>
    /// Returns header GUIStyle.
    /// </summary>
    public static GUIStyle Header
    {
        get
        {
            GUIStyle style = new GUIStyle();
            style.normal.background = CustomEditorHelpers.CreateColorTexture(Style.HeaderBackground);
            style.overflow = new RectOffset(20, 20, -3, -3);
            style.margin = style.padding = new RectOffset();
            return style;
        }
    }
}
