using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour {
    private Transform t;
	
    private Head headScript;

    public Vector3 rotate;

	// Use this for initialization
	void Start ()
    {
        t = GetComponent<Transform>();
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
			Destroy(this.gameObject);
		}
	}
}
