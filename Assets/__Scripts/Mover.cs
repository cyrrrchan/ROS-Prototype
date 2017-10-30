using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;

    private Transform shotPosition;

    private void Start()
    {
        shotPosition = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update () {
        //shotPosition = transform.right * speed;
	}
}
