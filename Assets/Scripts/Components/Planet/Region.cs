using UnityEngine;

/// <summary>
/// Base class to construct each planet region.
/// </summary>
public class Region
{
    private Mesh _mesh;
    private int _resolution;
    private int _radious;
    
    private Vector3 _localUp;
    private Vector3 _axisA;
    private Vector3 _axisB;

    private NoiseFilter _noiseFilter;

    /// <summary>
    /// Region constructor.
    /// </summary>
    /// <param name="mesh">Mesh reference.</param>
    /// <param name="resolution">Amount of vertices per side.</param>
    /// <param name="radius">Distance from the center.</param>
    /// <param name="localUp">Direction vector away from the center.</param>
    /// <param name="noiseFilter">Noise filter to be applied.</param>
    public Region(Mesh mesh, int resolution, int radius, Vector3 localUp, NoiseFilter noiseFilter)
    {
        _mesh = mesh;
        _resolution = resolution;
        _radious = radius;
        _localUp = localUp;
        _noiseFilter = noiseFilter;
        
        _axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        _axisB = Vector3.Cross(localUp, _axisA);
    }
    
    /// <summary>
    /// Build the mesh with the region params.
    /// </summary>
    public void ConstructMesh(out float elevation)
    {
        Vector3[] vertices = new Vector3[_resolution * _resolution];
        int[] triangles = new int[(_resolution - 1) * (_resolution - 1) * 6];
        int triIndex = 0;
        float elevationA = 0;
        
        for (int y = 0; y < _resolution; y++)
        {
            for (int x = 0; x < _resolution; x++)
            {
                int i = x + y * _resolution;
                Vector2 percent = new Vector2(x, y) / (_resolution - 1);
                Vector3 pointOnUnitCube = _localUp + (percent.x - .5f) * 2 * _axisA + (percent.y - .5f) * 2 * _axisB;
                Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;
                vertices[i] = PointOnPlanet(pointOnUnitSphere, out elevationA);

                if (x != _resolution - 1 && y != _resolution - 1)
                {
                    triangles[triIndex] = i;
                    triangles[triIndex + 1] = i + _resolution + 1;
                    triangles[triIndex + 2] = i + _resolution;

                    triangles[triIndex + 3] = i;
                    triangles[triIndex + 4] = i + 1;
                    triangles[triIndex + 5] = i + _resolution + 1;
                    triIndex += 6;
                }
            }
        }

        elevation = elevationA;
        
        _mesh.Clear();
        _mesh.vertices = vertices;
        _mesh.triangles = triangles;
        _mesh.RecalculateNormals();
    }

    private Vector3 PointOnPlanet(Vector3 pointOnUnitSphere, out float elevation)
    {
        elevation = _radious * (1 + _noiseFilter.Evaluate(pointOnUnitSphere));
        return pointOnUnitSphere * elevation;
    }
}
