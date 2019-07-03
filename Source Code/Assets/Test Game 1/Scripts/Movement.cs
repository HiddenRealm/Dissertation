using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private float topSpeed;
    private float waveSpeed;
    private int aliveTime;
    private float counter;
    private float yPos;
    private bool flip;

    private string red;
    private string blue;
    private string gold;

    private GameObject information;

    void Start () {
        yPos = gameObject.transform.position.y;
        flip = (Random.Range(0, 2) == 0 );


        information = GameObject.FindGameObjectWithTag("Information");
        waveSpeed = 3.8f;
        topSpeed = 0.3f;
        aliveTime = 6;
        counter = 0;

        red = "-10 Points(Clone)";
        blue = "5 Points(Clone)";
        gold = "10 Points(Clone)";
	}
	
	void Update () {
        counter = counter + (1 * Time.deltaTime);

        Moving();

        float time = Mathf.Round(counter * 100f) / 100f;

        if((time % 1) == 0)
        {
            flip = !flip;
        }

        if (counter >= aliveTime)
        {
            string name = gameObject.transform.name;
            

            if(string.Compare(name, red) == 0) {
                information.GetComponent<Information>().RedMiss();
            }
            else if (string.Compare(name, blue) == 0) {
                information.GetComponent<Information>().BlueMiss();
            }
            else if (string.Compare(name, gold) == 0) {
                information.GetComponent<Information>().GoldMiss();
            }


            Destroy(gameObject);
        }
	}

    void Moving() {
        float yMove = yPos * topSpeed * Time.deltaTime;
        float xRM = 1 * waveSpeed * Time.deltaTime;
        float xLM = -1 * waveSpeed * Time.deltaTime;

        float xMove;

        if (flip)
        {
            xMove = xRM;
        }
        else
        {
            xMove = xLM;
        }

        transform.Translate(xMove, -yMove, 0);
    }

    public void SetSpeed(float speed) {
        topSpeed = speed;
    }
}
