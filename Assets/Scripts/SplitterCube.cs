using System.Collections.Generic;
using UnityEngine;

public class SplitterCube : MonoBehaviour
{

    [SerializeField, Min(1)] private int _minSpliteCube;
    [SerializeField, Min(1)] private int _maxSpliteCube;

    [SerializeField] private float _decreaseScale;
    [SerializeField] private int _maxChanceSplit;
    [SerializeField] private float _forceExplode;
    [SerializeField] private float _radiusExplode;

    private int _currentChanceSplit;
    private System.Random _random = new System.Random();


    private void OnValidate()
    {
        if(_minSpliteCube >= _maxSpliteCube)
        {
            _minSpliteCube = _maxSpliteCube;
        }
    }

    private void Awake()
    {
        _currentChanceSplit = _maxChanceSplit;
    }


    public void Setup(int newChanceSplit)
    {
        _currentChanceSplit = newChanceSplit;
        transform.localScale /= _decreaseScale;
    }

    public void Initiate()
    {
        if (IsSuccessSplit())
        {
            List<Rigidbody> newObject = SpawnObjects();

            Explode(newObject);
        }

        Destroy(gameObject);
    }

    private List<Rigidbody> SpawnObjects()
    {
        List<Rigidbody> newObject = new List<Rigidbody>();
        _currentChanceSplit = DecreaseChance();

        int countSpliteCube = _random.Next(_minSpliteCube, _maxSpliteCube + 1);

        for (int i = 0; i < countSpliteCube; i++)
        {
            var createdCube = Instantiate(gameObject, transform.position, transform.rotation);
            Rigidbody createdCubeRigidbody = createdCube.GetComponent<Rigidbody>();
            SplitterCube createdCubeScript = createdCube.GetComponent<SplitterCube>();

            createdCubeScript.Setup(_currentChanceSplit);
            newObject.Add(createdCubeRigidbody);
        }

        return newObject;
    }

    private void Explode(List<Rigidbody> objects)
    {
        foreach (Rigidbody exploableObject in objects)
        {
            exploableObject.AddExplosionForce(_forceExplode, transform.position, _radiusExplode);
        }
    }

    private bool IsSuccessSplit()
    {
        return _random.Next(1, _maxChanceSplit + 1) <= _currentChanceSplit;
    }

    private int DecreaseChance()
    {
        return _currentChanceSplit / 2;
    }
}
