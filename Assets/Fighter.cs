using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {
    private CharacterController controller;
    private Vector3 moveVector;
    private float verticalVelocity;

    public Collider[] attackHitboxes;

	// Use this for initialization
	private void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	private void Update () {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            LaunchAttack(attackHitboxes[0]);
        if (Input.GetKeyDown(KeyCode.UpArrow))
            LaunchAttack(attackHitboxes[1]);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            LaunchAttack(attackHitboxes[2]);

        if (controller.isGrounded)
        {
            verticalVelocity = -1;

            if (Input.GetKeyDown(KeyCode.Space))
                verticalVelocity = 10;
        }
        else
        { verticalVelocity -= 14 * Time.deltaTime;
        }
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * 5;
        moveVector.y = verticalVelocity;

        controller.Move(moveVector * Time.deltaTime);
        }
    private void LaunchAttack(Collider col)
    { }
	}
