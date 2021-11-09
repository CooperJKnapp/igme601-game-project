using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenElevator : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(OpenDoors());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator OpenDoors()
    {
        yield return new WaitForSeconds(3);
        anim.SetBool("Open Doors", true);
    }
}
