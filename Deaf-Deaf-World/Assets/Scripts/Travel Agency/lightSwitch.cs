using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{
    public GameObject lights;
    public GameObject player_cam;
    public float max_dist = 2f;
    public float cos_similarity = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // vectors we will need to tell if you are close and looking at the switch
            Vector3 look_vec = player_cam.transform.forward;
            Vector3 to_switch = transform.position - player_cam.transform.position;
            float distance = to_switch.magnitude;

            if (distance < max_dist && Vector3.Dot(look_vec, to_switch/distance) > cos_similarity)
            {
                // toggles the lights
                lights.SetActive(!lights.activeSelf);
            }
        }
    }
}
