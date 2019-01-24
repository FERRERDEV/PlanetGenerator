﻿using UnityEngine;

/// <summary>
/// Base class of the planet generator.
/// </summary>
public class Planet : MonoBehaviour
{
    public PlanetSettings PlanetSettings;
    
    private MeshFilter[] _meshFilters;
    private Region[] _regions;
    
    private Vector3[] _directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };


    /// <summary>
    /// Generate the planet with the given planet settings.
    /// </summary>
    public void Generate()
    {
        if (_meshFilters == null || _meshFilters.Length == 0)
        {
            _meshFilters = new MeshFilter[6];
        }
        
        _regions = new Region[6];

        for (int i = 0; i < 6; i++)
        {
            if (_meshFilters[i] == null)
            {
                GameObject meshObj;

                if (transform.GetChild(i) != null)
                    meshObj = transform.GetChild(i).gameObject;
                else
                    meshObj = new GameObject("Region");
                
                
                meshObj.transform.parent = transform;
                
                if(meshObj.GetComponent<MeshRenderer>() == null)
                    meshObj.AddComponent<MeshRenderer>().sharedMaterial = new Material(Shader.Find("Standard"));
                
                _meshFilters[i] = meshObj.GetComponent<MeshFilter>() != null ? meshObj.GetComponent<MeshFilter>() : meshObj.AddComponent<MeshFilter>();
                _meshFilters[i].sharedMesh = new Mesh();
            }
            
            _regions[i] = new Region(_meshFilters[i].sharedMesh, PlanetSettings.Resolution, PlanetSettings.Radius, _directions[i], new NoiseFilter(PlanetSettings.NoiseSettings));
        }
        
        GenerateMesh();
    }

    /// <summary>
    /// Construct the mesh for each defined region.
    /// </summary>
    void GenerateMesh()
    {
        foreach (Region region in _regions)
        {
            region.ConstructMesh();
        }
    }
}
