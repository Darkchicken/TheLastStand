using UnityEngine;
using System.Collections;

public class TrackingEnemy : GenericCharacter {
	Vector3 playerPosition, diff;
	float rotation;
    public int killValue;
    private KillCount killCount;

    void Start()
    {
        GameObject killCountObject = GameObject.FindWithTag("KillCount");
        if (killCountObject != null)
        {
            killCount = killCountObject.GetComponent<KillCount>();
        }
    }
	
	
	// Update is called once per frame
	void Update () 
	{
		RotateToPlayer ();
		theta = new Vector3(0, 0, rotation);//z value controls rotation, 0 is facing to the right
		currentTime += Time.deltaTime;
		
		if (currentTime >= fireRate) 
		{
			fireArrow("EnemyArrow");
			currentTime = 0;			
		}
		if (health <= 0) 
		{
			RePool(this.gameObject);
		}
	}
	
	//Rotate to face a player
	private void RotateToPlayer()
	{
		GameObject player = GameObject.Find("Player");
		Transform playerTransform = player.transform;
		// get player position
		playerPosition = playerTransform.position;
		playerPosition = new Vector3(playerPosition.x, playerPosition.y, 0);
		diff = playerPosition - transform.position;
		diff.Normalize();
		rotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rotation);
		
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
	
	
}


