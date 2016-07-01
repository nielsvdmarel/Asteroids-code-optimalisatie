using UnityEngine;
using System.Collections;

public class laserStopScript : MonoBehaviour {
    void OnTriggerStay2D(Collider2D other)//op aanraking van een collider
    {
        if (other.tag == "laser")//als de aanraking is met een laser
        {
            int laserNumber = other.GetComponent<laserscript>().staticLaserLength;//kijk de hoeveelste laser het is
            GameObject[] lasers = GameObject.FindGameObjectsWithTag("laser");//zet alle lasers is een array
            
            for (int i = 0; i < lasers.Length; i++)//voor elke laser doe
            {
                if (lasers[i].GetComponent<laserscript>().staticLaserLength > laserNumber)//als de laser hoger is dan lasernuber
                {
                    Destroy(lasers[i]);//vernietig de laser
                    GameObject.Find("muzzlepoint").GetComponent<laserShooting>().LaserCounterEq(laserNumber);//maak de lengte van de laser gelijk aan de hoeveelste lser aan was geraakt
                }
            }
        }

    }
}
