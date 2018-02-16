using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneManBand : Enemy {

	enum State {Idle,
		Taunt,
		Attack};
    State _enemyState;

    private float _count = 0.0f;
    public float _tauntCooldown;

    // Use this for initialization
    void Start () {
		_enemyState = State.Idle;
	}
	
	// Update is called once per frame
	void Update () {
		if (_enemyState == State.Idle)
        {
            _count += Time.deltaTime;
            if (_count >= _tauntCooldown)
            {
                _enemyState = State.Taunt;
                _count = 0.0f;
            }
        }

        else if (_enemyState == State.Taunt)
        {
            Debug.Log("Taunt");
            _enemyState = State.Idle;
        }
	}
}
