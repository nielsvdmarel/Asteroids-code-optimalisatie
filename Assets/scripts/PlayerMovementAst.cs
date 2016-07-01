using UnityEngine;
using System.Collections;

public class PlayerMovementAst : MonoBehaviour
{

    public float RotationSpeed;
    public float ThrustForce;
    public float defaultspeed;


    public float breakforce;

    private Rigidbody2D Rigidbody2D;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        defaultspeed = ThrustForce;//maak de defaultspeed gelijk aan de thrustforce
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (GameObject.Find("enemies").GetComponent<waveScript>().playercanmove)//als de player kan bewegen
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))//als er a werd ingedrukt
            {

                //Rigidbody2D.angularVelocity = RotationSpeed;
                Rigidbody2D.AddForce(transform.right * -ThrustForce);//ga naar links
            }

            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))//als d word ingedrukt
            {

                //Rigidbody2D.angularVelocity = -RotationSpeed;
                Rigidbody2D.AddForce(transform.right * ThrustForce);//ga naar rechts
            }
            else
            {
                Rigidbody2D.angularVelocity = 0f;//ga nergens naar toe
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))//als w word ingedrukt ga naar voren
            {
                Rigidbody2D.AddForce(transform.up * ThrustForce);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))//als s word ingedrukt, ga naar achteren
            {
                Rigidbody2D.AddForce(transform.up * -ThrustForce);
            }

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightControl))//rem op leftshift
            {
                Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x / breakforce, Rigidbody2D.velocity.y / breakforce);
            }
        }
    }
}
