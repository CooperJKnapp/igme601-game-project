using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Mayor : MonoBehaviour
{
    public fireAlarm FireAlarm;
    public Transform target;
    public NavMeshAgent agent;
    public Animator anim;
    public float distance;
    public float normalizedTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);
        if(distance <= 20f)
        {
            StartCoroutine(WaitForAnimation());
            

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    IEnumerator WaitForAnimation()
    {
        anim.SetBool("Sitting", true);
        yield return new WaitForSeconds(2);
        anim.SetBool("walk", true);
        agent.SetDestination(target.position);

        if (distance >= 20f)
        {
            agent.SetDestination(transform.position);
            anim.SetBool("walk", false);
        }
        if (distance <= 2f)
        {
            agent.SetDestination(transform.position);
            anim.SetBool("walk", false);
        }
    }
}
