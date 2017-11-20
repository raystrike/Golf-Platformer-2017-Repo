using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Camera : MonoBehaviour {

    public GameObject BallObject;
    public float CamDistance = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(0, BallObject.transform.position.y, -1);
	}
}
