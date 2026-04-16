using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private InputReader _reader;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private float _decreaseScale;

    private int _decreaseNumberChance = 2;

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

        if (IsSuccessSplit(currentCube))
        {
            int newChance = currentCube.CurrentChanceSplit / _decreaseNumberChance;
            Vector3 newScale = cube.transform.localScale / _decreaseScale;

            List<Cube> createdObjects = _cubeSpawner.SpawnObjects(currentCube);

            SetUpChildren(createdObjects, newChance, newScale);

            _exploder.Explode(createdObjects, cube.transform.position);
        }

        Destroy(currentCube.gameObject);
    }

    private void SetUpChildren(List<Cube> children, int newChance, Vector3 newScale)
    {
        foreach (var child in children)
        {
            child.transform.localScale = newScale;
            child.SetupChance(newChance);
        }
    }

    private bool IsSuccessSplit(Cube cube)
    {
        return UnityEngine.Random.Range(1, cube.MaxChanceSplit + 1) <= cube.CurrentChanceSplit;
    }
}
