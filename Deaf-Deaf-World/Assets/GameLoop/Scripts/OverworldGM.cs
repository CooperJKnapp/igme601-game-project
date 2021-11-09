using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldGM : MonoBehaviour
{
    [SerializeField]
    GameManager GameManagerReference;

    [SerializeField]
    GameObject SubwayTriggerArea;

    [SerializeField]
    GameObject FireAlarmTriggerArea;

    [SerializeField]
    GameObject TravelAgencyTriggerArea;

    private void Awake()
    {
        GameManagerReference = GameObject.FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManagerReference.isTravelAgencyDone)
        {
            TravelAgencyTriggerArea.SetActive(false);
            FireAlarmTriggerArea.SetActive(true);

        }
     


        //if (GameManagerReference.isTravelAgencyDone && GameManagerReference.isSubwayDone)
        //{
        //    FireAlarmTriggerArea.SetActive(true);
        //}
        //else
        //{
        //    if (GameManagerReference.isSubwayDone)
        //    {
        //        SubwayTriggerArea.SetActive(false);
        //    }
        //    else if (GameManagerReference.isFireAlarmDone)
        //    {
        //        FireAlarmTriggerArea.SetActive(false);
        //    }
        //    else if (GameManagerReference.isTravelAgencyDone)
        //    {
        //        TravelAgencyTriggerArea.SetActive(false);
        //    }
        //}
    }
}
