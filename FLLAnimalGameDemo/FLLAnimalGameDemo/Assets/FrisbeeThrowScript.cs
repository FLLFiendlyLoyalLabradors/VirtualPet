using UnityEngine;
using System.Collections;

public class FrisbeeThrowScript : MonoBehaviour {


    CircleCollider2D hitbox;


    

    Rigidbody2D physicsBody;

	// Use this for initialization
	void Start () {

        hitbox = GetComponent<CircleCollider2D>();
        physicsBody = GetComponent<Rigidbody2D>();

	}
	

    

	// Update is called once per frame
	void Update () {
	
        if(hitbox.bounds.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10)) && Input.GetMouseButton(0))
        {
            physicsBody.AddTorque(10);
            
        }
        if(/*hitbox.bounds.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10)) &&*/Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10).x>=50 && Input.GetMouseButtonUp(0))
        {
            physicsBody.AddForce(new Vector2((Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10).x - transform.position.x) * 18, (Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10).y - transform.position.y) * 18));
            
        }

    }
}
