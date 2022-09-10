using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent navAgent;
    [SerializeField] float speed;
    [SerializeField] public GameObject Player;
    public float radius;

    [Range(0, 360)]
    public float angle;

    public LayerMask playerMask;
    public LayerMask obstacleMask;

    public bool playerVisible;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navAgent.speed = speed;
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
    private void FixedUpdate()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, forward, out hit, 4f))
        {
            if(hit.collider.tag == "obstacle")
            {
                animator.SetBool("jump", true);
            }
        }
        // stop animation over here once it is completed
    }
}
