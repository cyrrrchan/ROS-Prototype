using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary1
{

    public float xMin, xMax;
}

public class PlayerController : MonoBehaviour {

    //public int playerId = 0; // The Rewired player id of this character

    public Boundary1 _boundary;
    [HideInInspector] public bool _facingRight = true;
    [HideInInspector] public bool _jump = false;
    public float _moveForce = 365f; // Amount of force added to move the player left and right.
    public float _maxSpeed = 5f;
    public float _jumpForce = 1000f; // Amount of force added when the player jumps.
    public Transform _groundCheck;

    //private Player player; // The Rewired player
    //private CharacterController cc;
    //private Vector3 moveVector;

    //public float moveForce = 365f;
    //public float jumpSpeed;

    public GameObject _shot_fire1;
    public Transform _shotSpawn;
    public float _fireRate;
    private float _nextFire;

    private bool _grounded = false;          // Whether or not the player is grounded.

    private Rigidbody _rb;

    void Awake()
    {
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        //player = ReInput.players.GetPlayer(playerId);

        // Get the character controller
        //cc = GetComponent<CharacterController>();
        _rb = GetComponent<Rigidbody>();

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
		_rb.AddForce (movement * _moveForce);

        _rb.position = new Vector3(
            Mathf.Clamp(_rb.position.x, _boundary.xMin, _boundary.xMax),
            1.0f,
            0.0f
        );

        if(Input.GetButton("Fire1") && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            Instantiate(_shot_fire1, _shotSpawn.position, _shotSpawn.rotation);
        }

        if (_grounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //rb.velocity = new Vector3(0.0f, jumpSpeed, 0.0f);
				_rb.AddForce(0.0f, _jumpForce, 0.0f,ForceMode.Impulse);
				//rb.AddExplosionForce (jumpSpeed, transform.position - new Vector3 (0, .5f, 0), 100);
                _grounded = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            _grounded = true;
        }
    }
}
