using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	// Use this for initialization
	void Start ()
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
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void LevelSelectButton()
	{
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
	}

}
