using UnityEngine;
using System.Collections;

public class laserbeamp : MonoBehaviour
{



    void OnTriggerEnter2D(Collider2D other)//op aanraking met een trigger
    {
        if (other.tag == "Player")//als het aanraking is met de player
        {
            Destroy(gameObject);//sloop het gameobject
            other.GetComponent<pickupUseScript>().makeLaserTrue();//maak laser bruikbaar als pickup
        }

    }
}