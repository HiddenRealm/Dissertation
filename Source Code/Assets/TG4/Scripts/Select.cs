using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour {
	
	private GameObject Spawn;
	public int ID;
	
	void Start() {
		Spawn = GameObject.FindWithTag("Spawn");
	}
	
	void OnMouseDown(){
		if(Spawn.GetComponent<Spawn_4>().play == true)
		{
			Spawn.GetComponent<Buttons>().Add(ID);
		}
		
		StartCoroutine(Light());
	}
	
	IEnumerator Light() {
		if(Spawn.GetComponent<Spawn_4>().play == true)
		{	
			gameObject.GetComponent<Renderer>().material.color = Color.green;
			yield return new WaitForSeconds(0.2f);
			gameObject.GetComponent<Renderer>().material.color = Color.white;
			yield return new WaitForSeconds(0.1f);
		}
	}
}
