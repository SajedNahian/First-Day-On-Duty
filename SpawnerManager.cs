using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {
    float enemiesPerFiveSeconds = 1;
    float whenToSpawn = 0;
    float whenToIncreaseDifficulty;
    public GameObject[] spawners;
	// Use this for initialization
	void Start () {
        whenToIncreaseDifficulty = Time.time + 60f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > whenToSpawn)
        {
            SpawnWave();
        }
        if (Time.time > whenToIncreaseDifficulty)
        {
            IncreaseDifficulty();
        }
	}

    void SpawnWave ()
    {
        for (int i = 1; i <= enemiesPerFiveSeconds; i++)
        {
            spawners[Random.Range(0, 4)].GetComponent<Spawner>().SpawnCall();
        }
        whenToSpawn = Time.time + 5f;
    }

    void IncreaseDifficulty ()
    {
        enemiesPerFiveSeconds += 1;
        whenToIncreaseDifficulty = Time.time + 60f;
    }
}
