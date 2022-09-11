using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCLogic : MonoBehaviour
{
    Animator animator;
    //public bool setFollow = false;
    public Player player;
    public EnemyFollow enemyFollow;
    public GameObject go; // obstacle
    RaycastHit hit;

    private void Start()
    {
        enemyFollow = GetComponent<EnemyFollow>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        animator.SetBool("obstacle", false);


        // try to grab bakri
        if (Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) <= 2.0f)
        {
            animator.SetBool("playerCross", true);
        }

        // run after bakri
        if ((Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) <= 1.5f))
        {

            enemyFollow.attach2npc = true;
        }

        hit = new RaycastHit();
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f) || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 3f) || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 3f) || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 3f) || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, 3f) || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 3f))
        {

            print("here");

            if (hit.collider.tag == "obstacle")
            {
                animator.SetBool("obstacle", true);

            }
        }

        // jump if obj = obstacle
        //if (go.tag == "obstacle" && (Mathf.Abs(Vector3.Distance(transform.position, go.transform.position)) <= 1.5f))
        //{
        //    print("here");
        //    animator.SetBool("obstacle", true);
        //}



    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
            {
            //Debug.Log("here");
            // follow player
            //setFollow = true;
            animator.SetBool("playerHit", true);
           
            
            //Destroy(gameObject);
        }

    }



 

}
