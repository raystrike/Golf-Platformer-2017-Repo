using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_ShotCount : MonoBehaviour
{

	public int currentShots;
	public Text shotCountText;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentShots = GameObject.Find ("Ball").GetComponent<S_Ball> ().shotCount;

		shotCountText.text = ("Shots: " + currentShots);
	}
}
