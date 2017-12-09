using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
	public Rigidbody2D rocket;				// Prefab of the rocket.
	public float speed = 20f;				// The speed the rocket will fire at.

    public AudioClip _trumpetHit;
    public AudioClip _comboHit;


	private PlayerControl _playerCtrl;		// Reference to the PlayerControl script.
	private Animator _anim;					// Reference to the Animator component.
    private AudioSource _audioSource;


	void Awake()
	{
		// Setting up the references.
		_anim = transform.root.gameObject.GetComponent<Animator>();
		_playerCtrl = transform.root.GetComponent<PlayerControl>();
        _audioSource = GetComponent<AudioSource>();
	}


	void Update ()
	{
		// If the square button is pressed...
		if(Input.GetButtonDown("Fire1"))
		{
			// ... set the animator Shoot trigger parameter and play the audioclip.
			_anim.SetTrigger("Shoot");
            _audioSource.PlayOneShot(_trumpetHit);

			// If the player is facing right...
			if(_playerCtrl.facingRight)
			{
				// ... instantiate the rocket facing right and set it's velocity to the right. 
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(speed, 0);
			}
			else
			{
				// Otherwise instantiate the rocket facing left and set it's velocity to the left.
				Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;
				bulletInstance.velocity = new Vector2(-speed, 0);
			}
		}

        // If the triangle button is pressed...
        else if (Input.GetButtonDown("Fire2"))
        {
            // ... set the animator Shoot trigger parameter and play the audioclip.
            _anim.SetTrigger("Shoot");
            _audioSource.PlayOneShot(_trumpetHit);

            // If the player is facing right...
            if (_playerCtrl.facingRight)
            {
                // ... instantiate the rocket facing right and set it's velocity to the right. 
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(speed, 0);
            }
            else
            {
                // Otherwise instantiate the rocket facing left and set it's velocity to the left.
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-speed, 0);
            }
        }

        // If the circle button is pressed...
        else if (Input.GetButtonDown("Fire3"))
        {
            // ... set the animator Shoot trigger parameter and play the audioclip.
            _anim.SetTrigger("Shoot");
            _audioSource.PlayOneShot(_comboHit);

            // If the player is facing right...
            if (_playerCtrl.facingRight)
            {
                // ... instantiate the rocket facing right and set it's velocity to the right. 
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(speed, 0);
            }
            else
            {
                // Otherwise instantiate the rocket facing left and set it's velocity to the left.
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-speed, 0);
            }
        }
    }
}
