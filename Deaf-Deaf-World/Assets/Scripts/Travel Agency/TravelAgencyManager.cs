using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelAgencyManager : MonoBehaviour
{
    public Text message;
    public GameObject turnIn;
    public GameObject lights;
    public basic_procedural_animation AgentAnimation;
    public string location = "Paris";
    public GameObject[] PosterLights;
    public Camera player_cam;

    private int ChosenPoster = -1;

    // Start is called before the first frame update
    void Start()
    {
        message.text = "Use Light to get the clerk's attention";
    }

    // Update is called once per frame
    void Update()
    {
        if (!lights.activeSelf)
        {
            AgentAnimation.awake = true;
        }
        if (AgentAnimation.awake)
        {
            message.text = "Use Light to show the clerk you want a ticket to " + location + " then buy a ticket";
            GetChosenPoster();
            if (ChosenPoster != -1)
                GetTicket();
        }
    }

    void GetChosenPoster()
    {
        ChosenPoster = -1;
        for(int i = 0; i < PosterLights.Length; i++)
        {
            if (PosterLights[i].activeSelf)
            {
                if (ChosenPoster == -1)
                {
                    ChosenPoster = i;
                }
                else
                {
                    ChosenPoster = -1;
                    break;
                }
            }
        }
    }

    void GetTicket()
    {
        // vectors we will need to tell if you are close and looking at the switch
        Vector3 look_vec = player_cam.transform.forward;
        Vector3 to_switch = AgentAnimation.GetComponent<Transform>().position - player_cam.transform.position;
        to_switch.y = 0;
        to_switch = Vector3.Normalize(to_switch);
        float distance = to_switch.magnitude;
        float cos_similarity = 0.8f;

        float max_dist = 3f;

        if (distance < max_dist && Vector3.Dot(look_vec, to_switch / distance) > cos_similarity)
        {
            if (Input.GetMouseButtonDown(0))
            {

            }
            turnIn.SetActive(true);
        }
        else
        {
            turnIn.SetActive(false);
        }
    }
}
