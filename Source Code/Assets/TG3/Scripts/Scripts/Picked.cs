using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picked : MonoBehaviour {

    private Vector3 gauge;
    private Vector3 scale;
    private Vector3 growth;
    private int grow;
    private bool grown;

    private GameObject Info;

    void Start() {
        gauge = new Vector3(0.7f, 0.7f, 1);

        if (Application.platform == RuntimePlatform.Android)
        {
            gauge = new Vector3(1.8f, 1.8f, 1);
        }
        scale = new Vector3(0, 0, 0);

        grow = 25;

        growth = (gauge / (grow * 2));
        grown = false;

        Info = GameObject.FindGameObjectWithTag("Creation");
    }

    void OnMouseDown() {

        Info.GetComponent<Information_Three>().Score();
        Destroy(gameObject);
	}

    void Update() {
        StartCoroutine(Grow());
    }

    IEnumerator Grow() {
        gameObject.transform.localScale = scale;
        
        if (scale.x >= gauge.x)
        {
            grown = true;
            gauge -= growth;
            scale -= growth;
            yield return new WaitForSeconds(0.5f);
        }
        else if (scale.x < gauge.x && grown == false)
        {
            scale += growth;
            yield return new WaitForSeconds(0.5f);
        }

        if (scale.x < 0)
        {
            Info.GetComponent<Information_Three>().Misses();
            Destroy(gameObject);
        }
    }
}
