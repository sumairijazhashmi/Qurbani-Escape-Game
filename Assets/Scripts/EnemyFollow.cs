using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent navAgent;
    [SerializeField] float speed;
    [SerializeField] public Player Player;
    public float radius;



    public bool playerVisible;
    public bool attach2npc = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "npc" && attach2npc == false)
        {
            return;
        }
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
        navAgent.speed = speed;
        radius = 50;
        navAgent.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "npc" && attach2npc == true)
        {
            Start();
        }

        if (gameObject.tag == "npc" && attach2npc == false)
        {
            return;
        }
        navAgent.destination = Player.transform.position;
        
        navAgent.Raycast(Vector3.forward, out NavMeshHit navHit);
    }


}
