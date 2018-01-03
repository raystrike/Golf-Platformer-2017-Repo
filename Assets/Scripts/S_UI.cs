using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class S_UI : MonoBehaviour
{
	public GameObject startScreen;
	public GameObject levelSelectScreen;
	public GameObject leaderboardsScreen;
	public GameObject creditsScreen;

	public GameObject HUD;
	public GameObject ball;
	public GameObject borders;

	public GameObject grassLevel;
	public GameObject volcanoLevel;
	public GameObject spaceLevel;

	string currentLevel;

	public S_Database database;

	public GameObject ScoreboardText;
	public GameObject Scoreboard;

	public GameObject levelCompletePopup;
	public GameObject gameOverPopup;

	private Vector3 ballStartPosition;
	private Vector3 magmaStartPosition;

	public GameObject magma;


	void Awake()
	{
		//Advertisement.Initialize ("1657903");

	}

	// Use this for initialization
	void Start ()
	{
		magmaStartPosition = magma.transform.position;
		ballStartPosition = ball.transform.position;

		startScreen.SetActive (true);
		levelSelectScreen.SetActive (false);
		leaderboardsScreen.SetActive (false);
		creditsScreen.SetActive (false);

		HUD.SetActive (false);
		ball.SetActive (false);
		borders.SetActive (false);

		grassLevel.SetActive (false);
		volcanoLevel.SetActive (false);
		spaceLevel.SetActive (false);

		levelCompletePopup.SetActive (false);
		gameOverPopup.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		// check if ball is dead
		if (ball.GetComponent<S_Ball> ().isDead == true)
		{
			// if player is dead
			ShowGameOverPopup();
		}

		if (ball.GetComponent<S_Ball> ().levelComplete == true)
		{
			ShowLevelCompletePopup ();
		}
		database.Level = currentLevel;
	}

	//Takes string collected in "S_Database" and splits it into an array which is then printed in a grid table
	public void PrintScoreboard (string URLOutput)
	{
		Scoreboard = GameObject.FindWithTag ("ScoreTable").gameObject;

		string[] array = URLOutput.Split ('\t', '\n');

		for(int i = 0; i < array.Length; i++)
		{
            GameObject _textBox = Instantiate(ScoreboardText, transform.position, transform.rotation);
            _textBox.transform.parent = Scoreboard.transform;
			_textBox.GetComponent<Text> ().text = array [i];
        }
			
	}

	public void LevelSelectButton()
	{
		
	//	Debug.Log ();

		startScreen.SetActive (false);
		levelSelectScreen.SetActive (true);
		leaderboardsScreen.SetActive (false);
		creditsScreen.SetActive (false);

		HUD.SetActive (false);
		ball.SetActive (false);
		borders.SetActive (false);

		grassLevel.SetActive (false);
		volcanoLevel.SetActive (false);
		spaceLevel.SetActive (false);

		levelCompletePopup.SetActive (false);
		gameOverPopup.SetActive (false);
	}

	public void LeaderboardsButton()
	{
		startScreen.SetActive (false);
		levelSelectScreen.SetActive (false);
		leaderboardsScreen.SetActive (true);
		creditsScreen.SetActive (false);

		HUD.SetActive (false);
		ball.SetActive (false);
		borders.SetActive (false);

		grassLevel.SetActive (false);
		volcanoLevel.SetActive (false);
		spaceLevel.SetActive (false);

		levelCompletePopup.SetActive (false);
		gameOverPopup.SetActive (false);
	}

	public void CreditsButton()
	{
		startScreen.SetActive (false);
		levelSelectScreen.SetActive (false);
		leaderboardsScreen.SetActive (false);
		creditsScreen.SetActive (true);

		HUD.SetActive (false);
		ball.SetActive (false);
		borders.SetActive (false);

		grassLevel.SetActive (false);
		volcanoLevel.SetActive (false);
		spaceLevel.SetActive (false);

		levelCompletePopup.SetActive (false);
		gameOverPopup.SetActive (false);
	}

	public void ReturnButton()
	{
		startScreen.SetActive (true);
		levelSelectScreen.SetActive (false);
		leaderboardsScreen.SetActive (false);
		creditsScreen.SetActive (false);

		HUD.SetActive (false);
		ball.SetActive (false);
		borders.SetActive (false);

		grassLevel.SetActive (false);
		volcanoLevel.SetActive (false);
		spaceLevel.SetActive (false);

		levelCompletePopup.SetActive (false);
		gameOverPopup.SetActive (false);
	}

	public void GrassLevel1Button()
	{
		startScreen.SetActive (false);
		levelSelectScreen.SetActive (false);
		leaderboardsScreen.SetActive (false);
		creditsScreen.SetActive (false);

		HUD.SetActive (true);
		ball.SetActive (true);
		borders.SetActive (true);

		grassLevel.SetActive (true);
		volcanoLevel.SetActive (false);
		spaceLevel.SetActive (false);

		levelCompletePopup.SetActive (false);
		gameOverPopup.SetActive (false);

		currentLevel = "GrassLevel";
	}

	public void VolcanoLevel1Button()
	{
		startScreen.SetActive (false);
		levelSelectScreen.SetActive (false);
		leaderboardsScreen.SetActive (false);
		creditsScreen.SetActive (false);

		HUD.SetActive (true);
		ball.SetActive (true);
		borders.SetActive (true);

		grassLevel.SetActive (false);
		volcanoLevel.SetActive (true);
		spaceLevel.SetActive (false);

		levelCompletePopup.SetActive (false);
		gameOverPopup.SetActive (false);

		currentLevel = "VolcanoLevel";
	}

	public void SpaceLevel1Button()
	{
		startScreen.SetActive (false);
		levelSelectScreen.SetActive (false);
		leaderboardsScreen.SetActive (false);
		creditsScreen.SetActive (false);

		HUD.SetActive (true);
		ball.SetActive (true);
		borders.SetActive (true);

		grassLevel.SetActive (false);
		volcanoLevel.SetActive (false);
		spaceLevel.SetActive (true);

		levelCompletePopup.SetActive (false);
		gameOverPopup.SetActive (false);

		currentLevel = "SpaceLevel";
	}

	void ShowGameOverPopup()
	{
		ShowAdvert ();

		Time.timeScale = 0.0f;

		HUD.SetActive (false);

		levelCompletePopup.SetActive (false);
		gameOverPopup.SetActive (true);
	}

	public void ReplayLevelButton()
	{
		Time.timeScale = 1.0f;
		ball.GetComponent<S_Ball> ().isDead = false;

		// if grass level
		// reset ball and camera to original position
		if (currentLevel == "GrassLevel")
		{
			GrassLevel1Button ();
			ResetBallPosition ();
		}


		// if volcano level
		// reset ball, camera and magma to original position
		if (currentLevel == "VolcanoLevel")
		{
			VolcanoLevel1Button ();
			ResetMagmaPosition ();
			ResetBallPosition ();
		}

		// if space level
		// reset ball, camera and O2 tanks to original position
		if (currentLevel == "SpaceLevel")
		{
			SpaceLevel1Button ();
			ResetBallPosition ();
			//ResetO2Position ();
		}
	}

	void ResetBallPosition()
	{
		ball.transform.position = ballStartPosition;
	}

	void ResetMagmaPosition()
	{
		magma.transform.position = magmaStartPosition;
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

	public void ExitToMain()
	{
		Invoke ("Start", 0.1f);
	}

	public void ShowLevelCompletePopup()
	{
		//ShowAdvert ();

		Time.timeScale = 0.0f;

		HUD.SetActive (false);

		levelCompletePopup.SetActive (true);
		gameOverPopup.SetActive (false);
	}

	void ShowAdvert()
	{
		if (Advertisement.IsReady() == true)
		{
			Advertisement.Show ("video");
		}
	}
}
