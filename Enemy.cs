using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private float speed = 6f;
    private GameObject[] sites;
    public GameObject explosion;
    private bool dead = false;
    private int health = 1;
    private AudioSource source;
    public AudioClip explosionSound, deathSound;
    private bool deathClipPlayed = false;

	// Use this for initialization
	void Awake () {
        sites = GameObject.FindGameObjectsWithTag("Sites");
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!dead)
        {
            Move();
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Marker")
        {
            transform.LookAt(sites[Random.Range(1,4)].transform);
        } else if (other.tag == "Sites")
        {
            //Vector3 location = other.gameObject.transform.position;
            source.PlayOneShot(explosionSound);
            Vector3 location = transform.position;
            Instantiate(explosion, location, Quaternion.identity);
            Death(true);
        }
        else if (other.tag == "Player")
        {
            source.PlayOneShot(explosionSound);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Death(true);
            other.gameObject.GetComponent<PlayerMovement>().Death();
        } else if (other.tag == "Bullet")
        {
            if (!deathClipPlayed)
            {
                health--;
                if (health <= 0)
                {
                    source.PlayOneShot(deathSound);
                    deathClipPlayed = true;
                    Death(false);
                }
            }
        }
    }

    void Move ()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    
    void Death (bool explosionWentOff)
    {
        Destroy(GetComponent<BoxCollider>());
        Destroy(GetComponent<BoxCollider>());
        Destroy(GetComponent<Rigidbody>());
        if (explosionWentOff)
        {
            GameObject.FindGameObjectWithTag("GameOverController").GetComponent<GameOverScript>().GameOver();
        }
        dead = true;
        GetComponentInChildren<EnemyAnimator>().DeathAnim();
        Destroy(gameObject, 4f);
    } 
}
