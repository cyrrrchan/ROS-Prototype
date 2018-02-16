using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneManBand : Enemy {

	enum State {Idle,
		Taunt,
		Attack};
	
	// Use this for initialization
	void Start () {
		State state; 

		state = State.Idle;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
