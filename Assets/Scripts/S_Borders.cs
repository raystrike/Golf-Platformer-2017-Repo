using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Borders : MonoBehaviour
{
	public float screenHeight; // written by James Atkins
	public float myHeight; // written by James Atkins

	// Use this for initialization
	void Start ()
    {
		screenHeight = Screen.height; // written by James Atkins
	}
	
	// Update is called once per frame
	void Update () // written by James Atkins
	{
		myHeight = screenHeight / 10;
		this.transform.localScale = new Vector3(1, myHeight, 0); 
	}
}
