using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Splitter _splitter;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private int _maxChanceSplit;

    private int _currentChanceSplit;
    private int decreaseNumberChance = 2;

    private void Awake()
    {
        _currentChanceSplit = _maxChanceSplit;
    }

    public void Initiate()
    {
        if (IsSuccessSplit())
        {
            _currentChanceSplit = DecreaseChance();
            List<Rigidbody> newObject = _splitter.SpawnObjects(_currentChanceSplit);

            _exploder.Explode(newObject);
        }

        Destroy(gameObject);
    }

    public void SetupChance(int newChance)
    {
        _currentChanceSplit = newChance;
    }

    private bool IsSuccessSplit()
    {
        return UnityEngine.Random.Range(1, _maxChanceSplit + 1) <= _currentChanceSplit;
    }

    private int DecreaseChance()
    {
        return _currentChanceSplit / decreaseNumberChance;
    }

}
