using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public GameObject Player;
    public float radius;

    [Range(0, 360)]
    public float angle;

    public LayerMask playerMask;
    public LayerMask obstacleMask;

    public bool playerVisible;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = 1;
        radius = 50;
        angle = 60;
        //this.GetComponent<Renderer>().enabled = true;
        navAgent.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
            navAgent.destination = Player.transform.position;
    }
}
