using UnityEngine;
using System.Collections;

public class RocketCircle : MonoBehaviour
{
    public GameObject explosion;		// Prefab of explosion effect.
    [SerializeField] int _damage;

    Trumpet _Trumpet;
    BreathMeter _BreathMeter;

    void Start()
    {
        _Trumpet = GameObject.Find("Trumpet").GetComponent<Trumpet>();
        _BreathMeter = GameObject.Find("breathMeterUI").GetComponent<BreathMeter>();

        // Destroy the rocket after 2 seconds if it doesn't get destroyed before then.
        Destroy(gameObject, 2);
    }


    void OnExplode()
    {
        _Trumpet._circleIsHit = true;

        // Create a quaternion with a random rotation in the z-axis.
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        // Instantiate the explosion where the rocket is with the random rotation.
        Instantiate(explosion, transform.position, randomRotation);


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // If it hits an enemy...
        if (col.tag == "Buscker")
        {
            // ... find the Enemy script and call the Hurt function.
            //col.gameObject.GetComponent<Enemy>().Hurt();
            col.gameObject.GetComponent<Buscker>().Hurt(_damage);
            _BreathMeter._hitEnemy = true;

            // Call the explosion instantiation.
            OnExplode();

            // Destroy the rocket.
            Destroy(gameObject);
        }
        // Otherwise if it hits a bomb crate...
        else if (col.tag == "OneManBand")
        {
            // if OneManBand is taunting when attacked, enter attack state
            if (col.gameObject.GetComponent<OneManBand>()._enemyState == OneManBand.State.Taunt)
            {
                // Destroy the rocket.
                Destroy(gameObject);

                col.gameObject.GetComponent<OneManBand>()._enemyState = OneManBand.State.Attack;
            }

            // if OneManBand is not taunting, do damage on OneManBand
            else
            {
                // ... find the Enemy script and call the Hurt function.
                col.gameObject.GetComponent<OneManBand>().Hurt(_damage);

                // Call the explosion instantiation.
                OnExplode();

                // Destroy the rocket.
                Destroy(gameObject);
            }
        }

        else if (col.tag == "Trigger")
        {

        }

        // Otherwise if the player manages to shoot himself...
        else if (col.tag == "Obstacle")
        {
            // Instantiate the explosion and destroy the rocket.
            OnExplode();
            Destroy(gameObject);
        }
    }
}
