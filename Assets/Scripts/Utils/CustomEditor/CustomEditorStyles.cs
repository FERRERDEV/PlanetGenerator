using UnityEngine;
using UnityEditor;

public class CustomEditorStyles
{
    static Color Grey(float amount)
    {
        return new Color(amount, amount, amount, 1f);
    }

    static Styling PersonalStyling = new Styling(
        Grey(0.65f),
        Grey(0.725f),
        Grey(0.8f));


    static Styling ProfessionalStyling = new Styling(
        Grey(0.32f),
        Grey(0.2f),
        Grey(0.175f));
    
    static Styling Style = EditorGUIUtility.isProSkin ? ProfessionalStyling : PersonalStyling;

    public static GUIStyle Background
    {
        get
        {
            GUIStyle style = new GUIStyle();
            style.normal.background = CreateColorTexture(Style.CategoryBackground);
            style.overflow = new RectOffset(20, 20, -3, -3);
            style.margin = style.padding = new RectOffset();
            return style;
        }
    }
    
    static Texture2D CreateColorTexture(Color color)
    {
        var tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, color);
        tex.Apply(false, true);
        return tex;
    }
}
