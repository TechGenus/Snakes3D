using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {

	public string horizontalAxis;
	public string verticalAxis;

    public int speedX;
    private int speedZ;

    public float delay;
    public GameObject currTail;
    public GameObject body;

    private float posX;
    private const float POSY = 0.5f;
    private float posZ;

    private int xAxis = 1;
    private int zAxis;
    private bool movingHorizontal = true;

    public GameObject directionLight;
    private Transform dLT; // directional light transform

    private Transform t;

	// Use this for initialization
	void Start ()
    {
        t = GetComponent<Transform>();
        dLT = directionLight.GetComponent<Transform>();

		posX = t.position.x;
		posZ = t.position.z;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetAxis(horizontalAxis) == 1 || Input.GetAxis(horizontalAxis) == -1)
        {
            xAxis = (int)Input.GetAxis(horizontalAxis);
            movingHorizontal = true;
        }
        else if (Input.GetAxis(verticalAxis) == 1 || Input.GetAxis(verticalAxis) == -1)
        {
            zAxis = (int)Input.GetAxis(verticalAxis);
            movingHorizontal = false;
        }

        if (movingHorizontal)
        {
            speedX = Mathf.Abs(speedX) * xAxis;
			posX += (speedX / delay);
		}
        else
        {
            speedZ = Mathf.Abs(speedX) * zAxis;
			posZ += speedZ / delay;
		}

        if (Input.GetKey(KeyCode.Space))
        {
            AddNewTail();
        }

        t.position = new Vector3(posX, POSY, posZ);
	}

    public void AddNewTail()
    {
		currTail.tag = "Body";

        GameObject newTail = Instantiate(body, currTail.transform.position, Quaternion.identity);
        newTail.transform.parent = gameObject.transform.parent;
		newTail.GetComponent<FollowHead>().head = currTail;

		currTail = newTail;
    }

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag != "Ground" && collision.gameObject.tag != "PickUpItem") {
			Destroy(this.gameObject);
		}
	}
}
