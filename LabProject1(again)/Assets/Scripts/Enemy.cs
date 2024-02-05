using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public List<Vector3> patrolPoints;
    public NavMeshAgent agent;

    private GameObject player;
    private int patrolPointIndex;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            agent.SetDestination(player.transform.position);
        }
        else
        {
            if (Vector3.Distance(transform.position, patrolPoints[patrolPointIndex]) < 1)
            {
                patrolPointIndex++;
                print("Reached Destination and getting next point");
                if (patrolPointIndex >= patrolPoints.Count)
                {
                    patrolPointIndex = 0;
                }
            }

            if (agent.destination != patrolPoints[patrolPointIndex])
            {
                agent.SetDestination(patrolPoints[patrolPointIndex]);
                print("Setting Destination");
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player = null;
        }
    }

    public void takeDamage()
    {
        gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        for (int i = 1; i < patrolPoints.Count; i++)
        {
            Gizmos.DrawLine(patrolPoints[i - 1], patrolPoints[i]);
        }

        Gizmos.DrawLine(patrolPoints[patrolPoints.Count - 1], patrolPoints[0]);
    }
}
