using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    void OnGui()
    {
        //zorgt dat het faden start, met een bepaalde tijd.
        //bepaalt texture van object dat ingefade wordt (fadeOutTexture)
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }


    // beginnen van de fade

        public float BeginFade (int direction)
    {
        
        fadeDir = direction;
        return (fadeSpeed);

    }
    // stopt de fade (start start de fade out)
    void onLevelWasLoaded()
    {
        BeginFade(-1);
    }

   


}

	

