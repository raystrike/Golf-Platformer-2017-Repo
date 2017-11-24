using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class S_Ball : MonoBehaviour {

    public float thrust;
    public float fallOffMultiplier;
    public Rigidbody2D rb;
	public Vector2 velocity;
    public bool MidShot = false;
    public bool Clubswitcher;

    public GameObject ClubIcon;
    public Sprite Putter;
    public Sprite Club;

    public float Offset = 90f;

	public int shotCount;

	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Adds Force
        //rb.AddForce(transform.up * thrust);
        //rb.velocity = thrust * transform.up;
		velocity = rb.velocity;

        Vector3 differance = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        differance.Normalize();
        float rotation_z = Mathf.Atan2(differance.y, differance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + Offset);

        if (MidShot == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (MidShot == true)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && MidShot == false)
        {
            rb.velocity = thrust * transform.up;
            MidShot = true;
			shotCount++;
        }

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

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Slower") 
		{
			rb.velocity = Vector3.zero;
		}
	}
}
