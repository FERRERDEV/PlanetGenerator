using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class EditorRotator : MonoBehaviour 
{
    public float Rotation;
 
    void OnEnable()
    {
        EditorApplication.update += EditorUpdate;
    }
 
    void EditorUpdate () 
    {
        this.transform.Rotate(new Vector3(0,Rotation,0));
    }
 
    void OnDisable()
    {
        EditorApplication.update -= EditorUpdate;
    }
}
