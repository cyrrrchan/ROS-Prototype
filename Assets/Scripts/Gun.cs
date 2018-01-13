using UnityEngine;
using System.Collections;
using Rewired;

public class Gun : MonoBehaviour
{
    public int playerId = 0; // The Rewired player id of this character
    private Player player; // The Rewired Player

    public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed = 20f;				// The speed the rocket will fire at.

    public AudioClip _trumpetHit;
    public AudioClip _comboHit;


	private PlayerControl _playerCtrl;		// Reference to the PlayerControl script.
	private Animator _anim;					// Reference to the Animator component.
    private AudioSource _audioSource;

	PlayerControl _WillieMaePlayerControl;


	void Awake()
	{
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerId);

        // Setting up the references.
        _anim = transform.root.gameObject.GetComponent<Animator>();
		_playerCtrl = transform.root.GetComponent<PlayerControl>();
        _audioSource = GetComponent<AudioSource>();

		_WillieMaePlayerControl = GameObject.Find ("WillieMae").GetComponent<PlayerControl> ();
	}


	void Update ()
	{
		// If the square button is pressed...
		if (player.GetButtonDown("Shoot_Square") && _WillieMaePlayerControl._isBreathing) {
			// ... set the animator Shoot trigger parameter and play the audioclip.
			_WillieMaePlayerControl.anim.SetTrigger ("Shoot");
			_audioSource.PlayOneShot (_trumpetHit);
			//_isFiring = true;

			// If the player is facing right...
			if (_playerCtrl.facingRight) {
				// ... instantiate the rocket facing right and set it's velocity to the right. 
				Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2 (speed, 0);
			} else {
				// Otherwise instantiate the rocket facing left and set it's velocity to the left.
				Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 180f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2 (-speed, 0);
			}
		}

        // If the triangle button is pressed...
		else if (player.GetButtonDown("Shoot_Triangle") && _WillieMaePlayerControl._isBreathing) {
            // ... set the animator Shoot trigger parameter and play the audioclip.
            _WillieMaePlayerControl.anim.SetTrigger("Shoot");
            _audioSource.PlayOneShot (_trumpetHit);
			//_isFiring = true;

			// If the player is facing right...
			if (_playerCtrl.facingRight) {
				// ... instantiate the rocket facing right and set it's velocity to the right. 
				Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2 (speed, 0);
			} else {
				// Otherwise instantiate the rocket facing left and set it's velocity to the left.
				Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 180f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2 (-speed, 0);
			}
		}

        // If the circle button is pressed...
		else if (player.GetButtonDown("Shoot_Circle") && _WillieMaePlayerControl._isBreathing) {
            // ... set the animator Shoot trigger parameter and play the audioclip.
            _WillieMaePlayerControl.anim.SetTrigger("Shoot");
            _audioSource.PlayOneShot (_comboHit);
			//_isFiring = true;

			// If the player is facing right...
			if (_playerCtrl.facingRight) {
				// ... instantiate the rocket facing right and set it's velocity to the right. 
				Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2 (speed, 0);
			} else {
				// Otherwise instantiate the rocket facing left and set it's velocity to the left.
				Rigidbody2D bulletInstance = Instantiate (rocket, transform.position, Quaternion.Euler (new Vector3 (0, 0, 180f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2 (-speed, 0);
			}
		} 
    }
}
