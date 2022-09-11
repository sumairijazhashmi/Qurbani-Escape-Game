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

    private void Start()
    {
        enemyFollow = GetComponent<EnemyFollow>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        // try to grab bakri
        if(Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) <= 2.0f)
        {
            animator.SetBool("playerCross", true);
        }
        
        // run after bakri
        if ((Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) <= 1.5f))
        {
            
            enemyFollow.attach2npc = true;
        }

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
