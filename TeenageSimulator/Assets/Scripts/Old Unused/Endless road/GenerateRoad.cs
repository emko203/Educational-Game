using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateRoad : MonoBehaviour
{
    private IEnumerator coroutine;
    public GameObject road;
    public float interval;
    GameObject clone;
    public List<GameObject> tiles = new List<GameObject>();
    private float pos = 0f;
    void Start()
    {
        initialRoads();
        coroutine = WaitAndInstantiate(interval);
        StartCoroutine(coroutine);
    }

    private void initialRoads() 
    {
        for (int i = 0; i < 3; i++)
        {
            clone = Instantiate(road, new Vector3(pos, 0, 0), Quaternion.identity);
            tiles.Add(clone);
            pos += 50.4f;
        }
        pos -= 50.4f;
    }
  

    private void Update()
    {
        tiles = tiles.Where(item => item != null).ToList();
    }

    private IEnumerator WaitAndInstantiate(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);               
            pos += 50.4f;
            clone = Instantiate(road, new Vector3(pos, 0, 0), Quaternion.identity);
            tiles.Add(clone);
            if (tiles.Count > 5)
            {
                yield return new WaitForSeconds(waitTime);
                Destroy(tiles[0]);
            }
        }
    }
}
