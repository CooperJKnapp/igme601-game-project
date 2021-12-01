using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evacuate : MonoBehaviour
{
    private Animator anim;
    public GameObject receptionist;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Receptionist").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "receptionist")
        {
            receptionist.SetActive(false);
            anim.SetBool("walk", false);
        }
    }
}
