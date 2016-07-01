using UnityEngine;
using System.Collections;

public class shieldAddon : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")//als het een player raakt 
        {
            Destroy(gameObject);//gaat het kapot
            //krijgt het player een schild
            GameObject.Find("Player").GetComponent<PlayerRespawnScript>().shield = true;
            GameObject.Find("shield").GetComponent<shieldScript>().shield = true;
        }

    }

}