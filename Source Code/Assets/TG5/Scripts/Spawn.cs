using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject Square;
	public GameObject Circle;
	public GameObject Triangle;
	public GameObject Hexagon;
	
	private List<GameObject> shapes;
	
	private Vector3 spawn;
	
	void Start () {
		spawn = new Vector3(15, 2, 19);
		
		shapes = new List<GameObject>();
		
		for(int i = 0; i<= 6; i++)
		{
			SpawnShape();
		}
	}
	
	void Update () {
		
	}
	
	public void SpawnShape() {
		
		Move();
		int num = Random.Range(0, 4);
		
		GameObject newObject;
		
		if(num == 1)
		{
			newObject = Instantiate(Triangle, spawn, Quaternion.identity) as GameObject;
			GetComponent<Click>().AddQueue(newObject);
		}
		else if (num == 2)
		{
			newObject = Instantiate(Square, spawn, Quaternion.identity) as GameObject;
			GetComponent<Click>().AddQueue(newObject);
		}
		else if (num == 3)
		{
			newObject = Instantiate(Circle, spawn, Quaternion.identity) as GameObject;
			GetComponent<Click>().AddQueue(newObject);
		}
		else
		{
			newObject = Instantiate(Hexagon, spawn, Quaternion.identity) as GameObject;
			GetComponent<Click>().AddQueue(newObject);
		}
		shapes.Add(newObject);
	}
	
	void Move() {
		
		foreach(GameObject shape in shapes)
		{
			shape.transform.position += new Vector3(-5, 0, 0);
		}
		
		if(shapes.Count >= 7)
		{
			shapes.RemoveAt(0);
		}
	}
}
