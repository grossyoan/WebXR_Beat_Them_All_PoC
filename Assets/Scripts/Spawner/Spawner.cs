using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] ObjectPrefab;
    public float SpawnInterval = 10;


    private float Timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= SpawnInterval)
        {
            Spawn();
            Timer = 0;
        }
    }
    
    public void Spawn()
    {
        int randomNb = Random.Range(0, 10);

        GameObject copy;
        copy = Instantiate(ObjectPrefab[0], transform);
        
    }
}
