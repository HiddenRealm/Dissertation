using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour {

	private int selected;
	public List<GameObject> Checker;
	private GameObject[] tmp;
	private int rotation;
	private Vector3 rotationVector;
	public bool wait;
	
	private GameObject Information;
	
	void Start () {
		selected = 0;
		Checker = new List<GameObject>();
		tmp = new GameObject[2];
		wait = false;
	}
	
	void Update() {
		
		if(Checker.Count == 2) {
			StartCoroutine(Logic());
		}
	}
	
	IEnumerator Logic() {
		
		wait = true;
		string name_One = Checker[0].transform.name;
		string name_Two = Checker[1].transform.name;
		
		tmp[0] = Checker[0];
		tmp[1] = Checker[1];

        yield return new WaitForSeconds(0.5f);

        if (String.Compare(name_One, name_Two) == 0) {
			Destroy(tmp[0]);
			Destroy(tmp[1]);
		}
		else {
			GetComponent<Information_Two>().NoMatch();
		}
        //GameObject.FindGameObjectsWithTag("Card")
        foreach (GameObject obj in Checker) {
            //obj.GetComponent<OnClick>().Flip();

            
            rotationVector = obj.transform.rotation.eulerAngles;
			rotation = 0;
			rotationVector.y = rotation;
			obj.transform.rotation = Quaternion.Euler(rotationVector);
            

			}

        Checker.Clear();
		selected = 0;
		wait = false;
	}

    public int Selected() {
		return selected;
	}

	public void ReSelected() {
		selected = 0;
	}
	
	public void Checking(GameObject obj) {
		Checker.Add(obj);
        selected++;
    }
}
