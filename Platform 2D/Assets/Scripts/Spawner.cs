using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectSpawn;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 5, 5);
    }

    void Spawn(){
        int randIndex = (int)Random.Range(0,objectSpawn.Length);
        Instantiate(objectSpawn[randIndex], transform.position, Quaternion.identity);
    }
}
