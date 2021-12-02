using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MayorMovement : MonoBehaviour
{
    //public Vector3 target;
    public Transform[] waypoint;
    private Animator anim;
    private NavMeshAgent agent;
    private int i;
    private float minDistance = 2f;
    public Transform finalWaypoint;
    public float distance;
    public Transform player;
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
        if (distance <= 3)
        {
            anim.SetBool("Move", false);
            agent.SetDestination(transform.position);
        }
        else
        {
            anim.SetBool("Move", true);
            Move();
        }
        if (Vector3.Distance(finalWaypoint.transform.position, transform.position) < minDistance)
        {
            gameObject.SetActive(false);
        }
    }
    void Move()
    {
        if (i != waypoint.Length - 1)
        {
            if (Vector3.Distance(waypoint[i].transform.position, transform.position) < minDistance)
            {
                ++i;
            }
            anim.SetBool("Move", true);
            agent.SetDestination(waypoint[i].transform.position);
        }
    }
}
