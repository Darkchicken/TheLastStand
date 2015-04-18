﻿using UnityEngine;
using System.Collections;

public class GameOverDisplay : MonoBehaviour {
	// Test comment
	// Use this for initialization
	void Start()
	{
		Debug.Log ( "High Score is: "+PlayerPrefs.GetFloat("High Score"));
	}
	public void OnClickRetry()
	{
		Application.LoadLevel("Level3-Temple");
		//needs to look @ PlayerPrefs and load where player died last
	}
	public void OnClickQuit()
	{
		Application.Quit ();
	}
	public void onClickSelect()
	{
		Application.LoadLevel ("LevelSelectMenu");
	}
	public void onClickStart()
	{
		Application.LoadLevel ("StartMenu");
	}
}


