using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField, Min(1)] private int _minSpliteCube;
    [SerializeField, Min(1)] private int _maxSpliteCube;

    private void OnValidate()
    {
        if (_minSpliteCube >= _maxSpliteCube)
        {
            _minSpliteCube = _maxSpliteCube;
        }
    }

    public List<Rigidbody> SpawnObjects(Cube clickedCube)
    {
        List<Rigidbody> explodeObjects = new List<Rigidbody>();
        int countSpliteCube = UnityEngine.Random.Range(_minSpliteCube, _maxSpliteCube + 1);

        for (int i = 0; i < countSpliteCube; i++)
        {
            var cubeCopy = Instantiate(clickedCube.gameObject, clickedCube.transform.position, clickedCube.transform.rotation);
            Rigidbody createdCubeRigidbody = cubeCopy.GetComponent<Rigidbody>();
            explodeObjects.Add(createdCubeRigidbody);
        }

        return explodeObjects;
    }
}