using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
        //GetComponent<Rigidbody>().AddForce(new Vector3(0, 2000, 0));
        Destroy(gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(new Vector3(1f, 0, 0) * 100 * Time.deltaTime);
        Vector3 temp = transform.position;
        temp.y = 1.957771f;
        transform.position = temp;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);    
    }
}
