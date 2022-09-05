using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("here");
            Destroy(gameObject);
        }
    }
}
