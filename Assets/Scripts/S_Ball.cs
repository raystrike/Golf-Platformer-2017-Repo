using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_Ball : MonoBehaviour
{
	/// <summary>
	/// Unless commented otherwise, written by Ray Sloan
	/// </summary>

    public float BarSpeed;
    public float fallOffMultiplier;
    public float PowerTimer;
	public float lastY; // james langford input
    public Rigidbody2D rb;
	// public Collider2D C; // James langford input
	public Vector2 velocity; // written by James Atkins
    public bool MidShot = false;
    public bool ResetRotation;
    public bool PowerTimerActive = true;
    public bool PowerUp = true;
	// public bool isBounced; // james input

    public GameObject PowerBar;
    public GameObject PowerValueText;
    public Sprite Putter;
    public Sprite Club;

    public float Offset = 90f;

	public int shotCount; // written by James Atkins

	public bool isDead = false; // written by James Atkins
	public bool levelComplete; // written by James Atkins

	// Use this for initialization
	void Start () 
    {
		rb = GetComponent<Rigidbody2D>(); // written by James Atkins

		//C = GetComponent<Collider2D>(); // James input
	}
	
	// Update is called once per frame
	void Update () 
    {

		velocity = rb.velocity; // written by James Atkins

        //Shows shot direction and activate reset rotation function (By Ray Sloan)
        if (MidShot == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            PowerTimerActive = true;
            if (ResetRotation == false)
            {
                ResetBallRotation();
            }
        }
        else if (MidShot == true)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            PowerTimerActive = false;
        }

        //Builds and decreses power of shot over time, displays on slider (By Ray Sloan)
        if (PowerTimerActive == true)
        {
            PowerBar.SetActive(true);
            if (PowerUp == true)
            {
                if (PowerTimer < 20)
                {
                    PowerTimer += Time.deltaTime * BarSpeed;
                }
                else
                {
                    PowerUp = false;
                }
            }
            else
            {
                if (PowerTimer > 3)
                {
                    PowerTimer -= Time.deltaTime * BarSpeed;
                }
                else
                {
                    PowerUp = true;
                }
            }

            PowerBar.GetComponent<Slider>().value = PowerTimer;
            PowerValueText.GetComponent<Text>().text = PowerTimer.ToString("F0");
        }
        else
        {
            PowerBar.SetActive(false);
        }


        //Check if ball velocity is zero (stopped) (By James Atkins)
        if (rb.velocity == new Vector2(0, 0))
		{
			MidShot = false;
		}


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

        //PC & Mobile Controls (Eloquently implemented by Ray Sloan)
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
                ResetRotation = false;
                rb.velocity = PowerTimer * transform.up;
                MidShot = true;
				shotCount++; // written by James Atkins
            }



        }
        //Mobile Controls
        else if (Application.platform == RuntimePlatform.Android)
        {
            Touch touch = Input.GetTouch(0);
            int pointerID = touch.fingerId;

            //Touch Release launches ball
            if (Input.touchCount > 0 && MidShot == false)
            {

                if (touch.phase == TouchPhase.Moved)
                {
                    //Rotate Ball in direction of touch position
					var touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - transform.position;
                    touchPosition.Normalize();
                    float rotation_zm = Mathf.Atan2(touchPosition.y, touchPosition.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0f, 0f, rotation_zm + Offset);

                }
                else if (touch.phase == TouchPhase.Ended)
                {
					ResetRotation = false;
                    rb.velocity = PowerTimer * transform.up;
                    MidShot = true;
					shotCount++; // written by James Atkins
                }

            }

        }
    }

	void OnTriggerEnter2D (Collider2D other)
	{
        //Slower (By Ray Sloan)
		if (other.tag == "Slower") 
		{
			rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            //transform.Rotate(Vector3.up);
		}

		if (other.tag == "Magma" || other.tag == "Hazard") // written by James Atkins
		{
			isDead = true;
		}

		// by james langford
		if (other.tag == "Tramp") // outcome of of ball colliding with "Tramp" prefab, tagged as "Tramp" 
		{

			// C.enabled = false; // turns off colission of the ball.

			gameObject.layer = 9; // changes to layer 9, layer "ball".

			rb.AddForce(new Vector2(0,1000)); // vertical velosity

			lastY = transform.position.y; // getting posistion of y.

			// isBounced = true; 
		}

		// by james langford
		if (other.tag == "PortIN") 
		{
			
		}

		if (other.tag == "Hole") // written by James Atkins
		{
			levelComplete = true;
		}

	}

    //Plays collision debry particles (By Ray Sloan)
    void OnCollisionEnter2D(Collision2D collision)
    {
        transform.GetChild(2).GetComponent<ParticleSystem>().Play();
    }

    //Resets ball rotation so shot direction always points up after each shot & Plays ball is ready to shoot particle effect (By Ray Sloan)
    void ResetBallRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        ResetRotation = true;
    }
}
