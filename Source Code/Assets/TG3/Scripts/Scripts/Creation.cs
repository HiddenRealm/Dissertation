using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Creation : MonoBehaviour {

    public GameObject Bullseye;
    float randX;
    float randY;
    private Vector3 whereToSpawn;
    private Vector3 scale;
    private float spawnRate;
    float NextSpawn = 0.0f;
    public float timer = 45.0f;
    private float timeLeft;
    public Text tText;
    private bool done;
    private GameObject Info;

    private void Start()
    {
        scale = new Vector3(0, 0, 0);

        spawnRate = 1f;

        timeLeft = timer;
        tText.text = "0";
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        int time = Mathf.RoundToInt(timeLeft);
        tText.text = time.ToString();

        if (Time.time > NextSpawn)
        {
            NextSpawn = Time.time + spawnRate;
            Spawning();
        }

        if (timeLeft <= 0)
        {
            if (done == false)
            {
                gameObject.GetComponent<Information_Three>().Send();
                GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseMenu>().Pause();
            }
            done = true;
            //SceneManager.LoadScene("TG4");
        }
    }

    void Spawning()
    {
        randX = Random.Range(-24, 24);
        randY = Random.Range(-12, 14);
        whereToSpawn = new Vector3(randX, randY, 19);

        GameObject newObject = Instantiate(Bullseye, whereToSpawn, Quaternion.identity) as GameObject;
        newObject.transform.localScale = scale;
    }

    public void SetSpawnRate(float rate)
    {
        spawnRate = rate;
    }
}
