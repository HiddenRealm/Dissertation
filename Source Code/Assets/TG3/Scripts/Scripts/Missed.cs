using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missed : MonoBehaviour {

    private GameObject Info;

    void Start()
    {
        Info = GameObject.FindGameObjectWithTag("Creation");
    }

    void OnMouseDown()
    {
        Info.GetComponent<Information_Three>().Misses();
    }
}
