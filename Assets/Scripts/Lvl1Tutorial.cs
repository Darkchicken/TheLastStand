using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lvl1Tutorial : MonoBehaviour {
	
	public GameObject tutorialSpawn;
	public Text tutorialText, tutorialText2, tutorialText3, tutorialText4;
	public bool tutEnemyDead = false;
	public bool tutArrowCaught = false;
	public bool displayText2 = true;
	public bool displayText3 = true;
    public bool displayText4 = true;
    //these are the spawn points in the level
    public GameObject s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12;
	//tutorialSpawn.GetComponent<SpawnPoint>().EnemyCheck == false
	void Start () 
	{
		if (Application.isMobilePlatform) 
		{
			tutorialText.text = "Drag Thumb On Left Side Of Screen To Move Player. Single Tap Right Side Of Screen To Catch Arrows In Cone. This Protects You And Refills Your Ammo.";
			tutorialText2.text = "Drag Thumb On Right Side Of Screen To Aim. Quickly Double-Tap Right Side To Fire Arrows In The Direction You Are Facing";
		} 
		Invoke ("DisplayCatchText", 4.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(tutArrowCaught == true && displayText2 == true)
		{
			tutorialText.gameObject.SetActive(false);
			Invoke ("DisplayFireText", 0.1f);
			displayText2 = false;

		}
		if(tutEnemyDead == true && displayText3 == true)
		{


			tutorialText2.gameObject.SetActive(false);
			Invoke ("DisplayDefendText", 1.0f);
			displayText3 = false;
			Invoke("RemoveText", 3.0f);
			s1.SetActive(true);
			s2.SetActive(true);
			s3.SetActive(true);
			s4.SetActive(true);
			s5.SetActive(true);
			s6.SetActive(true);
			s7.SetActive(true);
			s8.SetActive(true);
			s9.SetActive(true);
			s10.SetActive(true);
			s11.SetActive(true);
			s12.SetActive(true);
		}
        if (displayText4 == true)
        {
            Invoke("DisplayPauseText", 1.0f);
            displayText4 = false;
            Invoke("RemovePauseText", 3.0f);
        }


    }
    void DisplayCatchText()
	{
		tutorialText.gameObject.SetActive(true);
	}
	void DisplayFireText()
	{
		//tutArrowCaught = false;
		tutorialText2.gameObject.SetActive(true);
	}
	void DisplayDefendText()
	{
		//tutEnemyDead = false;
		tutorialText3.gameObject.SetActive(true);
	}
    void DisplayPauseText()
    {
        tutorialText4.gameObject.SetActive(true);
    }
    void RemoveText()
	{
		tutorialText3.gameObject.SetActive(false);
	}
    void RemovePauseText()
    {
        tutorialText4.gameObject.SetActive(false);
    }
}
