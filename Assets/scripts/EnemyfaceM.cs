using UnityEngine;
using System.Collections;

public class EnemyfaceM : MonoBehaviour {

   public float rotSpeed = 90f;
    public bool hunter;
    public bool extraTurn;

    Transform MoederBoord;
    public GameObject target;

    void Start ()
    {
        if (!hunter)
        {
            if (this.GetComponent<EnemyMovement>().drone || hunter)
            {
                target = GameObject.Find("Player");
            }
            else if (target == null)
            {
                target = GameObject.Find("MoederBoord");
            }
        }
    }
	
	void Update ()
    {
       
	   
            GameObject go = target;

            if(go != null)
            {
                MoederBoord = go.transform;
            }
        
        if (MoederBoord == null)
            return;

        
        Vector3 dir = MoederBoord.position - transform.position;
        dir.Normalize();

        //bepaald hoe groot de hoek is wat heb object moet draaien naar een ander object(target). 
        float zAngel = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        if (extraTurn) { zAngel += 180; }
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngel);

        //zorgt voor de movement van de rotatie
        transform.rotation = Quaternion.RotateTowards ( transform.rotation, desiredRot , rotSpeed * Time.deltaTime);

        //testline

	}
}
