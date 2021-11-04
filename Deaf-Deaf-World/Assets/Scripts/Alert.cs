using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alert : MonoBehaviour
{
    public fireAlarm FireAlarm;
    public Mayor mayor;
    public GameObject text;
    public float distance;
    public Transform target;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);
        if (FireAlarm.timeUp)
        {
            if (Input.GetKeyDown(KeyCode.F) && text.activeInHierarchy)
            {
                mayor.enabled = true;   
            }
            if (distance <= 2)
            {
                text.SetActive(true);
            }
            else
            {
                text.SetActive(false);
            }
        }
    }




    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }

}
