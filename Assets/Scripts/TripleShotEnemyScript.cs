using UnityEngine;
using System.Collections;

public class TripleShotEnemyScript : GenericCharacter {
				
		Vector3 arrowDirMain, arrowDirLeft, arrowDirRight;
        public int killValue;
        private KillCount killCount;
		
		// Use this for initialization
		void Start () {
            GameObject killCountObject = GameObject.FindWithTag("KillCount");
            if (killCountObject != null)
            {
                killCount = killCountObject.GetComponent<KillCount>();
            }

			theta = new Vector3(0, 0, Random.value*360);
			arrowDirMain = new Vector3 (Mathf.Cos(theta.z * Mathf.PI / 180), Mathf.Sin(theta.z * Mathf.PI / 180));
			arrowDirLeft = new Vector3 (Mathf.Cos((theta.z + 30) * Mathf.PI / 180), Mathf.Sin(theta.z * Mathf.PI / 180));
			arrowDirRight = new Vector3 (Mathf.Cos((theta.z - 30) * Mathf.PI / 180), Mathf.Sin (theta.z * Mathf.PI / 180));
			transform.Rotate(theta);
		}
		
		// Update is called once per frame
		void Update () {
			currentTime += Time.deltaTime;
			if (currentTime >= fireRate) {
				GameObject centerarrow = ObjectPool.instance.GetObjectForType("BasicProjectile", false);
				GameObject leftarrow = ObjectPool.instance.GetObjectForType("BasicProjectile", false);
				GameObject rightarrow = ObjectPool.instance.GetObjectForType("BasicProjectile", false);
				centerarrow.rigidbody2D.velocity = arrowDirMain * arrowVelocity;
				leftarrow.rigidbody2D.velocity = arrowDirLeft * arrowVelocity;
				rightarrow.rigidbody2D.velocity = arrowDirRight * arrowVelocity;
				centerarrow.tag = "EnemyArrow";
				leftarrow.tag = "EnemyArrow";
				rightarrow.tag = "EnemyArrow";
				currentTime = 0;
			}
		}
		
		void OnColliderEnter2D(Collider col) {
			health--;
			RePool(col.gameObject);
            killCount.AddKills(killValue);
		}
	}