using System.Collections;
using UnityEngine;

public class GenerateRoad : MonoBehaviour
{
    private IEnumerator coroutine;
    public GameObject road;
    public float interval;

    void Start()
    {
        //Instantiate(road, new Vector3(0, 0, 0), Quaternion.identity);
        coroutine = WaitAndInstantiate(interval);
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndInstantiate(float waitTime)
    {
        float pos = 0;
        while (true)
        {          
            yield return new WaitForSeconds(waitTime);
            pos += road.GetComponent<Tile>().GetSpawnPosition().position.z;
            GameObject clone = Instantiate(road, new Vector3(pos, 0, 0), Quaternion.identity);
            Destroy(clone, 10);
            print(pos);
        }
        
    }
}
