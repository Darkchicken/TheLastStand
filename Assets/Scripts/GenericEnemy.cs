using UnityEngine;
using System.Collections;

public class GenericEnemy : GenericCharacter {
	// Use this for initialization
	public Transform sightStart, sightEnd;
	public bool playerInSight = false;
	public int killValue;
	private KillCount killCount;

	void Start () 
	{
		GameObject killCountObject = GameObject.FindWithTag ("KillCount");
		if (killCountObject != null)
		{
			killCount = killCountObject.GetComponent <KillCount> ();
		}
		theta = new Vector3(0, 0, 0);//z value controls rotation, 0 is facing to the right
		//transform.Rotate(theta);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Raycast ();
		currentTime += Time.deltaTime;
		if (currentTime >= fireRate && playerInSight) 
		{
			fireArrow("EnemyArrow");
			currentTime = 0;
		}

		if (health <= 0) 
		{
			health = 1;
			RePool(this.gameObject);
		}
	}

	public void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.tag == "EnemyArrow") return;
		if (col.gameObject.tag.Equals("PlayerArrow")) 
		{
			health--;
			RePool(col.gameObject);
			killCount.AddKills(killValue);
		}
	}

	public void Raycast()
	{
		//draws enemy line of sight in debug scene view
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.red);
		//makes player in sight true when player crosses line of sight. 
		//layermask makes the line of sight only trigger on objects contained on the "Player" layer
		//only the player itself should be contained on that layer
		playerInSight = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
	}
}