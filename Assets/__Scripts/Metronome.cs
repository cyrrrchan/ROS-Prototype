using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Metronome : MonoBehaviour {

    public float _bpm;
    public Color _colorOn;
    public Color _colorOff;
    public Image _metronomeUI01;
    public Image _metronomeUI02;
    public Image _metronomeUI03;
    public Image _metronomeUI04;

    private float _bpmInSeconds;
    private bool _metronome = true;

    private float _nextTime;

    // Use this for initialization
    void Start ()
    {
        _metronomeUI01.color = _colorOff;
        _metronomeUI02.color = _colorOff;
        _metronomeUI03.color = _colorOff;
        _metronomeUI04.color = _colorOff;

        _bpmInSeconds = 60.0f / _bpm;
        _nextTime = Time.time;

        StartCoroutine(MetronomeStart());
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    private IEnumerator MetronomeStart()
    {
        SwitchColor();
        Debug.Log("Tick");
        _nextTime += _bpmInSeconds;
        yield return new WaitForSeconds(_nextTime - Time.time);
        StartCoroutine(MetronomeStart());
    }

    void SwitchColor()
    {
        if (_metronomeUI01.color == _colorOn)
        {
            _metronomeUI01.color = _colorOff;
            _metronomeUI02.color = _colorOn;
        }

        else if (_metronomeUI02.color == _colorOn)
        {
            _metronomeUI02.color = _colorOff;
            _metronomeUI03.color = _colorOn;
        }

        else if (_metronomeUI03.color == _colorOn)
        {
            _metronomeUI03.color = _colorOff;
            _metronomeUI04.color = _colorOn;
        }

        else if (_metronomeUI04.color == _colorOn)
        {
            _metronomeUI04.color = _colorOff;
            _metronomeUI01.color = _colorOn;
        }

        else if (_metronomeUI01.color == _colorOff && _metronomeUI02.color == _colorOff && _metronomeUI03.color == _colorOff && _metronomeUI04.color == _colorOff)
        {
            _metronomeUI01.color = _colorOn;
        }
    }
}
