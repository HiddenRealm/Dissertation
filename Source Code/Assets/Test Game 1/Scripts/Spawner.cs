using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public GameObject bButterfly;
    public GameObject gButterfly;
    public GameObject rButterfly;
    float randX;
    private Vector3 whereToSpawn;
    private Vector3 scale;
    private float spawnRate;
    float NextSpawn = 0.0f;

    private void Start()
    {
        scale = new Vector3(7,7,1);

        if (Application.platform == RuntimePlatform.Android)
        {
            scale = new Vector3(12, 12, 1);
        }

        spawnRate = 0.6f;
    }
		
    void Update () {

        if (Time.time > NextSpawn)
        {
            NextSpawn = Time.time + spawnRate;
            Spawning();
        }
	}

    void Spawning() {
        randX = Random.Range(-18.4f, 18.4f);
        whereToSpawn = new Vector3(randX, transform.position.y, 19);

        int rand = Random.Range(0, 10);

        if (rand >= 5)
        {
            GameObject newObject = Instantiate(bButterfly, whereToSpawn, Quaternion.identity) as GameObject;
            newObject.transform.localScale = scale;
        }
        else if (rand == 4 || rand == 3)
        {
            GameObject newObject = Instantiate(gButterfly, whereToSpawn, Quaternion.identity) as GameObject;
            newObject.transform.localScale = scale;
        }
        else if (rand <= 2)
        {
            GameObject newObject = Instantiate(rButterfly, whereToSpawn, Quaternion.identity) as GameObject;
            newObject.transform.localScale = scale;
        }
    }

    public void SetSpawnRate(float rate)
    {
        spawnRate = rate;
    }

}
