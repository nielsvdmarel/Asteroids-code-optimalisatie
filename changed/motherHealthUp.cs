using UnityEngine;
using System.Collections;

public class motherHealthUp : MonoBehaviour
{
    public bool procent;
    public float amount;

    void OnTriggerEnter2D(Collider2D other)//op aanraking met een trigger
    {
        if (other.tag == "Player")//als de aanraking is mer een player
        {
            Destroy(gameObject);//vernietig het object
            float motherHealth = GameObject.Find("MoederBoord").GetComponent<motherHealthScript>().currentHealth;//krijg de health van het moedervoord
            float motherMaxHealth = GameObject.Find("MoederBoord").GetComponent<motherHealthScript>().maxHealth;//krijg de maxheath van het moederboord
            if (procent)//moet het is procenten of aantallen worden gerekend
            {
                GameObject.Find("MoederBoord").GetComponent<motherHealthScript>().currentHealth += motherMaxHealth / 100 * amount;//tel heath op in procenten
            }
            else
            {
                GameObject.Find("MoederBoord").GetComponent<motherHealthScript>().currentHealth += amount;//tel heath op in aantallen
            }

        }


    }
}
