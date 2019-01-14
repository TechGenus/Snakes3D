using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour {
	public GameObject pickUpPrefab;
	public int numOfPickUps = 6;
	[HideInInspector] public int numOfPickUpsAlive;

	// Use this for initialization
	void Start () {
		InstantiatePickUps();
	}
	
	// Update is called once per frame
	void Update () {
		if (numOfPickUpsAlive <= 0) {
			InstantiatePickUps();
		}
	}

	void InstantiatePickUps() {
		for (int i = 0; i < numOfPickUps; i++) {
			Instantiate(pickUpPrefab, new Vector3(Random.Range(-13.5f, 13.5f), 0.75f, Random.Range(-12f, 12f)), Quaternion.identity);
		}
		numOfPickUpsAlive = numOfPickUps;
	}
}
