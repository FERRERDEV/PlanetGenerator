using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "PlanetGenerator/Planet Settings")]
public class PlanetSettings : ScriptableObject
{
    [Range(2, 256)] 
    public int Resolution = 64;
    
    [Range(1, 100)]
    public int Radius = 1;

    public NoiseSettings NoiseSettings;

}
