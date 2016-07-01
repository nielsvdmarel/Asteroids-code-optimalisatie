using UnityEngine;
using System.Collections;

public class extaMovement : MonoBehaviour
{

    [SerializeField]
    private float startmoving;
    [SerializeField]
    private float moveAgain;
    [SerializeField]
    private float speed;

    private float X;
    private float Y;
    private Transform targetGet;
    private Vector2 targetSet;


    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");//de variabele player word gelijk aan het gameobject player
        targetGet = player.transform;
        InvokeRepeating("setNewTarget", startmoving, moveAgain);//laat de functie "setNewTarget" zich elke "moveAgain" seconden zich afspelen
        targetSet = new Vector2(this.transform.position.x, this.transform.position.y);//maat targetset gelijk aan de positie van de hunter
    }

    void Update()
    {
        this.GetComponent<EnemyfaceM>().target = player;//laat hem naar de player kijken door het script "EnemyfaceM"
        if (!player.GetComponent<Collider2D>().isTrigger)//als de player geen trigger is
        {
            transform.position = Vector2.MoveTowards(transform.position, targetSet, speed * Time.deltaTime);//gaat de hunter heel snel naar zijn target toe
        }
    }

    private void setNewTarget()//zet een nieuw target
    {
        if (!player.GetComponent<Collider2D>().isTrigger)//als de player geen trigger is 
        {
            //maar targetset gelijk aan targetget's values nadat de hunter heeft bewogen
            X = targetGet.position.x;
            Y = targetGet.position.y;
            targetSet = new Vector2(X, Y);
        }
    }
}
