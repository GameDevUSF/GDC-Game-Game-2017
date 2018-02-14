using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] spawnPoints;

	// Use this for initialization
	void Start ()
    {
        //float random = Random.Range(-10f, 10f);


        foreach (GameObject spawn in spawnPoints)
        {
            Instantiate(enemy, new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1.6f, spawn.transform.position.z), Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

    }
}
