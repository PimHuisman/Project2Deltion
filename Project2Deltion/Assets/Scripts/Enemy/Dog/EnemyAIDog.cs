using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIDog : MonoBehaviour
{
    // NavMesh
    NavMeshAgent agent;
    //RagDoll
    [SerializeField] private GameObject[] body;
    [SerializeField] private GameObject ragDoll;

    void Update()
    {
        MeshCollider realenemy = transform.gameObject.GetComponent<MeshCollider>();
        bool dDead = transform.gameObject.GetComponent<EnemyHealth>().dead;
        if (dDead)
        {
            Destroy(realenemy);
            ragDoll.SetActive(true);
            //agent.isStopped = true;
            for (int i = 0; i < body.Length; i++)
            {
                body[i].transform.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
