using UnityEngine;
using System.Collections;

public class laserscript : MonoBehaviour {

    public GameObject laser;
    private GameObject player = GameObject.Find("Player");

    public int staticLaserLength;

    void Start () {

         int laserlengt = GameObject.Find("muzzlepoint").GetComponent<laserShooting>().laserlengtget();//zet de lengte van de laser
        Transform playerT = GameObject.Find("Player").transform;//trijg de transform van de player
        Quaternion playerRotation = GameObject.Find("Player").transform.rotation;//krijg de rotation van de player

        staticLaserLength = laserlengt;//zet de leserleng vast

        this.transform.parent = GameObject.Find("muzzlepoint").transform;//word een child van muzzlepoint
        GameObject.Find("Player").transform.rotation = new Quaternion(0, 0, 0, 0);//maak de players rotation 0
        this.transform.rotation = new Quaternion(playerT.rotation.x, playerT.rotation.y, playerT.rotation.z, playerT.rotation.w);//maak de rotation gelijk aan de oude player rotation
        this.transform.position = new Vector2(playerT.position.x, playerT.position.y);//maak de position gelijk aan die van de player
        this.transform.position = new Vector2(playerT.position.x, playerT.position.y + 2 * staticLaserLength);//zet de laser op zijn plaats
        GameObject.Find("Player").transform.rotation = playerRotation;//zet de players rotation terug
        
    }
	
	void Update () {
        
    }

    public int getStaticLaser()//krijg de staticLaserLength
    {
        return staticLaserLength;
    }

    public void destroyLaser()
    {
            Destroy(gameObject);//sloop dit object
    }
    
}
