using UnityEngine;

public class RandomColor : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
