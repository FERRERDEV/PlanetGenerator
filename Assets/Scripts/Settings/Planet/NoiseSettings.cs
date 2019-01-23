using UnityEngine;
using System;

[Serializable]
public class NoiseSettings
{
    [Range(0,10)]
    public float Strength = 1;
    [Range(0,10)]
    public float BaseRoughness = 1;
    [Range(0,10)]
    public float Roughness = 1;

    [Range(0,10)]
    public float Persistence = 0.5f;
    
    [Range(1,8)]
    public int Layers = 1;
    
    public Vector3 Center;

    public float MinHeight;
}
