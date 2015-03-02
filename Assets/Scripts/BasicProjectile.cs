using UnityEngine;
using System.Collections;

public class BasicProjectile : MonoBehaviour, IPoolableObject 
{
    public GameObject gameObject
    {
        get
        {
            return this.transform.gameObject;
        }
    }

    private double timeSpawned;
    private double selfDestructTime;
    private double currentTime;

    private GenericCharacter firingEntity;

	// Use this for initialization
	void Start () 
    {
        selfDestructTime = 3.0f;
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        currentTime += Time.deltaTime;
        if (currentTime + timeSpawned >= timeSpawned + selfDestructTime)
        {
            firingEntity.DestroyProjectile(this.gameObject);
        }
	}

    public void SpawnArrow(double time, GenericCharacter entity)
    {
        timeSpawned = time;
        currentTime = 0f;

        firingEntity = entity;
    }
}
