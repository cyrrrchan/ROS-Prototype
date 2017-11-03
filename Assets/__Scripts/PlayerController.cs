using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{

    public float xMin, xMax;
}

public class PlayerController : MonoBehaviour {

    //public int playerId = 0; // The Rewired player id of this character

    public Boundary boundary;
    public float moveSpeed;

    //private Player player; // The Rewired player
    //private CharacterController cc;
    //private Vector3 moveVector;

    //public float moveForce = 365f;          // Amount of force added to move the player left and right.
    public float jumpSpeed;         // Amount of force added when the player jumps.

    public GameObject shot_fire1;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    private bool grounded = false;          // Whether or not the player is grounded.

    private Rigidbody rb;

    void Awake()
    {
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        //player = ReInput.players.GetPlayer(playerId);

        // Get the character controller
        //cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
    }

    // Update is called once per frame
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        //rb.velocity = movement * moveSpeed;
		//rb.AddForceAtPosition((moveHorizontal * moveForce), 1.0f, 0.0f);
		//rb.AddForceAtPosition(new Vector3(1,0,0),transform.position-new Vector3(.5f,0,0));
		rb.AddForce (movement * moveSpeed);

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            1.0f,
            0.0f
        );

        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot_fire1, shotSpawn.position, shotSpawn.rotation);
        }

        if (grounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //rb.velocity = new Vector3(0.0f, jumpSpeed, 0.0f);
				rb.AddForce(0.0f, jumpSpeed, 0.0f,ForceMode.Impulse);
				//rb.AddExplosionForce (jumpSpeed, transform.position - new Vector3 (0, .5f, 0), 100);
                grounded = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            grounded = true;
        }
    }
}
