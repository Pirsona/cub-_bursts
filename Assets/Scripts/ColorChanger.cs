using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private void Start()
    {
       var allCube = FindObjectsOfType<Cube>();

        foreach(Cube cube in allCube)
        {
            Paint(cube.Renderer);
        }
    }
    public void Paint(Renderer targetRenderer)
    {
        targetRenderer.material.color = Random.ColorHSV();
    }    
}
