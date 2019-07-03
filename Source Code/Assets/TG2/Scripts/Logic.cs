using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour {

	public GameObject Card_Butfly;
    public GameObject Card_Dog;
    public GameObject Card_Toad;
	public GameObject Card_Euro;
	public GameObject Card_Dollar;
	public GameObject Card_Pound;
	public GameObject Card_Circle;
	public GameObject Card_Square;
	public GameObject Card_Tri;
	public GameObject Card_Hex;
	
	private int level;
	private bool playing;
	private List<int> CardPicker;
	
	void Start () {
		level = 1;
		playing = false;
	}
	
	void Update () {
		SpawnCards();
	}
	
	void SpawnCards() {
		//Level 1
		if(level == 1 && playing == false)
		{
			//Butterfly
			//Dog
			//Euro
			//Pound
			playing = true;
			
			Vector3[] Level_1 = new Vector3[8];
			Level_1[0] = new Vector3(-8, 10, 19);
			Level_1[1] = new Vector3(-1, 10, 19);
			Level_1[2] = new Vector3(6, 10, 19);
			Level_1[3] = new Vector3(-8, 0, 19);
			Level_1[4] = new Vector3(6, 0, 19);
			Level_1[5] = new Vector3(-8, -10, 19);
			Level_1[6] = new Vector3(-1, -10, 19);
			Level_1[7] = new Vector3(6, -10, 19);
			
			CardPicker = new List<int>();
			for (int i = 1; i<= 8; i++)
			{
				CardPicker.Add(i);
			}
			
			for(int i = 0; i < Level_1.Length; i++){
			
			
			GameObject choice = GetNumber();
			GameObject newObject = Instantiate(choice, Level_1[i], Quaternion.identity) as GameObject;
			}
		}
	}
	
	
	GameObject GetNumber() {
		
		int PickedCardIndex = Random.Range(0, CardPicker.Count);
		int PickedCard = CardPicker[PickedCardIndex];
		CardPicker.RemoveAt(PickedCardIndex);
		
		if(PickedCard == 1 || PickedCard == 2)
		{
			return Card_Butfly;
		}
		else if (PickedCard == 3 || PickedCard == 4)			
		{
			return Card_Dog;
		}
		else if (PickedCard == 5 || PickedCard == 6)			
		{
			return Card_Square;
		}
		else if (PickedCard == 7 || PickedCard == 8)			
		{
			return Card_Circle;
		}
		else
		{
			Debug.Log(PickedCard);
			return Card_Pound;
		}
	}
}
