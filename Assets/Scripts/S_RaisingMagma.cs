using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RaisingMagma : MonoBehaviour {

    public float MagmaSpeed = 5;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Move Magma Up (By Ray Sloan)
        rb.velocity = MagmaSpeed * transform.up;
    }
}
