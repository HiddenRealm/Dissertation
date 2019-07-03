using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TColl : MonoBehaviour {

    private GameObject Information;
    GameObject Score;

    void OnMouseDown()
    {
        Score = GameObject.FindWithTag("Score");
        Score.GetComponent<Score>().TenPoints();

        Information = GameObject.FindWithTag("Information");
        Information.GetComponent<Information>().GoldHit();
        Destroy(gameObject);
    }
}
