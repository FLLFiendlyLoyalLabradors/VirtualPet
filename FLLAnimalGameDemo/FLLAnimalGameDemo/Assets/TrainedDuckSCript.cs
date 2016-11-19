using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrainedDuckSCript : MonoBehaviour {


    List<Vector3> points;

    public StatusBarSCript fitnessBar;

    public StatusBarSCript trainingBar;


    Rigidbody2D body;

    BoxCollider2D collider;

	// Use this for initialization
	void Start () {

        body = GetComponent<Rigidbody2D>();
        points = new List<Vector3>();

        collider = GetComponent<BoxCollider2D>();

	}

    IEnumerator StuntRoutine()
    {
        while (true)
        {
            if(Input.GetMouseButton(0))
            {
                points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10));
            }
            else
            {
                StartCoroutine(DoStunt());
                break;
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    IEnumerator DoStunt()
    {
        float fitnessIncrease = 0f;
        float trainingIncrease = 0f;
        while(points.Count >= 1)
        {
            body.position = Vector3.Lerp(body.position,points[0],0.8f);

            fitnessIncrease += 0.001f;
            trainingIncrease += 0.001f;


            if(Mathf.Abs(body.position.x - points[0].x) <= 0.1f && Mathf.Abs(body.position.y - points[0].y) <= 0.1f)
            {
                points.RemoveAt(0);
            }

            yield return new WaitForSecondsRealtime(0.01f);
        }

        fitnessBar.progress = Mathf.Clamp01(fitnessBar.progress + fitnessIncrease);
        trainingBar.progress = Mathf.Clamp01(trainingBar.progress + trainingIncrease);
    }


	// Update is called once per frame
	void Update () {
	
        if(Input.GetMouseButtonDown(0) && Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10).y >= 50)
        {
            StartCoroutine(StuntRoutine());
        }
	}
}
