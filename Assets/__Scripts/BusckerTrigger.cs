using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusckerTrigger : MonoBehaviour {

    public bool _detectPlayer = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _detectPlayer = true;
            //Debug.Log(_detectPlayer);
        }

        else
        {

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _detectPlayer = false;
            // Debug.Log(_detectPlayer);
        }

        else
        {

        }
    }
}
