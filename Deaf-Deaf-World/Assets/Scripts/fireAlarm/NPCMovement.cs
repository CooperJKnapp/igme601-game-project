using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    //public Vector3 target;
    public Transform[] waypoint;
    public Transform player;
    private Animator anim;
    private NavMeshAgent agent;
    private int i;
    private float minDistance = 2f;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if(distance <= 3)
        {
            anim.SetBool("Move", false);
            agent.SetDestination(transform.position);
        }
        else
        {
            anim.SetBool("Move", true);
            Move();
        }
    }
    void Move()
    {
        if(i <= waypoint.Length - 1)
        {
            if (Vector3.Distance(waypoint[i].transform.position, transform.position) < minDistance)
            {
                ++i;
            }
            if (i == waypoint.Length)
            {
                i = 0;
            }
            agent.SetDestination(waypoint[i].transform.position);
        }
        else if( i == waypoint.Length)
        {
            i = 0;
        }
    }
}
