using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }   
}
