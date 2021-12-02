using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerArea : MonoBehaviour
{
    public KeyCode _keyTriggerArea;
    public GameObject instructions;

    GameManager GameManagerReference;

    private void Awake()
    {
        GameManagerReference = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Debug enters the player");
            //print("Debug find this " + other.transform.parent.gameObject.name);
            if (this.gameObject.tag == GameVariables.Tasks.Subway.ToString())
                GameEvents.current.SubwayGameTriggerEnter();
            else if (this.gameObject.tag == GameVariables.Tasks.TravelAgency.ToString())
                GameEvents.current.TravelAgencyGameTriggerEnter();
            else if (this.gameObject.tag == GameVariables.Tasks.MeetTheMayor.ToString() && GameManager.gameManagerInstance.isSubwayDone && GameManager.gameManagerInstance.isTravelAgencyDone)
            {
                print("Debug enters the condition city hall");
                GameEvents.current.FireAlarmGameTriggerEnter();

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.tag == GameVariables.Tasks.Subway.ToString())
                GameEvents.current.SubwayGameTriggerExit();
            else if (this.gameObject.tag == GameVariables.Tasks.TravelAgency.ToString())
                GameEvents.current.TravelAgencyGameTriggerExit();
            else if (this.gameObject.tag == GameVariables.Tasks.MeetTheMayor.ToString())
            {
                print("Debug exitt the condition city hall");
                GameEvents.current.FireAlarmGameTriggerExit();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Debug stay the player");
            if (instructions != null && GameManagerReference.isSubwayDone && GameManagerReference.isTravelAgencyDone)
            {
                instructions.SetActive(true);
            }
            if (Input.GetKey(_keyTriggerArea))
            {
                print("Debug stay player and key");
                if (this.gameObject.tag == GameVariables.Tasks.Subway.ToString())
                    GameEvents.current.SubwayGameTriggerStart();
                else if (this.gameObject.tag == GameVariables.Tasks.TravelAgency.ToString())
                    GameEvents.current.TravelAgencyGameTriggerStart();
                else if (this.gameObject.tag == GameVariables.Tasks.MeetTheMayor.ToString() &&
                    GameManagerReference.isSubwayDone && GameManagerReference.isTravelAgencyDone)
                {
                    
                    GameEvents.current.FireAlarmGameTriggerStart();

                }
                // else

                //print(" tag " + gameObject.tag + " sub " + GameManagerReference.isSubwayDone + " travel  " + GameManagerReference.isTravelAgencyDone);

            }
        }
    }
}
