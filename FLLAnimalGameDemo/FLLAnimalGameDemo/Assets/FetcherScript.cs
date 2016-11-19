using UnityEngine;
using System.Collections;

public class FetcherScript : MonoBehaviour {

    public Rigidbody2D frisbee;

    Rigidbody2D body;

    public StatusBarSCript happinessBar;

    public StatusBarSCript fitnessBar;


    CircleCollider2D frisbeeCollider;

    BoxCollider2D collide;

    Vector2 oldVel = Vector2.zero;


    public BoxCollider2D manBox;

	// Use this for initialization
	void Start () {

        body = GetComponent<Rigidbody2D>();

        collide = GetComponent<BoxCollider2D>(); 

        frisbeeCollider = frisbee.GetComponent<CircleCollider2D>();
	}
	
    
    IEnumerator FetchRoutine()
    {
        float happinessIncrease = 0f;
        float fitnessIncrease = 0f;
        while(!frisbeeCollider.bounds.Intersects(collide.bounds))
        {
            transform.position = Vector3.Lerp(transform.position,frisbee.position,0.01f);

            happinessIncrease += 0.0001f;
            fitnessIncrease += 0.0001f;

            yield return new WaitForSecondsRealtime(0.01f);
        }

        frisbee.velocity = Vector2.zero;

        while (!frisbeeCollider.bounds.Intersects(manBox.bounds) && !collide.bounds.Intersects(manBox.bounds))
        {
            transform.position = Vector3.Lerp(transform.position, manBox.transform.position, 0.01f);
            frisbee.position = Vector3.Lerp(frisbee.position, manBox.transform.position, 0.01f);

            frisbee.velocity = Vector2.zero;

            yield return new WaitForSecondsRealtime(0.01f);
        }


        happinessBar.progress += happinessIncrease;
        fitnessBar.progress += fitnessIncrease;



        happinessBar.progress = Mathf.Clamp01(happinessBar.progress);

        fitnessBar.progress = Mathf.Clamp01(fitnessBar.progress);

        body.velocity = Vector2.zero;
        frisbee.velocity = Vector2.zero;

    }


	// Update is called once per frame
	void Update () {


        if (oldVel.magnitude < 5f && frisbee.velocity.magnitude >= 5f)
        {

            StartCoroutine(FetchRoutine());


            
        }

        oldVel = frisbee.velocity;
	}
}
