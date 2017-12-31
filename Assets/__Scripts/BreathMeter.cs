using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathMeter : MonoBehaviour {

	private Image _meterImage;

	PlayerControl _WillieMaePlayerControl;
	//Gun _TrumpetGun;

	[SerializeField] int _segments;
	[SerializeField] float _time;

	private float _meterFilled = 1f;
	private float _segmentSize;

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

		if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) && _WillieMaePlayerControl._isBreathing)
		{
			_meterImage.fillAmount -= _segmentSize;
		}

		else if (!_WillieMaePlayerControl._isBreathing && _meterImage.fillAmount != 1f)
		{
			_meterImage.fillAmount += Time.deltaTime / _time;
		}
	}
}
