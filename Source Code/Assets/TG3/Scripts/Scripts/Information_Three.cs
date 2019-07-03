using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Information_Three : MonoBehaviour {

    private float score;
    private float misses;
    private GameObject Pause;
    public Text sText;
    private float tmp;

    void Start () {
        score = 0;
        misses = 0;
        
        Pause = GameObject.FindGameObjectWithTag("Pause");
    }

    private void Update()
    {
        sText.text = score.ToString();

        tmp = ((score / misses) * 100);

        Pause.GetComponent<PauseMenu>().Acc(tmp);
    }

    public void Send()
    {
        Pause.GetComponent<PauseMenu>().GThA(tmp);
        Pause.GetComponent<PauseMenu>().GThS(score);
        Pause.GetComponent<PauseMenu>().GThM(misses);
    }

    public void Score() {
        score++;
    }

    public void Misses()
    {
        misses++;
    }
}
