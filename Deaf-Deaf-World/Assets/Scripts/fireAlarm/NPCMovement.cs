using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    //public Vector3 target;
    public Transform[] waypoint;
    private Animator anim;
    private NavMeshAgent agent;
    private int i;
    private float minDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(!NPCInteract.NPCInteractInstance.isNPCinteractable)
        Move();
    }
    void Move()
    {
        if(i <= waypoint.Length - 1)
        {
            if (Vector3.Distance(waypoint[i].transform.position, transform.position) < minDistance)
            {
                ++i;
            }
            agent.SetDestination(waypoint[i].transform.position);
        }
        else if( i == waypoint.Length)
        {
            i = 0;
        }
    }
}
