using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class BoxScript : MonoBehaviour {

    // Use this for initialization

    BoxCollider2D collider;

    public BoxCollider2D manBox;

    public Transform teleportExitLocation;

    //public Canvas labels;

    //public Text[] texts = new Text[5];
    
    
	void Start () {

        collider = GetComponent<BoxCollider2D>();

       // texts = labels.GetComponentsInChildren<Text>();
	}
	
    
	// Update is called once per frame
	void Update () {
        if (collider.bounds.Intersects(manBox.bounds))
        {
            manBox.transform.position = teleportExitLocation.position;
            Camera.main.transform.position = teleportExitLocation.position + Vector3.back * 10;
           // if (teleportExitLocation.name == "Home")
           // {
           //     foreach (Text text in texts)
           //     {
           //         //text.color = new Color(text.color.r, text.color.g, text.color.b, 255);
           //         text.transform.localPosition += Vector3.up * 100;
           //     }
            //}
            //else
            //{
            //    foreach (Text text in texts)
            //    {
            //        //text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            //        text.transform.localPosition -= Vector3.up * 100;
            //    }
            //}
        }

	}
}
