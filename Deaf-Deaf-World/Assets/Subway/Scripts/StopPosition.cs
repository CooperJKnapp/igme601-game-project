using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPosition : MonoBehaviour
{
    public string stopString;
    private bool triggerControl = false;

	private void OnTriggerStay2D(Collider2D collision)
	{
        if (!triggerControl)
        {
            stopString = collision.transform.name;
            collision.transform.GetChild(0).gameObject.SetActive(true);
            triggerControl = true;
        }
        
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        stopString = "";
        collision.transform.GetChild(0).gameObject.SetActive(false);
        triggerControl = false;
    }
}
