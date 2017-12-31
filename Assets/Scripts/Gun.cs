using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
	//public bool _isFiring = false;

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
		// Setting up the references.
		_anim = transform.root.gameObject.GetComponent<Animator>();
		_playerCtrl = transform.root.GetComponent<PlayerControl>();
        _audioSource = GetComponent<AudioSource>();

		_WillieMaePlayerControl = GameObject.Find ("WillieMae").GetComponent<PlayerControl> ();
	}


	void Update ()
	{
		// If the square button is pressed...
		if (Input.GetButtonDown ("Fire1") && _WillieMaePlayerControl._isBreathing) {
			// ... set the animator Shoot trigger parameter and play the audioclip.
			_anim.SetTrigger ("Shoot");
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
		else if (Input.GetButtonDown ("Fire2") && _WillieMaePlayerControl._isBreathing) {
			// ... set the animator Shoot trigger parameter and play the audioclip.
			_anim.SetTrigger ("Shoot");
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
		else if (Input.GetButtonDown ("Fire3") && _WillieMaePlayerControl._isBreathing) {
			// ... set the animator Shoot trigger parameter and play the audioclip.
			_anim.SetTrigger ("Shoot");
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

		/*else if (Input.GetButtonUp ("Fire1") || Input.GetButtonUp ("Fire2") || Input.GetButtonUp ("Fire3"))
			_isFiring = false;*/
    }
}
