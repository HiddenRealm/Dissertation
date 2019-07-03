using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hits : MonoBehaviour {

    private GameObject Info;

    void Start()
    {
        Info = GameObject.FindGameObjectWithTag("Information");
    }

    void OnMouseDown()
    {
        Info.GetComponent<Information>().Hits();
    }
}
