using UnityEngine;
using System.Collections;

public class PlayerRespawnScript : MonoBehaviour
{

    public Vector2 spawn;

    private Rigidbody2D playerRigidbody;

    public bool shield;

    public AudioClip playerDieClip;

    private AudioSource audioSourceComponent;
    void Start()
    {
        audioSourceComponent = this.GetComponent<AudioSource>();
        playerRigidbody = this.GetComponent<Rigidbody2D>();
        if (spawn.x == 0 && spawn.y == 0)//als je het op nul houd
        {
            spawn = GameObject.Find("MoederBoord").transform.position;//respawnd de player in het moederboord
            this.GetComponent<Collider2D>().isTrigger = true;
        }
        this.transform.position = spawn;//start op het respawnpoint

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)//bij het raken van een trigger collider 
    {
        if (other.tag == "enemy")//als je een enemy raakt
        {
            if (!shield) {//als je geen shield hebt respawn je op het moederboord
                if (spawn.x == GameObject.Find("MoederBoord").transform.position.x && spawn.y == GameObject.Find("MoederBoord").transform.position.y)
                {
                    this.GetComponent<Collider2D>().isTrigger = true;
                    audioSourceComponent.PlayOneShot(playerDieClip, 1F);   
                }
                playerRigidbody.velocity = Vector2.zero;//zet de player stil
                this.transform.position = spawn;
            }
            else//als je wel een shield hebt heb je geen shield meer
            {
                shield = false;
                GameObject.Find("shield").GetComponent<shieldScript>().shield = false;
            }
        }

    }

}
    


