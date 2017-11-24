using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Borders : MonoBehaviour
{
	public float screenHeight;
	public float myHeight;

	// Use this for initialization
	void Start ()
    {
		screenHeight = Screen.height;
	}
	
	// Update is called once per frame
	void Update ()
	{
		myHeight = screenHeight / 10;
		this.transform.localScale = new Vector3(1, myHeight, 0); 
	}
}
