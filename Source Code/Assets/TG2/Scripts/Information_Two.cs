using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information_Two : MonoBehaviour
{

    private int wrong;
    private GameObject Pause;

    private float timer = 0.0f;
    private bool done;

    void Start()
    {
        wrong = 0;
        done = false;
        
        Pause = GameObject.FindGameObjectWithTag("Pause");
    }


    void Update()
    {
        timer += Time.deltaTime;

        float temp = (wrong / 32);

        float tmp = ((4 / (temp + 4)) * 100);
        

        if (GameObject.FindGameObjectsWithTag("Card").Length == 0 && timer > 5)
        {
            if (done == false)
            {
                Pause.GetComponent<PauseMenu>().Acc(tmp);
                Pause.GetComponent<PauseMenu>().GTwA(tmp);
                Pause.GetComponent<PauseMenu>().GTwT(timer);
                Pause.GetComponent<PauseMenu>().Pause();
            }
            done = true;
            //SceneManager.LoadScene("TG3");
        }
    }

    public void NoMatch()
    {
        wrong++;
    }
}