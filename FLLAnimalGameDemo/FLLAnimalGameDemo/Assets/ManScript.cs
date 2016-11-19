using UnityEngine;
using System.Collections;

public class ManScript : MonoBehaviour {


    public float speed = 0.1f;

    public KeyCode forward = KeyCode.W;
    public KeyCode left = KeyCode.A;
    public KeyCode backward = KeyCode.S;
    public KeyCode right = KeyCode.D;

    // Use this for initialization
    void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKey(forward))
        {

            transform.Translate(Vector3.up * speed);
            //transform.position = new Vector2(transform.position.x,transform.position.y + 1);
        }
        if (Input.GetKey(backward))
        {

            transform.Translate(Vector3.down * speed);
            //transform.position = new Vector2(transform.position.x,transform.position.y + 1);
        }
        if (Input.GetKey(right))
        {

            transform.Translate(Vector3.right * speed);
            //transform.position = new Vector2(transform.position.x,transform.position.y + 1);
        }
        if (Input.GetKey(left))
        {

            transform.Translate(Vector3.left * speed);
            //transform.position = new Vector2(transform.position.x,transform.position.y + 1);
        }
    }
}
