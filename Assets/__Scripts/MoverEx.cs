using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEx : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.right * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
