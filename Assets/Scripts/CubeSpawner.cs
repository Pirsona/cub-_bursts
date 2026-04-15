using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{

    [SerializeField, Min(1)] private int _minSpliteCube;
    [SerializeField, Min(1)] private int _maxSpliteCube;

    [SerializeField] private InputReader _reader;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private float _decreaseScale;

    private int _decreaseNumberChance = 2;

    private void OnValidate()
    {
        if (_minSpliteCube >= _maxSpliteCube)
        {
            _minSpliteCube = _maxSpliteCube;
        }
    }

    private void OnEnable()
    {
        _reader.MouseClicked += Initiate;
    }

    private void OnDisable()
    {
        _reader.MouseClicked -= Initiate;
    }

    public void Initiate(Cube cube)
    {
        Cube currentCube = cube;
        int currentChance = currentCube.CurrentChanceSplit;

        if (IsSuccessSplit(currentCube))
        {
            int newChance = currentCube.CurrentChanceSplit / _decreaseNumberChance;
            List<Rigidbody> explodeObject = SpawnObjects(currentCube, newChance);

            _exploder.Explode(explodeObject);
        }

        Destroy(currentCube.gameObject);
    }

    public List<Rigidbody> SpawnObjects(Cube clickedCube, int newChance)
    {
        List<Rigidbody> explodeObjects = new List<Rigidbody>();

        int countSpliteCube = UnityEngine.Random.Range(_minSpliteCube, _maxSpliteCube + 1);
        clickedCube.transform.localScale /= _decreaseScale;

        for (int i = 0; i < countSpliteCube; i++)
        {
            var cubeCopy = Instantiate(clickedCube.gameObject, clickedCube.transform.position, clickedCube.transform.rotation);
            Cube cubeComponent = cubeCopy.GetComponent<Cube>();
            Rigidbody createdCubeRigidbody = cubeCopy.GetComponent<Rigidbody>();
            _colorChanger.Paint(cubeComponent.Renderer);
            cubeComponent.SetupChance(newChance);
            explodeObjects.Add(createdCubeRigidbody);
        }

        return explodeObjects;
    }

    private bool IsSuccessSplit(Cube cube)
    {
        return UnityEngine.Random.Range(1, cube.MaxChanceSplit + 1) <= cube.CurrentChanceSplit;
    }
}