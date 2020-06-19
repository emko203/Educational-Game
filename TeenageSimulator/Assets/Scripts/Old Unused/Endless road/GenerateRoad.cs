using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoad : MonoBehaviour
{
    private IEnumerator coroutine;
    public GameObject road;
    public float interval;

    private List<GameObject> tiles = new List<GameObject>();

    void Start()
    {
        coroutine = WaitAndInstantiate(interval);
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndInstantiate(float waitTime)
    {
        float pos = 0;
        while (true)
        {          
            yield return new WaitForSeconds(waitTime);
            if(tiles.Count < 10)
            {
                pos += road.GetComponent<Tile>().GetSpawnPosition().position.z;
                GameObject clone = Instantiate(road, new Vector3(pos, 0, 0), Quaternion.identity);
                tiles.Add(clone);
            }
        }
    }
}
