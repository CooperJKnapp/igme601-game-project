using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour
{
    public GameObject text;
    private StandUp standUp;
    // Start is called before the first frame update
    void Start()
    {
        standUp = GameObject.Find("Player").GetComponent<StandUp>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            text.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            text.SetActive(false);
            standUp.enabled = false;
        }
    }
}
