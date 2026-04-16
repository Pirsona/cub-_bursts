using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class ColorChanger : MonoBehaviour
{
    private void Start()
    {
       GetComponent<Renderer>().material.color = Random.ColorHSV();
    }   
}