using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public GameObject Speed;
    public GameObject[] Butterflies;
    public GameObject Spawner;
    public float timer = 45.0f;
    private float timeLeft;
    public Text tText;
    private bool done;

    void Start()
    {
        done = false;
        timeLeft = timer;
        tText.text = "0";
    }

    void Update () {
        timeLeft -= Time.deltaTime;

        int time = Mathf.RoundToInt(timeLeft);
        tText.text = time.ToString();

        SpeedUp();

        if (timeLeft <= 0)
        {
            if (done == false)
            {
                GameObject.FindGameObjectWithTag("Information").GetComponent<Information>().Send();
                GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseMenu>().Pause();
            }
            done = true;
            //SceneManager.LoadScene("TG2");
        }
	}

    void SpeedUp()
    {
        float pLeft = (timeLeft / timer) * 100;
        Butterflies = GameObject.FindGameObjectsWithTag("Butterfly");
        foreach (GameObject Speed in Butterflies) {
            if (pLeft <= 15)
            {
                Speed.GetComponent<Movement>().SetSpeed(0.6f);
            }
            else if (pLeft <= 50)
            {
                Speed.GetComponent<Movement>().SetSpeed(0.5f);
            }
            else if (pLeft <= 75)
            {
                Speed.GetComponent<Movement>().SetSpeed(0.4f);
            }
        }

        Spawner = GameObject.FindGameObjectWithTag("Spawner");

        if (pLeft <= 15)
        {
            Spawner.GetComponent<Spawner>().SetSpawnRate(0.2f);
        }
        else if (pLeft <= 50)
        {
            Spawner.GetComponent<Spawner>().SetSpawnRate(0.3f);
        }
        else if (pLeft <= 75)
        {
            Spawner.GetComponent<Spawner>().SetSpawnRate(0.4f);
        }
    }
}
