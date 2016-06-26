using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    public string scene;

	
	void Start () {
	
	}
	
	//zorgt voor een test button waarmee je de start van de scene fade kon laten beginnen (geen scene verandering!)
	void OnGUI () {
	    if (GUI.Button(new Rect(-100, 0, 0,0),""))
        {
            Initiate.Fade(scene, Color.black, 0.5f);
        }
	}
}
