using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{


    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float backSpeed = 1f;
    [SerializeField]
    private float bounceDistance;//hoe ver de enemy terug gaat na het moederboord te raken
    [SerializeField]
    private float spawnDistance;//ongebruikt
    public bool drone;//of het object een drone is

    private Animator anim;
    private GameObject motherboard;
    private float minDistance = 1f;
    private float range;
    private float rangeSet;
    private int dronenum;
    private Transform target;


    public bool forward = false;



    void Start()
    {
        //als het een drone is target het moederboord anders voor dronespawn uit
        if (!drone)
        {
            motherboard = GameObject.Find("MoederBoord");
        }
        else
        {
            Dronespawn();
        }

        //zet alle variabele
        target = motherboard.transform;
        forward = true;
        backSpeed = -backSpeed;
    }


    void Update()
    {
        //zet de afstand tot het target
        range = Vector2.Distance(transform.position, target.position);

        //als de afstand verder is dan de range van de bouncedistance moet hij naar voren
        if (range > rangeSet + bounceDistance)
            forward = true;

        //als hij naar vooren moet (forward == true) dan moet dij de richting van het target op bewegen anders moet hij er vanaf bewegen
        if (forward == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, backSpeed * Time.deltaTime);
        }
    }


    public void setrange()//set de setrange variabele
    {
        rangeSet = Vector2.Distance(transform.position, target.position);
    }
    public void setTarget(Transform tar)//set het target
    {
        target = tar;
    }
    public void setDroneNumber(int Dronenum)//zet de hoeveelste drone het is
    {
        dronenum = Dronenum + 1;
    }
    private void Dronespawn()//maak de drones klaar, zet ze op spawn
    {
        string whichspawn = "DroneSpawn" + dronenum;
        this.transform.position = GameObject.Find(whichspawn).transform.position;
        this.transform.rotation = GameObject.Find(whichspawn).transform.rotation;
        motherboard = GameObject.Find("Player");
    }

}
