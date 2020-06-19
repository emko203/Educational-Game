using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem MovementIndicator;
    [SerializeField] private ParticleSystem InteractableIndicator;

    public void SpawnMovementParticles(Vector3 posToSpawnAt)
    {
        InstantiateParticle(MovementIndicator, posToSpawnAt);
    }

    public void SpawnInteractableClickParticles(Vector3 posToSpawnAt)
    {
        InstantiateParticle(InteractableIndicator, posToSpawnAt);
    }

    private void InstantiateParticle(ParticleSystem particlesToSpawn, Vector3 posToSpawnAt)
    {
        Instantiate(particlesToSpawn, posToSpawnAt, Quaternion.identity);
    }
}
