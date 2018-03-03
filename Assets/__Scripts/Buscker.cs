using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buscker : Enemy {

    private PlayerControl _playerCtrl;		// Reference to the PlayerControl script.
	private GameObject _playerCtrlTransform;

    private bool _cooldown = false;

    public Rigidbody2D rocket;              // Prefab of the rocket.
    public float speed;               // The speed the rocket will fire at.

    //private float _t = 0.0f;
    private float _projectileDelay = 3.0f;
    private float _count = 0.0f;

    BusckerTrigger _BusckerTrigger;

    private void Awake()
    {
        _playerCtrl = GameObject.Find("WillieMae").GetComponent<PlayerControl>();
		_playerCtrlTransform = GameObject.Find ("WillieMae");
        _BusckerTrigger = transform.Find("triggerBuscker").GetComponent<BusckerTrigger>();
    }
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

		bool isInFrontOfPlayer = true;
		Vector3 busckerScale = transform.localScale;

        if(_BusckerTrigger._detectPlayer && !_cooldown)
        {
            if (!isInFrontOfPlayer)
            {
                // ... instantiate the rocket facing right and set it's velocity to the right. 
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(speed, 0);

                _cooldown = true;
            }
            else
            {
                // Otherwise instantiate the rocket facing left and set it's velocity to the left.
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-speed, 0);

                _cooldown = true;
            }
        }

        if (_cooldown)
        {
            _count += Time.deltaTime;

            if(_count >= _projectileDelay)
            {
                _cooldown = false;
                _count = 0.0f;
            }
        }

		if (gameObject.transform.localPosition.x >= _playerCtrlTransform.transform.localPosition.x) {
			isInFrontOfPlayer = true;
			busckerScale.x = -(Mathf.Abs(transform.localScale.x));
			transform.localScale = busckerScale;
		} 
		if (gameObject.transform.localPosition.x < _playerCtrlTransform.transform.localPosition.x) {
			isInFrontOfPlayer = false;
			busckerScale.x = Mathf.Abs(transform.localScale.x);
			transform.localScale = busckerScale;
		}
    }
}

