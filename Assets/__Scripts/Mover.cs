using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;
	private Rigidbody rb;

    //private Transform shotPosition;

    private void Start()
    {
        //shotPosition = GetComponent<Transform>();
		rb = GetComponent<Rigidbody>();
		//rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update () {
        //shotPosition = transform.right * speed;
		rb.velocity = transform.right * speed;
	}
}
