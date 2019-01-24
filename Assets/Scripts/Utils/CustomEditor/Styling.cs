using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Styling
{
    public Styling(Color categoryBackground, Color includeBackground, Color separator)
    {
        CategoryBackground = categoryBackground;
        IncludeBackground = includeBackground;
        Separator = separator;
    }
    
    public Color CategoryBackground;
    public Color IncludeBackground;
    public Color Separator;
}
