using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altitude
{
    public float MinAltitude;
    public float MaxAltitude;

    public Altitude()
    {
        MinAltitude = float.MaxValue;
        MaxAltitude = float.MinValue;
    }

    /// <summary>
    /// Evaluates a altitude point
    /// </summary>
    /// <param name="value"></param>
    public void Evaluate(float value)
    {
        if (value < MinAltitude)
            MinAltitude = value;
        
        if (value > MaxAltitude)
            MaxAltitude = value;
    }
}
