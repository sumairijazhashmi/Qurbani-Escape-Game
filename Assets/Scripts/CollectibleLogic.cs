using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleLogic : MonoBehaviour
{
    Animator animator;
    public bool setFollow = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        //Debug.Log("here");
    //        animator.SetBool("playerHit", true);
    //        //Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("here");
            // follow player
            //setFollow = true;
            animator.SetBool("playerHit", true);

            //Destroy(gameObject);
        }
    }

}
