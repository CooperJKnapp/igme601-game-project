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
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        //transform.position = waypoint[i].transform.position;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Vector3.Distance(finalWaypoint.transform.position, transform.position) < minDistance)
        {
            gameObject.SetActive(false);
        }
    }
    void Move()
    {
        if (i <= waypoint.Length - 1)
        {
            if (Vector3.Distance(waypoint[i].transform.position, transform.position) < minDistance)
            {
                ++i;
            }
            anim.SetBool("walk", true);
            agent.SetDestination(waypoint[i].transform.position);
        }
    }
}
