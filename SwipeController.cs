using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour {
     
    Vector2 firstPressPos;
    Vector2 currentSwipe;
    GameObject player;
    private bool swiping = false;
    private Vector2 prevPos;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }


    void Update() {
        if (!PlayerMovement.gameOver)
            SwipeMethod();
        //print(swiping);
     }

    void SwipeMethod ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(swiping == false)
            {
                swiping = true;
                firstPressPos = Input.mousePosition;
                prevPos = Input.mousePosition;
            } else
            {
                player.GetComponent<PlayerMovement>().SwipeShoot();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            swiping = false;
            float xDistance = Mathf.Abs(((Vector2)Input.mousePosition - firstPressPos).x);
            if (xDistance < 3f)
            {
                player.GetComponent<PlayerMovement>().SwipeShoot();
            } 
        }
        if (swiping)
        {
            currentSwipe = (Vector2)Input.mousePosition - prevPos;
            prevPos = Input.mousePosition;
            player.GetComponent<PlayerMovement>().SwipeMovement(currentSwipe);
        }
    }
 }


