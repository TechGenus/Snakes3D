using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHead : MonoBehaviour {

    private Transform t;
    private Vector3 nextPos;

    public GameObject head;  // this is declared as soon as the object spawns in head script
    private Transform hT;

	// Use this for initialization
	void Start ()
    {
        t = GetComponent<Transform>();
        hT = head.GetComponent<Transform>();
        nextPos = t.position;
	}
	
	void FixedUpdate () {
		try {
			Vector3 distance = hT.position - t.position;
			t.position = nextPos;
			nextPos = new Vector3(hT.position.x - distance.x / 1.2f, t.position.y, hT.position.z - distance.z / 1.2f);
			// Physics.IgnoreCollision(head.GetComponent<Collider>(), GetComponent<Collider>());
		}
		catch (MissingReferenceException) {
			Destroy(this.gameObject);
			Debug.Log("MissingReferenceException Handled");
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.tag != "Ground") {
			Debug.Log(collision.gameObject.tag);
		}
    }

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "PickUpItem") {
			Destroy(this.gameObject);
		}
	}
}
