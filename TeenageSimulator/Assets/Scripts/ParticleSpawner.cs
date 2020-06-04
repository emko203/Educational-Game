using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem MovementIndicator;

    public void SpawnMovementParticles(Vector3 posToSpawnAt)
    {
        Instantiate(MovementIndicator, posToSpawnAt, Quaternion.identity);
    }
}
