using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {


    public bool start = false;
    public float fadeDamp = 0.0f;
    public string fadeScene;
    public float alpha = 0.0f;
    public Color fadeColor;
    public bool isFadeIn = false;


	void Start () {

        

    }
	
	
	void OnGUI ()
    {
        // zorgt voor een pixel object dat het hele scherm enkele seconden doormiddel van een alpha laat faden

        if (!start)
            return;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        Texture2D mytex;
        mytex = new Texture2D(1, 1);
        mytex.SetPixel(0, 0, fadeColor);
        mytex.Apply();

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), mytex);
        if (isFadeIn)
            alpha = Mathf.Lerp(alpha, -0.1f, fadeDamp * Time.deltaTime);
        else
            alpha = Mathf.Lerp(alpha, 1.1f, fadeDamp * Time.deltaTime);


        if (alpha >= 1 && !isFadeIn)
        {
            
            Application.LoadLevel(fadeScene);
            DontDestroyOnLoad(gameObject);
            
        }
        else

        if (alpha <= 0 && isFadeIn)
        {
            Destroy(gameObject);
        }


	}

    void OnLevelWasLoaded(int level)
    {
        isFadeIn = true;
    }
}
