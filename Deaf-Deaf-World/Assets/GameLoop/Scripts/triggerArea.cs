using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerArea : MonoBehaviour
{
    public KeyCode _keyTriggerArea;

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == GameVariables.Tasks.Subway.ToString())
            GameEvents.current.SubwayGameTriggerEnter();
        else if (this.gameObject.tag == GameVariables.Tasks.TravelAgency.ToString())
            GameEvents.current.TravelAgencyGameTriggerEnter();
        else if (this.gameObject.tag == GameVariables.Tasks.MeetTheMayor.ToString())
            GameEvents.current.FireAlarmGameTriggerEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject.tag == GameVariables.Tasks.Subway.ToString())
            GameEvents.current.SubwayGameTriggerExit();
        else if (this.gameObject.tag == GameVariables.Tasks.TravelAgency.ToString())
            GameEvents.current.TravelAgencyGameTriggerExit();
        else if (this.gameObject.tag == GameVariables.Tasks.MeetTheMayor.ToString())
            GameEvents.current.FireAlarmGameTriggerExit();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(_keyTriggerArea))
        {
            if (this.gameObject.tag == GameVariables.Tasks.Subway.ToString())
                GameEvents.current.SubwayGameTriggerStart();
            else if (this.gameObject.tag == GameVariables.Tasks.TravelAgency.ToString())
                GameEvents.current.TravelAgencyGameTriggerStart();
            else if (this.gameObject.tag == GameVariables.Tasks.MeetTheMayor.ToString())
                GameEvents.current.FireAlarmGameTriggerStart();
        }
    }
}
