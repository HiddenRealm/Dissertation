using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MColl : MonoBehaviour {

    private GameObject Information;
    GameObject Score;

    void OnMouseDown()
    {
        Score = GameObject.FindWithTag("Score");
        Score.GetComponent<Score>().MinusPoints();

        Information = GameObject.FindGameObjectWithTag("Information");
        Information.GetComponent<Information>().RedHit();
        Destroy(gameObject);
    }
}
