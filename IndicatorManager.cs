using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorManager : MonoBehaviour {
    public GameObject enemyToTrack;
    private Enemy enemyScript;
    private float distanceFromPlayer = 1.2f;
    private GameObject player;
    private float height = 1.20f;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyScript = enemyToTrack.GetComponent<Enemy>();
        Vector3 targetPos = ((enemyToTrack.transform.position - player.transform.position).normalized * .6f) + player.transform.position;
        targetPos.y = height;
        transform.position = targetPos;
    }
	
	// Update is called once per frame
	void Update () {
        if (enemyScript.dead)
        {
            Destroy(gameObject);
        }
        UpdateIndicator();
	}

    void UpdateIndicator ()
    {
        //float xCor = (player.transform.position.x + enemyToTrack.transform.position.x) / 2f;
        //float zCor = (player.transform.position.z + enemyToTrack.transform.position.z) / 2f;

        //Vector3 targetPos = new Vector3(xCor, 0, zCor).normalized * distanceFromPlayer;
        //targetPos.y = height;

        //transform.position = targetPos;

        Vector3 targetPos = ((enemyToTrack.transform.position - player.transform.position).normalized * distanceFromPlayer) + player.transform.position;
        targetPos.y = height;
        //targetPos.z -= .8f;
        transform.position = targetPos;
        //transform.position = Vector3.Lerp(transform.position, targetPos, 2f * Time.deltaTime);
    }
}
