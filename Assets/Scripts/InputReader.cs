using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance;
   
    public event Action<Cube> MouseClicked;
    
    private int _leftMouseClicked = 0;

    private void Update()
    {
        Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(_ray.origin, _ray.direction * _maxDistance, Color.red);

        if (Input.GetMouseButtonUp(_leftMouseClicked))
        {

            if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
            {
                if(hit.transform.TryGetComponent(out Cube cube))
                {
                    MouseClicked?.Invoke(cube);
                }
            }
        }
    }
}