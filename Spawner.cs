using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject spawnerLocation, enemyPrefab;
    public float angle;
	
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnEnemy ()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnerLocation.transform.position, Quaternion.identity) as GameObject;
        Vector3 temp = enemy.transform.eulerAngles;
        temp.y = angle;
        enemy.transform.eulerAngles = temp;
    }

    public void SpawnCall ()
    {
        SpawnEnemy();
    }
}
