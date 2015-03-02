

using UnityEngine;
using System.Collections;


	public class GenericCharacter: MonoBehaviour{
		public double health, fireRate;
		public float arrowVelocity;
		public GameObject arrowPrefab;
		public double currentTime;
		public Vector3 theta, arrowDir;
	// Shared projectile object pool for all generic characters
		public static ObjectPool projectilePool;
	
		public GenericCharacter (){

		}
	public virtual void ProjectileUpDate(){
		GameObject arrow = projectilePool.PullObject();
		arrow.transform.position = transform.position;
		arrow.transform.rotation = transform.rotation;
		arrow.GetComponent<BasicProjectile>().SpawnArrow(Time.time,this);
		arrow.SetActive(true);
		arrow.rigidbody2D.velocity = arrowDir * arrowVelocity;
	}
	public virtual void DestroyProjectile(GameObject objToDestroy){
		projectilePool.PushObject(objToDestroy.gameObject.GetComponent(typeof(IPoolableObject)) as IPoolableObject);
	}
		
	public virtual void OnColliderEnter2D(Collider col) {}
	

}

