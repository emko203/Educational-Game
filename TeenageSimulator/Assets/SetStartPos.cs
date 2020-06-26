using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartPos : MonoBehaviour
{
    [SerializeField]
    Transform StartPosToSpawnAt;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = StartPosToSpawnAt.position;
    }
}
