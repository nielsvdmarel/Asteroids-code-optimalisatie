using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class healthScript : MonoBehaviour {

    private bool first;
    private Animator anim;
    public float maxHealth;
    public float minHealth;
    public bool boss;
    public GameObject enemies;
    public GameObject drone;
    public float dronehealthloss;
    private AudioSource audioSourceComponent;
    public AudioClip EnemyHitClip;
    public string scene3;

    private float dronespawnhealth;
    private GameObject[] droneSpawned;
    

    public float currentHealth;

	
	void Start () {
        EnemyHitClip = GameObject.Find("Audio Source").GetComponent<audioHolder>().hit;//krijg het sound voor als je gehit word
        audioSourceComponent = this.GetComponent<AudioSource>();//krijg de audio source
        first = true;
        enemies = GameObject.Find("enemies");// krijg het gameobject enemies
        currentHealth = maxHealth;//maak het current health gelijk aan het max health
        //Destroy(gameObject);
        anim = GetComponent<Animator>();
    }

    void Update () {
        if (!boss)//als het object niet de boss is
        {
            if (currentHealth < minHealth)//als het health dat het object lager is dan het minimalen health
            {
                //speel animatie af
                anim.SetBool("attack", false);
                anim.SetBool("die", true);
                //sloop het object na 6 seconden (tijd voor de animatie)
                Object.Destroy(gameObject, .6f);//
                if (first)//als first true is
                {
                    enemies.GetComponent<waveScript>().enemmiesDiedPlus();//tel 1 op bij de dode enemies
                    first = false;//maak first false
                }
            }
        }

        else if (boss)//als het object de "boss" is
        {
            //alle ifs hier zijn reacties op een bepaalde hoeveelheid leven
            if( currentHealth < maxHealth / 4 * 3 && currentHealth > maxHealth / 2)//drie kwart
            {
                targetPlayer();//ga naar de player toe
            }
            if (currentHealth < maxHealth / 2 - dronespawnhealth && currentHealth > maxHealth / 4)//half
            {
                spawnDrones(4);//spawn 4 drones
                dronespawnhealth += dronehealthloss;
            }
            if(currentHealth < maxHealth / 4 && currentHealth > minHealth)//een kwart
            {
                targetMoederboord();//ga weer naar het moederboord toe
            }
            if (currentHealth < minHealth)//geel leven meer
            {
                Destroy(gameObject);//sloop het object
                Initiate.Fade(scene3, Color.black, 0.5f);//start de fade
                //SceneManager.LoadScene("Win");
                GameObject.Find("Audio Source").GetComponent<backgroudSound>().clip = 2;//zet de clip is backgroundsound naar 2
                GameObject.Find("Audio Source").GetComponent<backgroudSound>().win = true;//zet win in backgroundsound

            }
        }

        if (gameObject.GetComponent<EnemyMovement>().forward)//animaties
        {
            anim.SetBool("attack", true);
        }

        else
        {
            anim.SetBool("attack", false);
        }

    }

    void OnTriggerEnter2D(Collider2D other)//als er een trigger in het object komt
    {
        if (other.tag == "bullet")//als het object een bullet is
        {
            Destroy(other.gameObject);//sloop de bullet
            currentHealth -= other.GetComponent<bulletCollision>().damage;//krijg de damage van de bullet
            audioSourceComponent.PlayOneShot(EnemyHitClip, 0.7F);//speel audio af
        }
        if (other.tag == "laser")//als het een laser is
        {
            anim.SetBool("die", true);//start death animation
            Object.Destroy(gameObject, 0.5f);//sloop gameobject na een halve seconde
            if (first)//als first  waar is
            {
                enemies.GetComponent<waveScript>().enemmiesDiedPlus();//tel een enemy op bij de dode enemies
                first = false;//maak first false
            }
        }
    }
    private void targetPlayer()
    {
        this.GetComponent<EnemyMovement>().setTarget(GameObject.Find("Player").transform);//ga richting de player
        //this.GetComponent<EnemyMovement>().forward = true;//ga direct naar voren als hij naar de player gaat
        this.GetComponent<EnemyfaceM>().target = GameObject.Find("Player");//kijk richting de player
    }
    private void targetMoederboord()
    {
        this.GetComponent<EnemyMovement>().setTarget(GameObject.Find("MoederBoord").transform);//ga richting het moederboord
        this.GetComponent<EnemyfaceM>().target = GameObject.Find("MoederBoord");//kijk righting het moederboord
    }
    private void spawnDrones(int AmountOfDrones)//spawn de drones
    {
        for (int i = 0; i < AmountOfDrones; i++)//voor hoe vaak er een drone gespawn moet worden
        {
            int droneNumber = i;//geef een dronenomer
            if(droneNumber > 3)//als er meer drones moeten dan 4 (tellen begint bij 0: 0,1,2,3)
            {
                droneNumber = droneNumber % 4;//zorg dat je alleen 1,2,3 en 4 hebt
            }
            Instantiate(drone).GetComponent<EnemyMovement>().setDroneNumber(droneNumber);//spawn de drone
        }
    }

}
