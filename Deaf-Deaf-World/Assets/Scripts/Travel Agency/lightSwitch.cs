using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightSwitch : MonoBehaviour
{
    public GameObject lights;
    public GameObject player_cam;
    public GameObject tip;
    public float max_dist = 2f;
    private float cos_similarity = 0.8f;
    public bool flip = true;
    private bool last = true;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // vectors we will need to tell if you are close and looking at the switch
        Vector3 look_vec = player_cam.transform.forward;
        Vector3 to_switch = transform.position - player_cam.transform.position;
        float distance = to_switch.magnitude;

        if (distance < max_dist && Vector3.Dot(look_vec, to_switch/distance) > cos_similarity)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // toggles the lights
                lights.SetActive(!lights.activeSelf);
                if (flip)
                {
                    Vector3 newScale = transform.localScale;
                    newScale.y *= -1;
                    transform.localScale = newScale;
                }
            }
            tip.SetActive(true);
            last = true;
        }
        else
        {
            if (last)
            {
                tip.SetActive(false);
            }
            last = false;
        }
    }
}
