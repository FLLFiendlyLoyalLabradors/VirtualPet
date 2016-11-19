using UnityEngine;
using System.Collections;

public class StatusBarSCript : MonoBehaviour {

    [Range(0f,1f)]
    public float progress = 1f;


    public Transform progressBar;

	// Use this for initialization
	void Start () {

        

	}
	
	// Update is called once per frame
	void Update () {

        progressBar.localScale = new Vector3(progress,1f,1f);



	}
}
