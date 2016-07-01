using UnityEngine;
using System.Collections;

public class bulletsShooting : MonoBehaviour
{

    [SerializeField]
    private GameObject BulletPrefab;//de prefab van de bullet
    [SerializeField]
    private AudioClip[] bulletSounds;//de geluiden van de bullet
    private AudioSource audioSourceComponent;//het deel dat geluiden afspeeld

    void Start()
    {
        audioSourceComponent = this.GetComponent<AudioSource>();//krijg het audioSource Component van muzzlepoint
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))//als linker muisknop word ingedrukt
        {
            if (GameObject.FindGameObjectsWithTag("laser").Length < 1)//als er geen lasers zijn
            {
                Instantiate(BulletPrefab, transform.position, transform.rotation);//zet de bullet in het spel
                audioSourceComponent.PlayOneShot(bulletSounds[Random.Range(0, 3)], 0.7F);//speel 1 van de geluiden af
            }
        }
    }
}
