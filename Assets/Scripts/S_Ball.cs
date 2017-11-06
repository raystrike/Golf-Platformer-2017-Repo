using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Ball : MonoBehaviour {

    public float thrust;
    public float fallOffMultiplier;
    public Rigidbody2D rb;
	public Vector2 velocity;
    public bool MidShot = false;

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

        var mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;

        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);

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
        }

		if (rb.velocity == new Vector2(0, 0))
		{
			MidShot = false;
		}
	}
}
