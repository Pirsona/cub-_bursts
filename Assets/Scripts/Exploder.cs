using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _forceExplode;
    [SerializeField] private float _radiusExplode;

    public void Explode(List<Cube> objects, Vector3 positionCube)
    {
        foreach (Cube exploadeObject in objects)
        {
            exploadeObject.Rigidbody.AddExplosionForce(_forceExplode, positionCube, _radiusExplode);
        }
    }
}