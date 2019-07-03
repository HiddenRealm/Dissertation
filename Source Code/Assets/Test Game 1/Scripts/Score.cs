using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static Score gameData;

	public int score;
	public Text sText;

	void Start () {
		sText.text = "0"; 
	}

	void Update(){
		sText.text = score.ToString();
	}

	public void SetScore(int points){
		score += points;
	}

	public void FivePoints(){
		score += 5;
	}

	public void TenPoints(){
		score += 10;
	}

	public void MinusPoints(){
		score += -10;
	}

}
