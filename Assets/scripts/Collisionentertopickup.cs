using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Collisionentertopickup : MonoBehaviour{

    public string scene;

    void OnCollisionEnter2D(Collision2D coll)
    {

       
        // laat het scherm weg faden met de kleur zwart
        Initiate.Fade(scene, Color.black, 0.5f);


    }


}
