using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_ShotCount : MonoBehaviour
{

	public int currentShots; // written by James Atkins
    public int currentScore;
	public Text shotCountText; // written by James Atkins
    public Text scoreText;

	public S_Database database;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        //Score calculator (By Ray Sloan)
		currentShots = GameObject.Find ("Ball").GetComponent<S_Ball> ().shotCount; // written by James Atkins
        currentScore = 1000 - (currentShots * 35);
        if (currentScore <= 0)
        {
            currentScore = 0;
        }

		database.Shotcount = currentShots;
		database.Scorecount = currentScore;
       

        scoreText.text = ("Score: " + currentScore);
		shotCountText.text = ("Shots: " + currentShots); // written by James Atkins
	}
}
