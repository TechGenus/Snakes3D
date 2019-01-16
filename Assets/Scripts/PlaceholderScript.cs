using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderScript : MonoBehaviour {
    public float spawnDelay;
    private float timeTillSpawn;
    private Transform t;

    public GameObject pickUpPrefab;

	// Use this for initialization
	void Start () {
        timeTillSpawn = Time.time + spawnDelay;
        t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (timeTillSpawn < Time.time)
        {
            Instantiate(pickUpPrefab, new Vector3(t.position.x, 0.75f, t.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Ground")
        {
            t.position = new Vector3(Random.Range(-13.5f, 13.5f), 2.75f, Random.Range(-12f, 12f));
        }
    }
}
