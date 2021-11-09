using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPosition : MonoBehaviour
{
    public string stopString;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        stopString = collision.transform.name;
        Debug.Log(collision.transform.name);
	}
}
