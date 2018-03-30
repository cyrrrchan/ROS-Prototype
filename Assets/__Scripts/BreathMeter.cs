﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class BreathMeter : MonoBehaviour {

    public int playerId = 0; // The Rewired player id of this character
    private Player player; // The Rewired Player

    [HideInInspector]
    public bool _isEmpty = false;

    private Image _meterImage;

	PlayerControl _WillieMaePlayerControl;

	[SerializeField] int _segments;
	[SerializeField] float _time;
    [SerializeField] float _emptyCooldownDuration;

	private float _meterFilled = 1.0f;
	private float _segmentSize;
    private float _count = 0.0f;

    private void Awake()
    {
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerId);
    }

    // Use this for initialization
    void Start () {
		_WillieMaePlayerControl = GameObject.Find ("WillieMae").GetComponent<PlayerControl> ();

		_meterImage = GetComponent<Image> ();
		_meterImage.fillAmount = _meterFilled;
		_segmentSize = 1f / _segments;
	}

	// Update is called once per frame
	void Update () {

		if ((player.GetButtonDown("Shoot_Square") || player.GetButtonDown("Shoot_Triangle") || player.GetButtonDown("Shoot_Circle")) && _WillieMaePlayerControl._isBreathing && !_isEmpty)
		{
			_meterImage.fillAmount -= _segmentSize;
		}

		else if (!_WillieMaePlayerControl._isBreathing && _meterImage.fillAmount != 1f && !_isEmpty) //fill meter when LShift or L2 is not held
		{
			_meterImage.fillAmount += Time.deltaTime / _time;
		}

        if (_meterImage.fillAmount <= 0.0f && !_isEmpty)
        {
            Debug.Log("Empty");
            _isEmpty = true;
            _count = 0.0f;
        }

        _count += Time.deltaTime;
        if (_isEmpty && _count >= _emptyCooldownDuration)
        {
            Debug.Log("Not Empty Anymore");
            _isEmpty = false;
        }
	}
}
