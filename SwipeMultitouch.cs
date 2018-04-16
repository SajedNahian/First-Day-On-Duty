using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMultitouch : MonoBehaviour {
    //private bool swiping = false;
    private Vector2 startingPos, prevPos = Vector2.zero;
    private GameObject player;
    private bool swiping = false;
	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (!PlayerMovement.gameOver)
            MobileTouch();
    }

    void MobileTouch ()
    {
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                swiping = true;
                startingPos = Input.touches[0].position;
                prevPos = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                swiping = false;
                float xDistance =  Mathf.Abs((Input.touches[0].position - startingPos).x);
                startingPos = prevPos = Vector2.zero;
                if (xDistance < 3f)
                {
                    player.GetComponent<PlayerMovement>().SwipeShoot();
                }
            } else
            {
                if (swiping)
                {
                    Vector2 currentSwipe = Input.touches[0].position - prevPos;
                    prevPos = Input.touches[0].position;
                    if (Mathf.Abs(currentSwipe.x) < 90f)
                    {
                        player.GetComponent<PlayerMovement>().SwipeMovement(currentSwipe);
                    }
                    else
                    {
                        if (currentSwipe.x > 0)
                        {
                            Vector3 temp = currentSwipe;
                            temp.x = 90f;
                            player.GetComponent<PlayerMovement>().SwipeMovement(temp);
                        }
                        else
                        {
                            Vector3 temp = currentSwipe;
                            temp.x = -90f;
                            player.GetComponent<PlayerMovement>().SwipeMovement(temp);
                        }
                    }
                }
            }


            // Might wanna use for loop to get input if more than 2 fingers are on the screen.
            if (Input.touches.Length > 1)
            {
                if (Input.touches[1].phase == TouchPhase.Began)
                {
                    player.GetComponent<PlayerMovement>().SwipeShoot();
                }
            }
        }
    }
}
