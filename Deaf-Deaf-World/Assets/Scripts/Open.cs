using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
public class Open : MonoBehaviour
{
    public GameObject text;
    private fireAlarm FireAlarm;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        FireAlarm = GameObject.Find("Fire Alarm Controller").GetComponent<fireAlarm>();
    }

    // Update is called once per frame
    void Update()
    {

        if (FireAlarm.timeUp && text.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetBool("Open", true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            text.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            text.SetActive(false);
        }
    }

}
