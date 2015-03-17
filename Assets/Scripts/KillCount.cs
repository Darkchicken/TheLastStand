using UnityEngine;
using System.Collections;

public class KillCount : MonoBehaviour {

	public GUIText killText;
	private int kills;

	// Use this for initialization
	void Start () {
		kills = 0;
		UpdateKills ();
	}

	public void AddKills (int newKills)
	{
		kills += newKills;
		UpdateKills ();
	}

	void UpdateKills()
	{
		killText.text = "Kills: " + kills;
	}
}
