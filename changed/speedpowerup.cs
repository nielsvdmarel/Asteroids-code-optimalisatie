using UnityEngine;
using System.Collections;

public class speedpowerup : MonoBehaviour
{

    public float Speeed;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")//als het een player raakt
        {
            //gaat het kapot en krijg de player een speed powerup
            other.GetComponent<pickupUseScript>().makeSpeedTrue();
            other.GetComponent<pickupUseScript>().setSpeed(Speeed);
            Destroy(gameObject);
             

        }

    }

    public void speedup(float speedchange)
    {
        //maak de player sneller
        GameObject.Find("Player").GetComponent<PlayerMovementAst>().ThrustForce += speedchange;
    }

}