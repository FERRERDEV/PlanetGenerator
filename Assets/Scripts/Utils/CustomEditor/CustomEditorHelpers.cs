using UnityEngine;
using UnityEditor;

public static class CustomEditorHelpers
{
    /// <summary>
    /// Draws a in line text header with background color.
    /// </summary>
    /// <param name="header">Text to be displayed on the header.</param>
    public static void DrawHeader(string header)
    {
        EditorGUILayout.BeginHorizontal(CustomEditorStyles.Header);
        GUILayout.Label(header, EditorStyles.boldLabel);
        EditorGUILayout.EndHorizontal();
    }
    
    /// <summary>
    /// Returns a 1x1 sized and colored texture.
    /// </summary>
    /// <param name="color">Color of the texture.</param>
    /// <returns>1x1 Colored texture.</returns>
    public static Texture2D CreateColorTexture(Color color)
    {
        var tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, color);
        tex.Apply(false, true);
        return tex;
    }
}
