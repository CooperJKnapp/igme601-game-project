using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public KeyCode _key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            //GameEvents.current.TravelAgencyGameTriggerEnd();
        }
    }
}
