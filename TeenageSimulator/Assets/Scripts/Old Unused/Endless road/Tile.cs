using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Transform _nextPosition;    
    [SerializeField]
    private float despawnDistance = -60;

    public void Awake()
    {
        StartCoroutine(WaitForDestroy());
    }
    public Transform GetSpawnPosition() 
    {
        
        return _nextPosition;
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
