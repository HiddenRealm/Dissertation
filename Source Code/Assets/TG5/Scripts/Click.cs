using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour {

	Queue<GameObject> shapes = new Queue<GameObject>();
	private GameObject First;
	private GameObject Second;
	
	private int correct;
	private int score;
	private int guessed;
	
	public Text sText;

	void Start () {
		score = 0;
		guessed = 0;
		correct = 0;
		
		sText.text = "0"; 
	}
	
	void Update() {
		sText.text = score.ToString();
	}
	
	public void Yes() {
		Logic(true);
	}
	
	public void No() {
		Logic(false);
	}
	
	void Logic(bool guess) {
		First = shapes.Dequeue();
		Second = shapes.Peek();
		
		string name_One = First.transform.name;
		string name_Two = Second.transform.name;
		
		if(String.Compare(name_One, name_Two) == 0) 
		{
			if(guess == true)
			{
				score += 2;
				correct++;
			}
			else
			{
				score--;
			}
			guessed++;
		}
		else 
		{
			if(guess == true)
			{
				score--;
			}
			else
			{
				score += 2;
				correct++;
			}
			guessed++;
		}
		
		
		Destroy(First);
		GetComponent<Spawn>().SpawnShape();
	}
	
	public void AddQueue(GameObject obj) {
		shapes.Enqueue(obj);
	}
	
	public int GetScore()
	{
		return score;
	}
	
	public int GetCorrect()
	{
		return correct;
	}
	
	public int GetGuessed()
	{
		return guessed;
	}
}
