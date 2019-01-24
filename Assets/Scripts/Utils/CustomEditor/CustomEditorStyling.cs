using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Struct that store the main colors to create new stylings.
/// </summary>
public struct CustomEditorStyling
{
    public CustomEditorStyling(Color headerBackground, Color includeBackground, Color separator)
    {
        HeaderBackground = headerBackground;
        IncludeBackground = includeBackground;
        Separator = separator;
    }
    
    public Color HeaderBackground;
    public Color IncludeBackground;
    public Color Separator;
}
