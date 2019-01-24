﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class of the noise to be applied on each region.
/// </summary>
public class NoiseFilter
{
    private NoiseSettings _settings;
    private Noise _noise = new Noise();

    /// <summary>
    /// Noise filter constructor.
    /// </summary>
    /// <param name="settings">Noise settings reference.</param>
    public NoiseFilter(NoiseSettings settings)
    {
        _settings = settings;
    }
    
    /// <summary>
    /// Give the elevation value of a mesh point.
    /// </summary>
    /// <param name="point">Point on the mesh</param>
    /// <returns>Elevation value</returns>
    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = _settings.BaseRoughness;
        float amplitude = 1;

        for (int i = 0; i < _settings.Layers; i++)
        {
            float v = _noise.Evaluate(point * frequency + _settings.Center);
            noiseValue += (v + 1) * 0.5f * amplitude;
            frequency *= _settings.Roughness;
            amplitude *= _settings.Persistence;
        }

        noiseValue = Mathf.Max(0, noiseValue - _settings.MinHeight);
        return noiseValue * _settings.Strength;
    }
}
