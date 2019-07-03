using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FColl : MonoBehaviour {

    private GameObject Information;
    GameObject Score;

	void OnMouseDown(){
        Score = GameObject.FindWithTag("Score");
        Score.GetComponent<Score>().FivePoints();

        Information = GameObject.FindGameObjectWithTag("Information");
        Information.GetComponent<Information>().BlueHit();

        Destroy(gameObject);
	}
}
