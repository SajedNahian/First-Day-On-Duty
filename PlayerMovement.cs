using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeekGame.Input;

public class PlayerMovement : MonoBehaviour {
    public float speed = 8f;
    private Animator anim;
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private float shootDelay = 1f;
    private float whenCanShoot;
    private bool dead = false;
    public static bool gameOver = false;
    //private bool resetJoystick = true;
    //private float curPosRotation = 0.0f;
    private bool rightButton, leftButton;
    private float rotationForButtons = 90f;
    private AudioSource source;
    public AudioClip deathSound, shootSound;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        gameOver = false;
	}

    void Start()
    {
        whenCanShoot = Time.time;
    }
    void Update () {
        if (!dead && !gameOver)
        {
            //LeftJoystick();
            //RightJoystick();
            MoveForward();
        }
        if (gameOver && !dead)
        { 
            anim.SetFloat("Speed_f", 0f);

        }
    }

    //void LeftJoystick ()
    //{
    //    float joystickH = JoystickMove.instance.H / 75f;
    //    float joystickV = JoystickMove.instance.V / 75f;
    //    float val = Vector2.Distance(new Vector2(joystickH, joystickV), Vector2.zero);
    //    //print(val);
    //    if (val > .95f)
    //    {
    //        anim.SetFloat("Speed_f", .3f);
    //        transform.Translate(val / 2f * speed * Time.deltaTime * Vector3.forward);
    //    } else
    //    {
    //        anim.SetFloat("Speed_f", 0f);
    //    }
    //}

    //void RightJoystick ()
    //{
    //    float joystickH = JoystickMove.instance.H / 75f;
    //    float joystickV = JoystickMove.instance.V / 75f;
    //    if (joystickV + joystickH != 0)
    //    {
    //        Shoot();
    //        float val = Vector2.Distance(new Vector2(joystickH, joystickV), Vector2.zero);
    //        float angle;
    //        if (val > .95f)
    //        {
    //            angle = Mathf.Atan2(joystickH, joystickV) * Mathf.Rad2Deg;
    //        } else
    //        {
    //            angle = 0f;
    //            curPosRotation = transform.eulerAngles.y;
    //        }
            
    //        Vector3 temp = transform.eulerAngles;
    //        temp.y = curPosRotation + angle;
    //        transform.eulerAngles = temp;

    //    } else
    //    {
    //        curPosRotation = transform.eulerAngles.y;
    //    }

    //    //float joystickh1 = joystickrotate.instance.h / 75f;
    //    //float joystickv1 = joystickrotate.instance.v / 75f;
    //    //if (joystickv1 + joystickh1 != 0)
    //    //{
    //    //    shoot();
    //    //}
    //}


    void MoveForward ()
    {
        anim.SetFloat("Speed_f", .3f);
        //Shoot();
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //if ((leftButton && rightButton) || (!leftButton && !rightButton))
        //{
        //    return;
        //} else if (leftButton)
        //{
        //    Vector3 curRot = transform.eulerAngles;
        //    curRot.y -= rotationForButtons * Time.deltaTime;
        //    transform.eulerAngles = curRot;
        //} else
        //{
        //    Vector3 curRot = transform.eulerAngles;
        //    curRot.y += rotationForButtons * Time.deltaTime;
        //    transform.eulerAngles = curRot;
        //}
    }

    //public void TurnLeft ()
    //{
    //    Vector3 curRot = transform.eulerAngles;
    //    curRot.y -= 15f * Time.deltaTime;
    //    transform.eulerAngles = curRot;
    //}

    //public void TurnRight ()
    //{
    //    Vector3 curRot = transform.eulerAngles;
    //    curRot.y += 15f * Time.deltaTime;
    //    transform.eulerAngles = curRot;
    //}

    public void LeftButtonPointerDown ()
    {
        leftButton = true;
    }

    public void LeftButtonPointerUp ()
    {
        leftButton = false;
    }

    public void RightButtonPointerDown ()
    {
        rightButton = true;
    }

    public void RightButtonPointerUp ()
    {
        rightButton = false;
    }

    void Shoot ()
    {
        if (Time.time > whenCanShoot)
        {
            source.PlayOneShot(shootSound);
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(shootingPoint.forward * 2000);
            whenCanShoot = Time.time + shootDelay;
        }
       
    }

    public void Death ()
    {
        //AdManager.UpdateDeath();
        source.PlayOneShot(deathSound);
        anim.SetBool("Death_b", true);
        dead = true;
    }

    public void SwipeMovement (Vector2 swipe)
    {
        Vector3 curRot = transform.eulerAngles;
        curRot.y += swipe.x  * Time.deltaTime * 10f;
        transform.eulerAngles = curRot; 
    }

    public void SwipeShoot ()
    {
        whenCanShoot = Time.time + .1f;
        source.PlayOneShot(shootSound);
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(shootingPoint.forward * 3500);
        whenCanShoot = Time.time + shootDelay;
    }
    
}
