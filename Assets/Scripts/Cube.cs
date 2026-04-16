using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private int _maxChanceSplit;

    public Rigidbody Rigidbody { get; private set; }
    public int CurrentChanceSplit { get; private set; }

    public int MaxChanceSplit => _maxChanceSplit;

    private void Awake()
    {
        CurrentChanceSplit = _maxChanceSplit;
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void SetupChance(int newChance)
    {
        CurrentChanceSplit = newChance;
    }
}