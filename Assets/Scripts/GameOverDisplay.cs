using UnityEngine;
using System.Collections;

public class GameOverDisplay : MonoBehaviour {
	// Test comment
	// Use this for initialization
	public void OnClickRetry()
	{
		Application.LoadLevel("BasicLevel");
		//needs to look @ PlayerPrefs and load where player died last
	}
	public void OnClickQuit()
	{
		Application.Quit ();
	}
	public void onClickSelect()
	{
		Application.LoadLevel ("LevelSelect");
	}
}
