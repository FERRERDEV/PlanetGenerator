using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFilter
{
    private NoiseSettings _settings;
    private Noise _noise = new Noise();

    public NoiseFilter(NoiseSettings settings)
    {
        _settings = settings;
    }
    
    public float Evaluate(Vector3 point)
    {
        return ((_noise.Evaluate(point * _settings.Roughness + _settings.Center) + 1) * 0.5f) * _settings.Strength;
    }
}
