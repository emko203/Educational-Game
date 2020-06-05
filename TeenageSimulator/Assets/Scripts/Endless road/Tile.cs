using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Transform _nextPosition;

    public Transform GetSpawnPosition() 
    {
        return _nextPosition;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * 12);
    }
}
