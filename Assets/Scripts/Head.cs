using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Head : MonoBehaviour {

	public string horizontalAxis;
	public string verticalAxis;

    public int speedX;
    private int speedZ;

    public float delay;
    public GameObject currTail;
    public GameObject body;

	public Text winText;
	[TextArea] public string loseTextOutputedToWinText;

    private float posX;
    private const float POSY = 0.5f;
    private float posZ;

    private int xAxis = 1;
    private int zAxis;
    private bool movingHorizontal = true;

    public GameObject directionLight;
    private Transform dLT; // directional light transform

    private Transform t;

	private void Awake() {
		Time.timeScale = 1;
	}

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
        if (Input.GetAxisRaw(horizontalAxis) == 1 || Input.GetAxisRaw(horizontalAxis) == -1)
        {
            xAxis = (int)Input.GetAxisRaw(horizontalAxis);
            movingHorizontal = true;
        }
        else if (Input.GetAxisRaw(verticalAxis) == 1 || Input.GetAxisRaw(verticalAxis) == -1)
        {
            zAxis = (int)Input.GetAxisRaw(verticalAxis);
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
		try {
			currTail.tag = "Body";
		}
		catch (MissingReferenceException e) {
			currTail = t.parent.transform.GetChild(t.parent.childCount - 1).gameObject;
			currTail.tag = "Body";
			Debug.Log(e);
		}

		GameObject newTail = Instantiate(body, currTail.transform.position, Quaternion.identity);
        //newTail.transform.parent = gameObject.transform.parent;
		newTail.transform.parent = t.parent;
		newTail.GetComponent<FollowHead>().head = currTail;

		currTail = newTail;
    }
	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag != "Ground" && collision.gameObject.tag != "PickUpItem") {
			winText.text = loseTextOutputedToWinText;
			Time.timeScale = 0f;
			Destroy(this.gameObject);
		}
	}
}
