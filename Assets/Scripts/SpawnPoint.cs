using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	
	
	public Transform Enemy;
	private bool EnemyCheck = false;
	private float Timer;
	
	void  Awake (){
		Timer = Time.time + 10;
	}
	void  Start (){
		Timer = Time.time + 10;
	}
	
	void  Update (){
		if (Timer < Time.time && !EnemyCheck) { // check if real time has caught up with timer
			Instantiate(Enemy, transform.position, transform.rotation);
			Timer = Time.time + 5;
			EnemyCheck = true;
		}
	}
}