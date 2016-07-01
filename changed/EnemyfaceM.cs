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
        if (!hunter)//als het object niet de hunter is
        {
            if (this.GetComponent<EnemyMovement>().drone || hunter)//als het object een drone of hunter is
            {
                target = GameObject.Find("Player");//target de player
            }
            else if (target == null)//anders als het target niets is
            {
                target = GameObject.Find("MoederBoord");//target het moederboord
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

        float zAngel = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        if (extraTurn) { zAngel += 180; }
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngel);

        transform.rotation = Quaternion.RotateTowards ( transform.rotation, desiredRot , rotSpeed * Time.deltaTime);

        //testline

	}
}






