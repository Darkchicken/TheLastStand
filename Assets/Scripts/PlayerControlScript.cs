using UnityEngine;
using System.Collections;



public class PlayerControlScript : MonoBehaviour{
	public float walkSpeed = 3.5f; //movement speed of the player


	void Start(){

	}


	void Update(){
		//WASD Controls

		 if (Input.GetKey (KeyCode.D)) {
			transform.position += new Vector3 (walkSpeed * Time.deltaTime, 0.0f, 0.0f);
		} 
		 if (Input.GetKey (KeyCode.A)) {
			transform.position -= new Vector3 (walkSpeed * Time.deltaTime, 0.0f, 0.0f);
		} 
		 if (Input.GetKey (KeyCode.W)) {
			transform.position += new Vector3 (0.0f,walkSpeed * Time.deltaTime, 0.0f);
		} 
		 if (Input.GetKey (KeyCode.S)) {
			transform.position -= new Vector3 (0.0f,walkSpeed * Time.deltaTime, 0.0f);
		}

		//arrow key controls 

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += new Vector3 (walkSpeed * Time.deltaTime, 0.0f, 0.0f);
		} 
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position -= new Vector3 (walkSpeed * Time.deltaTime, 0.0f, 0.0f);
		} 
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += new Vector3 (0.0f,walkSpeed * Time.deltaTime, 0.0f);
		} 
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position -= new Vector3 (0.0f,walkSpeed * Time.deltaTime, 0.0f);
		}
		}
	}
