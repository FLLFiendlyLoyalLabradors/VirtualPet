using UnityEngine;
using System.Collections;

public class DuckSCript : MonoBehaviour {


    public float speedMin = 1f;

    public float speedMax = 10f;

    Rigidbody2D body;

    public float timeMin = 1f;

    public float timeMax = 3f;


    public float torqueMin = 10f;

    public float torqueMax = 100f;

    

    

    // Use this for initialization
    void Start () {

        body = GetComponent<Rigidbody2D>();

        StartCoroutine(MoveRoutine());
    }

    public IEnumerator MoveRoutine()
    {
        

        while(true)
        {
            body.velocity = Vector2.zero;
            body.angularVelocity = 0f;

            body.AddTorque(Random.Range(torqueMin,torqueMax));

            yield return new WaitForSecondsRealtime(0.5f);

            body.angularVelocity = 0f;
            body.AddForce(transform.right * Random.Range(speedMin,speedMax));

            yield return new WaitForSecondsRealtime(Random.Range(timeMin,timeMax));
        }
    }


	// Update is called once per frame
	void Update () {

        //time += Time.deltaTime;

        //if(time >= maxTime)
        //{
        //    transform.Rotate(Vector3.forward * Random.Range(1f,360f));
        //    maxTime = Random.Range(0,2);
        //    speed = Random.Range(speedMin,speedMax);
        //    time = 0f;
        //}
        //else
        //{
        //    transform.position += transform.forward * speed;
        //}

    }
}
