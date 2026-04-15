using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _forceExplode;
    [SerializeField] private float _radiusExplode;

    public void Explode(List<Rigidbody> objects, Vector3 positionCube)
    {
        foreach (Rigidbody exploadeObject in objects)
        {
            exploadeObject.AddExplosionForce(_forceExplode, positionCube, _radiusExplode);
        }
    }
}