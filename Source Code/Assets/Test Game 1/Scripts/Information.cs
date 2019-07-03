using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour {

    private int bluButtHit, bluButtMis;
    private int golButtHit, golButtMis;
    private int redButtHit, redButtMis;
    private int hits;
    private float accuracy, total, good;
    private GameObject Pause;
    
    private float counter;

	void Start () {
        bluButtHit = 0;
        bluButtMis = 0;
        golButtHit = 0;
        golButtMis = 0;
        redButtHit = 0;
        redButtMis = 0;
        accuracy = 0;
        total = 0;
        good = 0;
        hits = 0;

        Pause = GameObject.FindGameObjectWithTag("Pause");
    }
	
	
	void Update () {
        total = ((hits + (bluButtMis + golButtMis + redButtMis) * 100));
        good = ((bluButtHit + golButtHit + redButtMis) * 100);

        accuracy = ((good / total) * 100);
        Pause.GetComponent<PauseMenu>().Acc(accuracy);
    }

    public void Send()
    {
        Pause.GetComponent<PauseMenu>().GOnA(accuracy);
        Pause.GetComponent<PauseMenu>().GOnT(total);
        Pause.GetComponent<PauseMenu>().GOnG(good);
    }

    public void BlueHit()
    {
        bluButtHit++;
    }

    public void GoldHit()
    {
        golButtHit++;
    }

    public void RedHit() {
        redButtHit++;
    }

    public void BlueMiss()
    {
        bluButtMis++;
    }

    public void GoldMiss()
    {
        golButtMis++;
    }

    public void RedMiss()
    {
        redButtMis++;
    }

    public void Hits()
    {
        hits += 100;
    }
}
