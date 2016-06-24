using UnityEngine;
using System.Collections;

public class CamerFollow : MonoBehaviour {

    public Transform target;
    Camera mycam;
    public float Camera_follow_speed = 1.0f;
    public float zoomSize = 5;
	
	void Start ()
    {
        // component camera krijgen
        mycam = GetComponent<Camera>();
	}


    void Update()
    {

        //mycam.orthographicSize = (Screen.height / 100f / .5f); // dit bepaalt camera grote

        if (target)
        {
            //zorgt ervoor dat de camera de target volgt, met een standaard z waarde van -10
            transform.position = Vector3.Lerp(transform.position, target.position, Camera_follow_speed) + new Vector3(0, 0, -10);
        }

        // als e wordt ingedurkt zoomt de camera in
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (zoomSize > 2)
                zoomSize -=1;
        }
        
        // als e wordt ingedurkt zoomt de camera uit
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (zoomSize < 35)
                zoomSize += 1;

        }



        GetComponent<Camera>().orthographicSize = zoomSize;


	}
}
