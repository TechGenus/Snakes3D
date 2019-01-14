using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour {
    private Transform t;
	
    private Head headScript;

    public Vector3 rotate;

	private PickUpSpawner pickUpSpawnerScript;

	// Use this for initialization
	void Start ()
    {
        t = GetComponent<Transform>();
		pickUpSpawnerScript = GameObject.Find("PickUp Spawner").GetComponent<PickUpSpawner>();
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        t.Rotate(rotate * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Head") {
			other.gameObject.GetComponent<Head>().AddNewTail();
			pickUpSpawnerScript.numOfPickUpsAlive -= 1;
			Destroy(this.gameObject);
		}
        else if (other.gameObject.tag == "Body"
            || other.gameObject.tag == "Tail"
            || other.gameObject.tag == "Player")
        {
            pickUpSpawnerScript.numOfPickUpsAlive -= 1;
            Destroy(this.gameObject);
        }
	}
}
