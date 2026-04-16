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

    public List<Cube> SpawnObjects(Cube clickedCube)
    {
        List<Cube> explodeObjects = new List<Cube>();
        int countSpliteCube = UnityEngine.Random.Range(_minSpliteCube, _maxSpliteCube + 1);

        for (int i = 0; i < countSpliteCube; i++)
        {
            var cubeCopy = Instantiate(clickedCube, clickedCube.transform.position, clickedCube.transform.rotation);
            explodeObjects.Add(cubeCopy);
        }

        return explodeObjects;
    }
}