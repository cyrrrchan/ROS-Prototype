using UnityEngine;
using System.Collections;
using Rewired;

public class Trumpet : MonoBehaviour
{
    public int playerId = 0; // The Rewired player id of this character
    private Player player; // The Rewired Player

    public Rigidbody2D rocketSquare;				// Prefab of the rocket.
    public Rigidbody2D rocketTriangle;
    public Rigidbody2D rocketCircle;
    public float speed = 20f;				// The speed the rocket will fire at.

    public AudioClip _comboHit;

    public string _rtpcIDTrumpetSquare;
    public string _rtpcIDTrumpetTriangle;
    public string _rtpcIDTrumpetCircle;
    public string _rtpcIDEnemyHit;
    public float _comboCooldownDurationBeats;

    [HideInInspector]
    public bool _squareIsHit = false;
    [HideInInspector]
    public bool _triangleIsHit = false;
    [HideInInspector]
    public bool _circleIsHit = false;

	private PlayerControl _playerCtrl;		// Reference to the PlayerControl script.
	private Animator _anim;					// Reference to the Animator component.
    private float _count = 0.0f;
    private float _comboCooldownDuration;
    private float _enemyCount = 0.0f;       // Count for projectile hitting enemies.
    private float _enemyCountDuration;

    PlayerControl _WillieMaePlayerControl;
    Metronome _Metronome;
    BreathMeter _BreathMeter;


	void Awake()
	{
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerId);

        AkSoundEngine.SetRTPCValue(_rtpcIDTrumpetSquare, 0.0f);
        AkSoundEngine.SetRTPCValue(_rtpcIDTrumpetTriangle, 0.0f);
        AkSoundEngine.SetRTPCValue(_rtpcIDTrumpetCircle, 0.0f);
        AkSoundEngine.SetRTPCValue(_rtpcIDEnemyHit, 0.0f);

        // Setting up the references.
        _anim = transform.root.gameObject.GetComponent<Animator>();
		_playerCtrl = transform.root.GetComponent<PlayerControl>();

		_WillieMaePlayerControl = GameObject.Find ("WillieMae").GetComponent<PlayerControl>();
        _Metronome = GameObject.Find("MetronomeUI").GetComponent<Metronome>();
        _BreathMeter = GameObject.Find("breathMeterUI").GetComponent<BreathMeter>();

        _comboCooldownDuration = (60.0f / _Metronome._bpm) * _comboCooldownDurationBeats;
        _enemyCountDuration = (60.0f / _Metronome._bpm) * 4;

    }


    void Update()
    {
        bool buttonPressed = false;

        // If the square button is pressed...
        if (player.GetButtonDown("Shoot_Square") && _WillieMaePlayerControl._isBreathing && !_BreathMeter._isEmpty)
        {
            buttonPressed = true;
            // ... set the animator Shoot trigger parameter and play the audioclip.
            _WillieMaePlayerControl.anim.SetTrigger("Shoot");
            //AkSoundEngine.PostEvent ("Play_TrumpetSingleHit", gameObject);
            AkSoundEngine.SetRTPCValue(_rtpcIDTrumpetSquare, 100f);
            AkSoundEngine.SetRTPCValue(_rtpcIDTrumpetTriangle, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcIDTrumpetCircle, 0.0f);
            _count = 0.0f;

            // If the player is facing right...
            if (_playerCtrl.facingRight)
            {
                // ... instantiate the rocket facing right and set it's velocity to the right. 
                Rigidbody2D bulletInstance = Instantiate(rocketSquare, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(speed, 0);
            }
            else
            {
                // Otherwise instantiate the rocket facing left and set it's velocity to the left.
                Rigidbody2D bulletInstance = Instantiate(rocketSquare, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-speed, 0);
            }
        }

        // If the triangle button is pressed...
        else if (player.GetButtonDown("Shoot_Triangle") && _WillieMaePlayerControl._isBreathing && !_BreathMeter._isEmpty)
        {
            buttonPressed = true;
            // ... set the animator Shoot trigger parameter and play the audioclip.
            _WillieMaePlayerControl.anim.SetTrigger("Shoot");
            //AkSoundEngine.PostEvent ("Play_TrumpetSingleHit", gameObject);
            AkSoundEngine.SetRTPCValue(_rtpcIDTrumpetTriangle, 100f);
            AkSoundEngine.SetRTPCValue(_rtpcIDTrumpetSquare, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcIDTrumpetCircle, 0.0f);
            _count = 0.0f;

            // If the player is facing right...
            if (_playerCtrl.facingRight)
            {
                // ... instantiate the rocket facing right and set it's velocity to the right. 
                Rigidbody2D bulletInstance = Instantiate(rocketTriangle, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(speed, 0);
            }
            else
            {
                // Otherwise instantiate the rocket facing left and set it's velocity to the left.
                Rigidbody2D bulletInstance = Instantiate(rocketTriangle, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-speed, 0);
            }
        }

        // If the circle button is pressed...
        else if (player.GetButtonDown("Shoot_Circle") && _WillieMaePlayerControl._isBreathing && !_BreathMeter._isEmpty)
        {
            buttonPressed = true;
            // ... set the animator Shoot trigger parameter and play the audioclip.
            _WillieMaePlayerControl.anim.SetTrigger("Shoot");
            //AkSoundEngine.PostEvent ("Play_Combo_HotAndSweet", gameObject);
            AkSoundEngine.SetRTPCValue(_rtpcIDTrumpetCircle, 100f);
            AkSoundEngine.SetRTPCValue(_rtpcIDTrumpetTriangle, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcIDTrumpetSquare, 0.0f);
            _count = 0.0f;

            // If the player is facing right...
            if (_playerCtrl.facingRight)
            {
                // ... instantiate the rocket facing right and set it's velocity to the right. 
                Rigidbody2D bulletInstance = Instantiate(rocketCircle, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(speed, 0);
            }
            else
            {
                // Otherwise instantiate the rocket facing left and set it's velocity to the left.
                Rigidbody2D bulletInstance = Instantiate(rocketCircle, transform.position, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-speed, 0);
            }
        }

        if (buttonPressed)
        {
            _count = 0.0f;
        }

        if(_squareIsHit)
        {
            _enemyCount = 0.0f;
            AkSoundEngine.SetRTPCValue(_rtpcIDEnemyHit, 100.0f);
            _squareIsHit = false;
        }

        if(_triangleIsHit)
        {
            _enemyCount = 0.0f;
            AkSoundEngine.SetRTPCValue(_rtpcIDEnemyHit, 100.0f);
            _triangleIsHit = false;
        }

        if (_circleIsHit)
        {
            _enemyCount = 0.0f;
            AkSoundEngine.SetRTPCValue(_rtpcIDEnemyHit, 100.0f);
            _circleIsHit = false;
        }
   
        _count += Time.deltaTime; //timer for combo cooldown
        if (_count >= _comboCooldownDuration)
        {
            AkSoundEngine.SetRTPCValue(_rtpcIDTrumpetSquare, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcIDTrumpetTriangle, 0.0f);
            AkSoundEngine.SetRTPCValue(_rtpcIDTrumpetCircle, 0.0f);
        }

        _enemyCount += Time.deltaTime; //timer for projectile hitting enemies
        if (_enemyCount >= _enemyCountDuration)
        {
            AkSoundEngine.SetRTPCValue(_rtpcIDEnemyHit, 0.0f);
        }
    }
}
