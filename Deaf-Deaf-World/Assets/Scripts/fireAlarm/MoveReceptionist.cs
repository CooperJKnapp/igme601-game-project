using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveReceptionist : MonoBehaviour
{
    public Vector3 target;
    public Transform exitTransform;
    private Animator anim;
    private fireAlarm FireAlarm;
    private NavMeshAgent agent;
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        FireAlarm = GameObject.Find("Fire Alarm Controller").GetComponent<fireAlarm>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        target = new Vector3(exitTransform.position.x, exitTransform.position.y, exitTransform.position.z);
        if (FireAlarm.timeUp)
        {
            StartCoroutine(Wait());
            go.SetActive(true);
        }
    }
    IEnumerator Wait()
    {
        anim.SetBool("Sitting", true);
        yield return new WaitForSeconds(2);
        anim.SetBool("walk", true);
        agent.SetDestination(target);
    }
}
