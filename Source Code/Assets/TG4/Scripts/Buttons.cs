using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

	private List<int> pattern;
	private List<int> light;
	private int level;
	private int fl;
    private bool done;
    private float wrong;
    private float tmp;
    public Transform button;
    private GameObject Pause;
    private float timer = 0.0f;

    void Start() {
		pattern = new List<int>();
		light = new List<int>();

        done = false;
		level = 2;
		light = GetComponent<Spawn_4>().Light;
        button.gameObject.SetActive(true);
        Pause = GameObject.FindGameObjectWithTag("Pause");
    }

    void Update() {
        timer += Time.deltaTime;
        tmp = ((3 / (wrong + 3)) * 100);
    }

    public void Check() {
			
		if(GetComponent<Spawn_4>().play == true)
		{
			bool check = true;
			
			int z = 0;
			
			foreach (int li in light)
			{
				if(light[z] != pattern[z])
				{
                    check = false;
				}
				z++;
			}
			
			pattern.Clear();
			
			if(check == true)
			{
				GetComponent<Spawn_4>().SetLevel(level);
					
				if(level == 4)
				{
                    if (done == false)
                    {
                        Pause.GetComponent<PauseMenu>().Acc(tmp);
                        button.gameObject.SetActive(false);
                        Pause.GetComponent<PauseMenu>().GFoA(tmp);
                        Pause.GetComponent<PauseMenu>().GFoW(wrong);
                        Pause.GetComponent<PauseMenu>().GFoT(timer);
                        Pause.GetComponent<PauseMenu>().Pause();
                    }
                    done = true;
                    //SceneManager.LoadScene("TG5");
                }
				level++;
			}
            else
            {
                wrong++;
                Reset();
            }
		}
	}
	
	public void Reset() {
		if(GetComponent<Spawn_4>().play == true)
		{
			pattern.Clear();
			
			GetComponent<Spawn_4>().Code();
		}
	}
	
	public void Add(int id) {
		pattern.Add(id);
	}
}
