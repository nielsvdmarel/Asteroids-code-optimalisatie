using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {

    public string scene;

    public void NielsTestScene()
    {
       //zorgt ervoor dat de fade van de scene start.
        Initiate.Fade(scene, Color.black, 0.5f);
    }

    
}
