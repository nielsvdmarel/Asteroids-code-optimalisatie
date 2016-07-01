using UnityEngine;
using System.Collections;

public class shieldScript : MonoBehaviour {

    public Color shieldOff;
    public Color shieldOn;

    public bool shield;

    void Update () {
        if (shield)//als het schild aan is
        {
            this.GetComponent<SpriteRenderer>().color = shieldOn;//krijgt hij een visueel schild
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = shieldOff;//anders niet
        }
	}
}
