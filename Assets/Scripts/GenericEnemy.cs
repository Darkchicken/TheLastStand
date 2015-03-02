using UnityEngine;
using System.Collections;

public class GenericEnemy : GenericCharacter {



	// Use this for initialization
	void Start () 
    {
		theta = new Vector3(0, 0, Random.value*360);
		arrowDir = new Vector3 (Mathf.Cos(theta.z * Mathf.PI / 180), Mathf.Sin(theta.z * Mathf.PI / 180));
		transform.Rotate(theta);

        if (projectilePool == null)
            projectilePool = new ObjectPool(arrowPrefab, false, 16);
	}
	
	// Update is called once per frame
	void Update () 
    {
		currentTime += Time.deltaTime;
		if (currentTime >= fireRate) 
        {
			ProjectileUpDate();
			currentTime = 0;
			//All the arrow prefab needs is a rigidBody2D with everything 0'd out.
			//The arrow will only have to time out and kill itself.
            
		}
	}


	
	public override void OnColliderEnter2D(Collider col) 
    {
        if (!col.tag.Equals("Enemy")) //Incase of non hero hits. 
            // Messy, there will be an internal Action to handle objects going back to the pool OnDisable
            DestroyProjectile(col.gameObject);
	}

   
}
