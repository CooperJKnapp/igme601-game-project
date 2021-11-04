using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        if (current == null)
            current = this;
    }
    public event Action onSubwayGameTriggerEnter;
    public event Action onSubwayGameTriggerExit;
    public event Action onSubwayGameTriggerStart;
    public event Action onSubwayGameTriggerEnd;

    public event Action onFireAlarmGameTriggerEnter;
    public event Action onFireAlarmGameTriggerExit;
    public event Action onFireAlarmGameTriggerStart;
    public event Action onFireAlarmGameTriggerEnd;

    public event Action onTravelAgencyTriggerEnter;
    public event Action onTravelAgencyTriggerExit;
    public event Action onTravelAgencyTriggerStart;
    public event Action onTravelAgencyTriggerEnd;

    public void SubwayGameTriggerEnter()
    {
        if (onSubwayGameTriggerEnter != null)
        {
            onSubwayGameTriggerEnter();
        }
    }
    public void SubwayGameTriggerExit()
    {
        if (onSubwayGameTriggerExit != null)
        {
            onSubwayGameTriggerExit();
        }
    }

    public void SubwayGameTriggerStart()
    {
        if (onSubwayGameTriggerStart != null)
        {
            onSubwayGameTriggerStart();
        }
    }

    public void SubwayGameTriggerEnd()
    {
        if (onSubwayGameTriggerEnd != null)
        {
            onSubwayGameTriggerEnd();
        }
    }

    public void FireAlarmGameTriggerEnter()
    {
        if (onFireAlarmGameTriggerEnter != null)
        {
            onFireAlarmGameTriggerEnter();
        }
    }
    public void FireAlarmGameTriggerExit()
    {
        if (onFireAlarmGameTriggerExit != null)
        {
            onFireAlarmGameTriggerExit();
        }
    }

    public void FireAlarmGameTriggerStart()
    {
        if (onFireAlarmGameTriggerStart != null)
        {
            onFireAlarmGameTriggerStart();
        }
    }

    public void FireAlarmGameTriggerEnd()
    {
        if (onFireAlarmGameTriggerEnd != null)
        {
            onFireAlarmGameTriggerEnd();
        }
    }

    public void TravelAgencyGameTriggerEnter()
    {
        if (onTravelAgencyTriggerEnter != null)
        {
            onTravelAgencyTriggerEnter();
        }
    }

    public void TravelAgencyGameTriggerExit()
    {
        if (onTravelAgencyTriggerExit != null)
        {
            onTravelAgencyTriggerExit();
        }
    }
    public void TravelAgencyGameTriggerStart()
    {
        if (onTravelAgencyTriggerStart != null)
        {
            onTravelAgencyTriggerStart();
        }
    }
    public void TravelAgencyGameTriggerEnd()
    {
        if (onTravelAgencyTriggerEnd != null)
        {
            onTravelAgencyTriggerEnd();
        }
    }
}
