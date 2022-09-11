using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    private NPCLogic npc;
    private EnemyFollow enemyFollow;

    private void Start()
    {
        npc = GetComponent<NPCLogic>();
        enemyFollow = GetComponent<EnemyFollow>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //EnemyFollow newEnemy = gameObject.AddComponent<EnemyFollow>() as EnemyFollow;
        }
    }
}
