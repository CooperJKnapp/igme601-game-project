using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenElevator : MonoBehaviour
{
    private Animator anim;
    private fireAlarm FireAlarm;
    private GameObject receptionist;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        receptionist = GameObject.Find("Receptionist");
        FireAlarm = GameObject.Find("Fire Alarm Controller").GetComponent<fireAlarm>();
        StartCoroutine(OpenDoors());
    }

    // Update is called once per frame
    void Update()
    {
        if (FireAlarm.timeUp && !receptionist.activeInHierarchy)
        {
            anim.SetBool("Open Doors", false);
        }
    }
    IEnumerator OpenDoors()
    {
        yield return new WaitForSeconds(3);
        anim.SetBool("Open Doors", true);
    }
}
