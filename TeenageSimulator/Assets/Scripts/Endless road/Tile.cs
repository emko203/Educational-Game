using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Transform _nextPosition;
    [SerializeField]
    private float speed = 12;
    [SerializeField]
    private float despawnDistance = -20;

    public void Awake()
    {
        StartCoroutine(WaitForDestroy());
    }
    public Transform GetSpawnPosition() 
    {
        return _nextPosition;
    }

    private void Update()
    {
        MoveSelf();
    }

    private void MoveSelf()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    private IEnumerator WaitForDestroy()
    {
        while (transform.position.x >= despawnDistance)
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}
