using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneTransition : MonoBehaviour
{
    public GameObject text;
    private fireAlarm FireAlarm;
    private BoxCollider bc;
    public Animator anim;
    private Mayor mayor;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        //FireAlarm = GameObject.Find("Fire Alarm Controller").GetComponent<fireAlarm>();
        mayor = GameObject.Find("Mayor").GetComponent<Mayor>();
        bc.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(mayor.hasMayor == true)
        {
            bc.enabled = true;
            if (Input.GetKeyDown(KeyCode.F) && text.activeInHierarchy)
            {
                anim.SetBool("Open Doors", true);
                StartCoroutine(Exit());
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        text.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    { 
        text.SetActive(false);
    }
    IEnumerator Exit()
    {
        yield return new WaitForSeconds(2);
        GameEvents.current.FireAlarmGameTriggerEnd();
    }
}
