using UnityEngine;
using System.Collections;

public class randomspawn : MonoBehaviour {

    public float spawnDistance;
    public bool pickup;
    public float randomRange;

    // Use this for initialization
    void Start () {

        if (spawnDistance == 0) { spawnDistance = GameObject.Find("enemies").GetComponent<waveScript>().spawndistance; }//als spawn nul word gelaten word het een algemeen spawn punt

        float random = Random.Range(0, 100);//random word een random getal tussen nul en 100

        if (pickup) { spawnDistance = Random.Range(spawnDistance, spawnDistance + randomRange); }//als het een pickup is spawnen ze niet op 1 lijn

        //deze ifs vormen 4 lijnen waarop ze random kunnen spawnwn
        if (random < 25 && random > 0) { transform.position = new Vector2(Random.Range(spawnDistance, -spawnDistance), spawnDistance); }//
        else if (random < 50 && random > 25) { transform.position = new Vector2(Random.Range(spawnDistance, -spawnDistance), -spawnDistance); }
        else if (random < 75 && random > 50) { transform.position = new Vector2(spawnDistance, Random.Range(spawnDistance, -spawnDistance)); }
        else if (random < 100 && random > 75) { transform.position = new Vector2(-spawnDistance, Random.Range(spawnDistance, -spawnDistance)); }


    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
