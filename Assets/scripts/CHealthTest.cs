using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CHealthTest : MonoBehaviour {

    public Scrollbar HealthBar;
    public float Health = 5000;

    public void Damage(float value)
    {
        //health value (5000) wordt minder wanneer Damage getriggerd wordt 
        //healthbar groote wordt horizontaal minder met bepaalde waarde. 
        //Health -= value;
        //HealthBar.size = Health / 5000f;

        // hierboven is voor een handmatige damage knop. 

    }

    void Update()
    {
        // zorgt ervoor dat de health gelijk is aan de waarde van current health (motherHealthScript)
       Health = GameObject.Find("MoederBoord").GetComponent<motherHealthScript>().currentHealth;
        //dit zorgt ervoor dat als er damage wordt gedaan, dit wordt gedeeld door maxHealth (motherHealthScript)
        HealthBar.size = Health / GameObject.Find("MoederBoord").GetComponent<motherHealthScript>().maxHealth;
    }


	



}
