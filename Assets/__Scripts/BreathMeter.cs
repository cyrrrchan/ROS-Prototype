using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class BreathMeter : MonoBehaviour {

    public int playerId = 0; // The Rewired player id of this character
    private Player player; // The Rewired Player

    private Image _meterImage;

	PlayerControl _WillieMaePlayerControl;
	//Gun _TrumpetGun;

	[SerializeField] int _segments;
	[SerializeField] float _time;

	private float _meterFilled = 1f;
	private float _segmentSize;

    private void Awake()
    {
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerId);
    }

    // Use this for initialization
    void Start () {
		_WillieMaePlayerControl = GameObject.Find ("WillieMae").GetComponent<PlayerControl> ();
		//_TrumpetGun = GameObject.Find ("Trumpet").GetComponent<Gun> ();

		_meterImage = GetComponent<Image> ();
		_meterImage.fillAmount = _meterFilled;
		_segmentSize = 1f / _segments;
	}

	// Update is called once per frame
	void Update () {

		if ((player.GetButtonDown("Shoot_Square") || player.GetButtonDown("Shoot_Triangle") || player.GetButtonDown("Shoot_Circle")) && _WillieMaePlayerControl._isBreathing)
		{
			_meterImage.fillAmount -= _segmentSize;
		}

		else if (!_WillieMaePlayerControl._isBreathing && _meterImage.fillAmount != 1f)
		{
			_meterImage.fillAmount += Time.deltaTime / _time;
		}
	}
}
