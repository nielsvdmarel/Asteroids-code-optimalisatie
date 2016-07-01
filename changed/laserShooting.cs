using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class laserShooting : MonoBehaviour {

    public GameObject headLaser;
    public int laserTime;
    public int laserTimeLeft;
    public bool lasersound;
    public AudioClip lasersoundClip;

    private Text lasertext;
    private GameObject[] lasers;
    private int laserCounter;
    private bool deleteLaser = false;
    private bool createLaser = false;
    private AudioSource audioSourceComponent;

    // Use this for initialization
    void Start() {
        audioSourceComponent = this.GetComponent<AudioSource>();
    }

    // Update speelt zich 1 keer per frame af
    void Update() {
        if (createLaser)//als hij een laser moet maken
        {
            instantiateLaser();//voer de functie "instantiateLaser" uit
        }
        else if(GameObject.FindGameObjectsWithTag("laser").Length > 0)//als er meer dan 1 laser is
        {
            GameObject[] allLasers = GameObject.FindGameObjectsWithTag("laser");//stop ze allemaal in een array
            Destroy(allLasers[allLasers.Length-1]);//sloop alle lasers 1 per keer dat de functie word aangeroepen
        }
        if(createLaser && laserTimeLeft > 0)//als hij een laser moet maken en er is nog tijd over met de laser
        {
            //zet de lasertijd viueel op de tijd die nog over is
            lasertext = GameObject.Find("laserTimer").GetComponent<Text>();
            lasertext.text = "" + laserTimeLeft;
        }
        else
        {
            lasertext.text = "";//maak de text van de laser leeg
        }

        if(GameObject.FindGameObjectsWithTag("laser").Length < 1)//als er geen lasers meer zijn
        {
            laserCounter = 1;//maak lasercount 1
            if (!lasersound)//zet het lasergeluid uit
            {
                audioSourceComponent.Stop();
                lasersound = true;
                CancelInvoke();
            }
        }

        if(GameObject.FindGameObjectsWithTag("laser").Length > 1 &&  lasersound)//als er een laser is
        {
            //start het laser geluid
            InvokeRepeating("lasershounds", 0, lasersoundClip.length-1f);
            lasersound = false;

        }

    }
    
    public int laserlengtget()//krijg de lengte van de laser
    {
        return laserCounter;
    }
    
    public void instantiateLaser()//maak de laser
    {
        Instantiate(headLaser);//maak de laser
        laserCounter++;//tel 1 op bij de totale hoeveelheid lasers
    }
    public void MinLaserCounter(int minLaser)//haal laser af van de totale hoeveelheid lasers
    {
        laserCounter -= minLaser;
    }
    public void LaserCounterEq(int laser)//maak de totale hoeveelheid lasers geleijk aan een getal
    {
        laserCounter = laser;
    }
    public void laserStart()//start de laser
    {
        if (createLaser) { createLaser = false; }//als createlaser waar is maak et dan niet waar
        else { createLaser = true; }//anders maak het waar
        laserTimeLeft = laserTime;//zet de lasertijd gelijk aan de begin tijd
        StartCoroutine(timerfunction());//start de timer functie
    }
    IEnumerator timerfunction()
    {
        while (laserTimeLeft > 0)//als laserTimeLeft meer is dan 0 dan
        {
            yield return new WaitForSeconds(1);//wacht 1 seconden
            laserTimeLeft -= 1;//haal 1 van laserTimeLeft af
        }
        if (laserTimeLeft == 0)//als er geen tijd meer over is
        {
            createLaser = false;//maak createlaser niet waar
        }
    }

    private void lasershounds()
    {
        audioSourceComponent.PlayOneShot(lasersoundClip, 1F);//speel het lasergeluid af
    }

}
