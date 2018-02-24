using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    public GameObject explosion;        // Prefab of explosion effect.

    PlayerControl _WillieMaePlayerControl;
    GameController _GameController;

    private void Awake()
    {
        _WillieMaePlayerControl = GameObject.Find("WillieMae").GetComponent<PlayerControl>();
        _GameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Start()
    {
        // Destroy the rocket after 5 seconds if it doesn't get destroyed before then.
        Destroy(gameObject, 5);
    }


    void OnExplode()
    {
        // Create a quaternion with a random rotation in the z-axis.
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        // Instantiate the explosion where the rocket is with the random rotation.
        Instantiate(explosion, transform.position, randomRotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If it hits the player...
        if (other.tag == "Player")
        {
            // Call the explosion instantiation.
            OnExplode();

            // Destroy the rocket.
            Destroy(gameObject);

            if (_WillieMaePlayerControl.HP > 1)
            {
                // ... find WillieMae and decrease HP by 1.
                _WillieMaePlayerControl.HP--;
                _GameController.UpdateHP();
            }

            else if (_WillieMaePlayerControl.HP == 1)
            {
                _GameController.UpdateHP();
                _GameController.GameOver();
                other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        else if (other.tag == "Trigger" || other.tag == "Enemy")
        {

        }

        // Otherwise if the player manages to shoot himself...
        else if (other.gameObject.tag == "Obstacle" || other.tag == "Bullet")
        {
            // Instantiate the explosion and destroy the rocket.
            OnExplode();
            Destroy(gameObject);
        }
    }
}
