using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StandUp : MonoBehaviour
{
    private fireAlarm FireAlarm;
    public GameObject go;
    public Transform cam;
    public NavMeshAgent agent;
    public Transform target;
    public float yVal;
    public FirstPersonController fpsController;
    // Start is called before the first frame update
    void Start()
    {
        //agent.enabled = true;
        fpsController.canWalk = false;
        FireAlarm = GameObject.Find("Fire Alarm Controller").GetComponent<fireAlarm>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FireAlarm.timeUp)
        {
            go.SetActive(true);
        }
        // try OnCollision Enter for showing the text.
        if (FireAlarm.timeUp && go.activeInHierarchy)
        {
            go.SetActive(true);
            agent.enabled = true;
            if (Input.GetKeyDown(KeyCode.F))
            {
                fpsController.canWalk = true;
                agent.SetDestination(target.position);
                cam.Translate(0f, yVal, 0f);
                go.SetActive(false);
                agent.enabled = false;
            }
        }

    }
}
