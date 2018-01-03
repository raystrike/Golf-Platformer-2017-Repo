using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class S_Ball : MonoBehaviour
{

    public float thrust;
    public float fallOffMultiplier;
	public float lastY; // james input
    public Rigidbody2D rb;
	// public Collider2D C; // James input
	public Vector2 velocity;
    public bool MidShot = false;
    public bool Clubswitcher;
	// public bool isBounced; // james input

    public GameObject ClubIcon;
    public Sprite Putter;
    public Sprite Club;

    public float Offset = 90f;

	public int shotCount;

	public bool isDead = false;
	public bool levelComplete;

	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();

		//C = GetComponent<Collider2D>(); // James input
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Adds Force
        //rb.AddForce(transform.up * thrust);
        //rb.velocity = thrust * transform.up;
		velocity = rb.velocity;


        if (MidShot == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (MidShot == true)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        //PC & Mobile Controls by Ray Sloan
        //PC Controls
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            //Rotate Ball in direction of mouse pointer
            Vector3 differance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            differance.Normalize();
            float rotation_z = Mathf.Atan2(differance.y, differance.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + Offset);

            //Mouse Click launches ball
            if (Input.GetMouseButtonDown(0) && MidShot == false)
            {
                rb.velocity = thrust * transform.up;
                MidShot = true;
                shotCount++;
            }

        }
        //Mobile Controls
        else if (Application.platform == RuntimePlatform.Android)
        {

            //Touch Release launches ball
            if ( MidShot == false)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    //Rotate Ball in direction of touch position
                    var touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.nearClipPlane));
                    Quaternion rot = Quaternion.LookRotation(transform.position - touchPosition, Vector3.forward);
                    transform.rotation = rot;

                    transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);


                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    rb.velocity = thrust * transform.up;
                    MidShot = true;
                    shotCount++;
                }

            }

        }

        //Club Switching By Ray Sloan
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Clubswitcher == false)//Switch to Putter
            {
                thrust = 5;
                print("Putter Selected");
                ClubIcon.GetComponent<Image>().sprite = Putter;
                Clubswitcher = true;
            }
            else if (Clubswitcher == true)//Switch to Driver
            {
                thrust = 15;
                print("Driver Selected");
                ClubIcon.GetComponent<Image>().sprite = Club;
                Clubswitcher = false;
            }
        }

        if (rb.velocity == new Vector2(0, 0))
		{
			MidShot = false;
		}

		// check for collision with bottom border and if colliding then game over 

	}

	void FixedUpdate ()
	{
		if (lastY > transform.position.y) 
		{
			gameObject.layer = 0;
		}
		else
		{
			lastY = transform.position.y;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
        //Slower By Ray Sloan
		if (other.tag == "Slower") 
		{
			rb.velocity = Vector3.zero;
		}

		if (other.tag == "Magma")
		{
			isDead = true;
		}

		if (other.tag == "Tramp") // outcome of of ball colliding with "Tramp" prefab, tagged as "Tramp" 
		{

			// C.enabled = false; // turns off colission of the ball.

			gameObject.layer = 9; // changes to layer 9, layer "ball".

			rb.AddForce(new Vector2(0,1000)); // vertical velosity

			lastY = transform.position.y; // getting posistion of y.

			// isBounced = true; 
		}
		if (other.tag == "PortIN") 
		{
			
		}

		if (other.tag == "Hole")
		{
			levelComplete = true;
		}

	}
}
