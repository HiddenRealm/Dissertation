using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_4 : MonoBehaviour {

	public GameObject Square;
	
	private int level;
	private List<GameObject> Tiles;
	public List<int> Light;
	private Vector3[] Level_1 = new Vector3[4];
	private Vector3[] Level_2 = new Vector3[9];
	private Vector3 scale;
	public bool play;
	
	void Start () {
		scale = new Vector3(3.5f,3.5f,1);
		level = 1;
		Level_1[0] = new Vector3(-5.2f, 10f, 19f);
		Level_1[1] = new Vector3(-5.2f, -0.5f, 19f);
		Level_1[2] = new Vector3(5.2f, 10f, 19f);
		Level_1[3] = new Vector3(5.2f, -0.5f, 19f);
		
		Level_2[0] = new Vector3(-6, 11, 19f);
		Level_2[1] = new Vector3(0, 11, 19f);
		Level_2[2] = new Vector3(6, 11, 19f);
		Level_2[3] = new Vector3(-6, 5, 19f);
		Level_2[4] = new Vector3(0, 5, 19f);
		Level_2[5] = new Vector3(6, 5, 19f);
		Level_2[6] = new Vector3(-6, -1, 19f);
		Level_2[7] = new Vector3(0, -1, 19f);
		Level_2[8] = new Vector3(6, -1, 19f);
		
		Light = new List<int>();
		Tiles = new List<GameObject>();
		
		play = true;
		Spawn();
	}
	
	public IEnumerator Play() {
		play = false;
		yield return new WaitForSeconds(1);
		
		foreach (int light in Light)
		{
			Tiles[light].GetComponent<Renderer>().material.color = Color.red;
			yield return new WaitForSeconds(1);
			Tiles[light].GetComponent<Renderer>().material.color = Color.white;
			yield return new WaitForSeconds(0.5f);
		}
		play = true;
	}
	
	void Update () {
		Spawn();
	}
	
	public void Code() {
		StartCoroutine(Play());
	}
	
	void Spawn() {
		
		if(level == 1)
		{
			for(int i = 0; i < Level_1.Length; i++) {
				GameObject newObject = Instantiate(Square, Level_1[i], Quaternion.identity) as GameObject;
				newObject.transform.localScale = scale;
				newObject.GetComponent<Select>().ID = i;
				Tiles.Add(newObject);
			}
			
			Light.Add(Random.Range(0, 4));
			Light.Add(Random.Range(0, 4));
			Light.Add(Random.Range(0, 4));
			
			level = 0;
			StartCoroutine(Play());
		}
		else if (level == 2)
		{
			foreach (GameObject obj in Tiles)
			{
				Destroy(obj);
			}
			
			Tiles.Clear();
			Light.Clear();
			
			for(int i = 0; i < Level_2.Length; i++) {
				GameObject newObject = Instantiate(Square, Level_2[i], Quaternion.identity) as GameObject;
				newObject.GetComponent<Select>().ID = i;
				Tiles.Add(newObject);
			}
			
			for(int i = 0; i <= 3; i++)
			{
				Light.Add(Random.Range(0, 9));
			}
			
			level = 0;
			StartCoroutine(Play());
		}
		else if (level == 3)
		{
			foreach (GameObject obj in Tiles)
			{
				Destroy(obj);
			}
			
			Tiles.Clear();
			Light.Clear();
			
			for(int i = 0; i < Level_2.Length; i++) {
				GameObject newObject = Instantiate(Square, Level_2[i], Quaternion.identity) as GameObject;
				newObject.GetComponent<Select>().ID = i;
				Tiles.Add(newObject);
			}
			
			for(int i = 0; i <= 4; i++)
			{
				Light.Add(Random.Range(0, 9));
			}
			
			level = 0;
			StartCoroutine(Play());
		}
	}
	
	public void SetLevel(int num) {
		level = num;
	}
}
