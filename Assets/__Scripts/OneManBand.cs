using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneManBand : Enemy {

	public enum State {Idle,
		Taunt,
		Attack};
    public State _enemyState;

    private float _count = 0.0f;
    public float _idleDuration;
    public float _tauntDuration;

    // Use this for initialization
    void Start () {
		_enemyState = State.Idle;
	}
	
	// Update is called once per frame
	void Update () {
		if (_enemyState == State.Idle)
        {
            Debug.Log("Idle");

            _count += Time.deltaTime;
            if (_count >= _idleDuration)
            {
                _enemyState = State.Taunt;
                _count = 0.0f;
            }
        }

        else if (_enemyState == State.Taunt)
        {
            Debug.Log("Taunt");

            _count += Time.deltaTime;
            if (_count >= _tauntDuration)
            {
                _enemyState = State.Idle;
                _count = 0.0f;
            }
        }

        else if (_enemyState == State.Attack)
        {
            Debug.Log("Attack");
            _enemyState = State.Idle;
        }
	}
}
