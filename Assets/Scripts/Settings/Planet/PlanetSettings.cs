using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlanetGenerator/Planet Settings")]
public class PlanetSettings : ScriptableObject
{
    [Range(2, 256)] 
    public int Resolution = 64;
    
    [Range(1, 100)]
    public int Radious = 1;

    public NoiseSettings NoiseSettings;

}
