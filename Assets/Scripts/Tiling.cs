using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiling : MonoBehaviour {
    public GameObject player;
    private Transform playerT;

    public GameObject spawnedTerrain;
    private Terrain terrain;
    private Vector3 terrainSize;

    public GameObject prefTerrain;

    private float distanceOfPlayer;
    private Vector3 directionOfPlayer;
    private float centerOfTerrainX;
    private float centerOfTerrainZ;

    // Use this for initialization
    void Start () {
        playerT = player.GetComponent<Transform>();
        terrain = spawnedTerrain.GetComponent<Terrain>();
        terrainSize = terrain.terrainData.size;
        centerOfTerrainX = spawnedTerrain.transform.position.x + terrainSize.x / 2;
        centerOfTerrainZ = spawnedTerrain.transform.position.z + terrainSize.z / 2;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 centerOfTerrain = new Vector3(centerOfTerrainX, player.transform.position.y, centerOfTerrainZ);
        distanceOfPlayer = Vector3.Dot(player.transform.position, centerOfTerrain);
        directionOfPlayer = Vector3.Cross(player.transform.position, centerOfTerrain).normalized;

        Debug.Log(terrainSize.x);

        if (distanceOfPlayer > (terrainSize.x + terrainSize.z) / 4)
        {
            // Todo: create something to spawn new tiles
            float posX = (spawnedTerrain.transform.position.x + terrainSize.x) * (int) directionOfPlayer.x;
            float posZ = (spawnedTerrain.transform.position.z + terrainSize.z) * (int) directionOfPlayer.z;
            if (posZ != 0 && posX != 0)
            {
                spawn3(directionOfPlayer);
            }
            Instantiate(prefTerrain, new Vector3(posX, 0, posZ), Quaternion.identity);
        }
    }

    void spawn3(Vector3 directionOfPlayer)
    {

    }
}