using UnityEngine;
using System.Collections;
using Rewired;


public class PlayerControl : MonoBehaviour
{
    public int playerId = 0; // The Rewired player id of this character
    private Player player; // The Rewired Player

    [HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.
    [HideInInspector]
    public bool _isBreathing = false;

    public int HP = 5;
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	//public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 700f;			// Amount of force added when the player jumps.
	//public AudioClip[] taunts;				// Array of clips for when the player taunts.
	//public float tauntProbability = 50f;	// Chance of a taunt happening.
	//public float tauntDelay = 1f;			// Delay for when the taunt should happen.


	//private int tauntIndex;					// The index of the taunts array indicating the most recent taunt.
	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	public Animator anim;					// Reference to the player's animator component.
    private Rigidbody2D _rb2d;
    private SpriteRenderer spriteRenderer;


	void Awake()
	{
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerId);

        // Setting up references.
        groundCheck = transform.Find("groundCheck");
		//anim = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
    }


	void Update()
	{
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        // If the jump button is pressed and the player is grounded then the player should jump.
        if (player.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

		if (player.GetButton("Breathing"))
			_isBreathing = true;
		else if (!player.GetButton("Breathing"))
			_isBreathing = false;
	}


	void FixedUpdate ()
	{
		// Cache the horizontal input.
		float h = player.GetAxis("Move Horizontal");

        // The Speed animator parameter is set to the absolute value of the horizontal input.
        anim.SetFloat("Speed", Mathf.Abs(h));

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * _rb2d.velocity.x < maxSpeed)
            // ... add a force to the player.
            _rb2d.AddForce(Vector2.right * h * moveForce);

		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(_rb2d.velocity.x) > maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            _rb2d.velocity = new Vector2(Mathf.Sign(_rb2d.velocity.x) * maxSpeed, _rb2d.velocity.y);

		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip();

		// If the player should jump...
		if(jump)
		{
            // Add a vertical force to the player.
            _rb2d.AddForce(new Vector2(0f, jumpForce));

            // Set the Jump animator trigger parameter.
            anim.SetTrigger ("Jump");

			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
