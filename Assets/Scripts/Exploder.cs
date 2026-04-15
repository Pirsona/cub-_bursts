using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _forceExplode;
    [SerializeField] private float _radiusExplode;

    public void Explode(List<Rigidbody> objects)
    {
        foreach (Rigidbody exploableObject in objects)
        {
            exploableObject.AddExplosionForce(_forceExplode, transform.position, _radiusExplode);
        }
    }
}