using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerManager : MonoBehaviour {
    float enemiesPerFiveSeconds = 1;
    float whenToSpawn = 0;
    float whenToIncreaseDifficulty, whenToIncreaseWaveText;
    public GameObject[] spawners;
    public Text waveText;
    private float wave = 1;
    // Use this for initialization
    void Awake()
    {
        UpdateWaveText(0);
    }

    void Start () {
        whenToIncreaseDifficulty = Time.time + 60f;
        whenToIncreaseWaveText = Time.time + 30f;
    }
	
	// Update is called once per frame
	void Update () {
        if (!PlayerMovement.gameOver)
        {
            if (Time.time > whenToSpawn)
            {
                SpawnWave();
            }
            if (Time.time > whenToIncreaseDifficulty)
            {
                IncreaseDifficulty();
            }
            if (Time.time > whenToIncreaseWaveText)
            {
                UpdateWaveText(1);
                whenToIncreaseWaveText = Time.time + 30f;
            }
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

    void UpdateWaveText (int waveIncrease)
    {
        wave += waveIncrease;
        waveText.text = "Wave: " + wave;
    }
}
