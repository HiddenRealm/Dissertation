using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Information_5 : MonoBehaviour {

    private float timer = 45.0f;
    private float timeLeft;
    public Text tText;
    private bool done;
    public Transform button;
    private float guessed, tmp;
    private int score;
    public GameObject Spawn;
    private GameObject Pause;


    void Start()
    {
        done = false;
        timeLeft = timer;
        tText.text = "0";

        button.gameObject.SetActive(true);
        Pause = GameObject.FindGameObjectWithTag("Pause");
    }

    void Update () {
        timeLeft -= Time.deltaTime;

        int time = Mathf.RoundToInt(timeLeft);
        tText.text = time.ToString();

        if (timeLeft <= 0)
        {
			score = Spawn.GetComponent<Click>().GetScore();
			float correct = Spawn.GetComponent<Click>().GetCorrect();
			guessed = Spawn.GetComponent<Click>().GetGuessed();

            tmp = ((correct / guessed) * 100);
            Pause.GetComponent<PauseMenu>().Acc(tmp);

            if (done == false)
            {
                button.gameObject.SetActive(false);
                Pause.GetComponent<PauseMenu>().GFiA(tmp);
                Pause.GetComponent<PauseMenu>().GFiS(guessed);
                Pause.GetComponent<PauseMenu>().GFiG(score);
                Pause.GetComponent<PauseMenu>().Pause();
            }
            done = true;
            //SceneManager.LoadScene("Save");
        }
	}
}
