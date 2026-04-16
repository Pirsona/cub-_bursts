using UnityEngine;

public class AreaExploder : MonoBehaviour
{
    [SerializeField] private float _forceExplode;
    [SerializeField] private float _radiusExplode;

    public void ExplodeInRadius(Vector3 positionCube, float scaleModifier)
    {
        float scaledForcedExplode = _forceExplode * scaleModifier;
        float scaledRadiusExplode = _radiusExplode * scaleModifier;

       Collider[] hitColliders =  Physics.OverlapSphere(positionCube, scaledRadiusExplode);

        foreach (var collider in hitColliders)
        {
            if (collider.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(scaledForcedExplode, positionCube, scaledRadiusExplode);
            }
        }
    }
}