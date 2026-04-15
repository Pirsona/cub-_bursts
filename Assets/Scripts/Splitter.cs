using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{

    [SerializeField, Min(1)] private int _minSpliteCube;
    [SerializeField, Min(1)] private int _maxSpliteCube;

    [SerializeField] private float _decreaseScale;

    private void OnValidate()
    {
        if(_minSpliteCube >= _maxSpliteCube)
        {
            _minSpliteCube = _maxSpliteCube;
        }
    }

    public List<Rigidbody> SpawnObjects( int currentChanceSplit)
    {
        List<Rigidbody> newObject = new List<Rigidbody>();

        int countSpliteCube = UnityEngine.Random.Range(_minSpliteCube, _maxSpliteCube + 1);
        transform.localScale /= _decreaseScale;

        for (int i = 0; i < countSpliteCube; i++)
        {
            var createdCube = Instantiate(gameObject, transform.position, transform.rotation);
            Rigidbody createdCubeRigidbody = createdCube.GetComponent<Rigidbody>();
            Cube createdCubeScript = createdCube.GetComponent<Cube>();
            createdCubeScript.SetupChance(currentChanceSplit);
            newObject.Add(createdCubeRigidbody);
        }

        return newObject;
    }
}
