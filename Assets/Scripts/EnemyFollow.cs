using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public GameObject Player;

    public float radius;

    private Vector3 spawnLoc;

    [Range(0, 360)]
    public float angle;

    public LayerMask playerMask;
    public LayerMask obstacleMask;

    public bool playerVisible;


    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
        navAgent.speed = 50;
        radius = 50;
        angle = 60;
        StartCoroutine(FOVRoutine());
        playerVisible = false;
        //this.GetComponent<Renderer>().enabled = true;
        navAgent.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerVisible)
        {
            navAgent.destination = Player.transform.position;
            // navAgent.speed = 800 *Time.deltaTime;
            navAgent.speed = 8;
        }
        else
        {
            // Vector3 randomDirection = Random.insideUnitSphere * radius;
            navAgent.speed = 5;
            // randomDirection += transform.position;
            // NavMeshHit hit;
            // NavMesh.SamplePosition(randomDirection, out hit, radius, 1);
            // Vector3 finalPosition = hit.position;
            navAgent.destination = Player.transform.position;
        }
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }
    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, playerMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directon = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directon) < angle / 2)
            {
                float distance = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directon, distance, obstacleMask))
                {
                    playerVisible = true;
                }
                else
                {
                    playerVisible = false;
                }
            }
            else
            {
                playerVisible = false;
            }
        }
        else if (playerVisible)
        {
            playerVisible = false;
        }
    }
}
