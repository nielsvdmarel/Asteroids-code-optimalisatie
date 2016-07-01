using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class waveScript : MonoBehaviour
{

    public int enemiesDied;
    public int wave;
    public int total;

    public int maxEnemies;
    public float spawndistance;
    public float waveStartDelay;
    public float[] enemySpawnDelay;

    public int waves;

    public GameObject[] pickups;

    public float[] speed;
    public float[] shield;
    public float[] health;
    public float[] laser;

    public GameObject[] Enemies;
    public GameObject hunterObject;
    public GameObject boss;
    

    
    public int[] enemy1;
    public int[] enemy2;
    public int[] enemy3;
    public int[] hunter;

    public bool playercanmove = false;

    
    
    private SpriteRenderer backColorRenderer;
    private float enemyCounter;
    private float timeBeforeWave;
    private Text wavetimer;



    void Start()
    {
        total = enemy1[wave] + enemy2[wave] + enemy3[wave] + hunter[wave];//de totalen hoeveelheid enemies in de wave
        wavetimer = GameObject.Find("waveTimer").GetComponent<Text>();//telt af voor de wave
        timeBeforeWave = waveStartDelay;

        InvokeRepeating("spawn", waveStartDelay, Random.Range(enemySpawnDelay[0], enemySpawnDelay[1]));//enemies blijven spawnen
        enemyCounter = 0;//hoe veel enemies er in het veld zijn
        wave = 0;//de hoeveelste wave het is
        StartCoroutine(timerfunction());//start de timer

    }


    void Update()
    {
        

        pickUps();//spawn de pickups voor de wave
        if (enemyCounter == total)//als alle enemies in de wave zijn gespawnd
        {
            CancelInvoke();//stop met het spawnen van enemies
            if (enemiesDied == total)//als alle enemies dood zijn
            {
            wave++;//volgende wave
                if (wave == waves)//als alle waves over zijn
                {
                    enemyCounter = -1;//de hoeveelheid enemies die gespawnd zijn word -1 (zodat de nieuwe wave niet begind)
                    Instantiate(boss);//spawn de boss
                    GameObject.Find("Audio Source").GetComponent<backgroudSound>().clip = 3;//start boss audio
                } else {//als nog neit alle waves over zijn
                    GameObject[] allPickUps = GameObject.FindGameObjectsWithTag("pickup laserbeam");//zet alle pickups in een array (alle pickups hebben als tag "pickup laserbeam"
                    for (int i = 0; i < allPickUps.Length; i++)//vernietig alle pickups
                    {
                        Destroy(allPickUps[i]);
                    }
                    timeBeforeWave = waveStartDelay;//zet de afteltijd weer goed
                    StartCoroutine(timerfunction());//start met aftellen
                    total = enemy1[wave] + enemy2[wave] + enemy3[wave] + hunter[wave];//zet total weer naar alle enemies in de wave
                    InvokeRepeating("spawn", waveStartDelay, Random.Range(enemySpawnDelay[0], enemySpawnDelay[1]));//start het spawnen van enemies
                    pickUps();//zet alle pickups voor de wave
                    enemyCounter = 0;//zet de hoeveelheid gespawnde enemies op 0
                    enemiesDied = 0;//zet de hoeveelheid dode enemies op 0
                }

            }
        }
        }
    private void spawn()//spawn de enemies
    {
        if (GameObject.FindGameObjectsWithTag("enemy").Length < maxEnemies+1)//als de hoeveelheid enemies nog niet aan de max zit
        {
            int totalSpawn = enemy1[wave] + enemy2[wave] + enemy3[wave] + hunter[wave];//krijg het totaal aan enemies de deze wave nog moeten spawnen
            float random = Random.Range(1, totalSpawn);//random word een getal tussen 1 en het totalen aantal enemies die moeten spawnen

            //zet alle kans dat die enemy spawnd even groot als de hoeveelheid enemies die daarvan nog in die wave moeten spawnen
            float enemy1c = enemy1[wave];//kans dat enemy 1  spawnd is als random zit tussen 0 en de hoeveelheid van enemy 1 die nog moet spawnen
            float enemy2c = enemy2[wave] + enemy1c;
            float enemy3c = enemy3[wave] + enemy2c;
            float hunterc = hunter[wave] + enemy2c;

            //checkt welke enemy moet spawnen
            if (random < enemy1c + 1)
            {
                enemyCounter++;
                Instantiate(Enemies[0]);
                enemy1[wave] -= 1;
            }
            if (random < enemy2c + 1 && random > enemy1c)
            {
                enemyCounter++;
                Instantiate(Enemies[1]);
                enemy2[wave] -= 1;
            }
            if (random < enemy3c + 1 && random > enemy2c)
            {
                enemyCounter++;
                Instantiate(Enemies[2]);
                enemy3[wave] -= 1;
            }
            if (random < hunterc + 1 && random > enemy3c)
            {
                enemyCounter++;
                Instantiate(hunterObject);
                hunter[wave] -= 1;
            }
        }
    }
    private void pickUps()//spawnd de pickups
    {
        int total = speed.Length + health.Length + laser.Length + shield.Length;
        
            if(speed[wave] > 0) { speed[wave] -= 1; Instantiate(pickups[3]); }
            if (health[wave] > 0) { health[wave] -= 1; Instantiate(pickups[0]); }
            if (laser[wave] > 0) { laser[wave] -= 1; Instantiate(pickups[1]); }
            if (shield[wave] > 0) { shield[wave] -= 1; Instantiate(pickups[2]); }
        
    }
    public void enemmiesDiedPlus()//telt 1 op bij dode enemies
    {
        enemiesDied++;
    }

    IEnumerator timerfunction()//telt de timer voor de wave af
    {
        while (timeBeforeWave > 0)
        {
            yield return new WaitForSeconds(1);
            timeBeforeWave -= 1;
            wavetimer.text = "" + timeBeforeWave;
        }

        if (timeBeforeWave == 0)
        {
            playercanmove = true;
            wavetimer.text = "";
            
        }
    }


}
