using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour {

	private int rotation;
	private Vector3 rotationVector;
    private int flipping;
    private GameObject Selection;

    void Start() {
		Selection = GameObject.FindGameObjectWithTag("Selection");
        flipping = 0;

    }

    void Update()  {
       
        float tmp = transform.rotation.y;

        if(tmp == -150 || tmp == -30)
        {
            Flip();
        }

        if (tmp != 0 && tmp != 1)
        {
            flipping++;
            if (flipping >= 20)
            {
                Flip();
            }
        }
        else
        {
            flipping = 0;
        }

    }

    void OnMouseDown() {

        if (Selection.GetComponent<Selection>().Checker.Count != 2)
		{
			rotationVector = transform.rotation.eulerAngles;

            Selection.GetComponent<Selection>().Checking(gameObject);

           
            //StartCoroutine(Turn());
            
            
            rotation = 180;
            rotationVector.y = rotation;
            transform.rotation = Quaternion.Euler(rotationVector);
            rotation += 30;
        }
    }

    public void Flip() {
        StartCoroutine(TurnBack());
    }

    IEnumerator Turn()
    {
        rotation = 30;
        bool loop = true;

        while (loop)
        {
            rotationVector.y = rotation;
            transform.rotation = Quaternion.Euler(rotationVector);
            rotation += 30;
            yield return new WaitForSeconds(0.03f);

            if (rotation == 210)
            {
                loop = false;
            }
        }
    }

    IEnumerator TurnBack()
    {
        rotation = 150;
        bool loop = true;

        while (loop)
        {
            rotationVector.y = rotation;
            transform.rotation = Quaternion.Euler(rotationVector);
            rotation -= 30;
            yield return new WaitForSeconds(0.03f);

            if (rotation == -30)
            {
                loop = false;
            }
        }
    }
}
