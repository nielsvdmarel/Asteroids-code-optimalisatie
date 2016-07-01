using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class motherHealthScript : MonoBehaviour
{

    public float maxHealth;
    public float minHealth;

    public float currentHealth;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;//zet health tot max
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxHealth)//als het health hoger is dan het max dan maak het gelijk aan het max
        {
            currentHealth = maxHealth;
        }

        if (currentHealth < minHealth)//als het health minder is dan het minimalen health
        {
            Destroy(gameObject);// vernietig het object
            GameObject.Find("Audio Source").GetComponent<backgroudSound>().clip = 2;//zet de variabele "clip" in backgroudSound op 2
            GameObject.Find("Audio Source").GetComponent<backgroudSound>().win = false;// zet de variabele "win" in backgroudSound op false
        }
    }
    void OnTriggerEnter2D(Collider2D other)//op aanraking van een trigger
    {
        if (other.tag == "enemy")//als de aanraking is met een "enemy"
        {
            currentHealth -= other.GetComponent<motherDamageScript>().Motherdamage;//haal de enemy's motherdamage van het heath af
            //other.GetComponent<EnemyMovement>.forward = false;
            other.GetComponentInParent<EnemyMovement>().forward = false;//laat de enemy achteruit gaan voor een nieuwe aanval
            other.GetComponentInParent<EnemyMovement>().setrange();//set de range van de enemy

            if (other.GetComponentInParent<EnemyMovement>().drone)//als het een drone is
            {
                Destroy(other.gameObject);//vernieting de drone
            }
        }
        if (other.tag == "bullet")//als de aanraking is met een bullet
        {
            Destroy(other.gameObject);//vernietig de bullet
        }
    }
    void OnTriggerExit2D(Collider2D other)//als de aanraking
    {
        if (other.tag == "Player")//met de player is afgelopen
        {
            other.GetComponent<Collider2D>().isTrigger = false;//is de player geen trigger meer
        }
    }
}
