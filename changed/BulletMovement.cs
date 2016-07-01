using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

    [SerializeField] private float BulletForce;//kracht de achter de bullet komt
    [SerializeField] private float bulletLifetime;//totalen levenstijd 

    private float life;//overgebleven levenstijd
    private Rigidbody2D Rigidbody2D;//rigidbody van de bullet

    void Start()
    {
        life = bulletLifetime;//life wor de totale levenstijd
        Rigidbody2D = GetComponent<Rigidbody2D>();//krijg de rigidbody van de bullet
        Rigidbody2D.velocity = GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity;//maak de snelheid van de bullet even snel als die van de player
        Rigidbody2D.AddForce(transform.up * BulletForce);//set een kracht achter de bullet

    }

    void Update()
    {
        life -= Time.deltaTime;//haal de tijd af van de overgebleven levenstijd van de bullet
        if (life < 0)//als de tijd op is
        {
            Destroy(gameObject);//destroy de bullet
        }
    }
  
    
}
