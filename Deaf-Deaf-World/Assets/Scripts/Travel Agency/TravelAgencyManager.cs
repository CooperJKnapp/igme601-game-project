using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TravelAgencyManager : MonoBehaviour
{
    public Text message;
    public RectTransform ticket;
    public Text ticketText;
    public GameObject turnIn;
    public GameObject lights;
    public Transform door;
    public basic_procedural_animation AgentAnimation;
    public string location = "Paris";
    public GameObject[] PosterLights;
    public Camera player_cam;
    private string[] destinations = {"New York City", "Las Vegas", "Chichen Iza", "Tokyo", "Giza", "Paris"};
    private string destination;
    private bool ticketChosen = false;
    private int ChosenPoster = -1;
    private float flyByTimer = 0;
    private bool removeTicket = false;

    // Start is called before the first frame update
    void Start()
    {
        message.text = "Use Light to get the clerk's attention";
    }

    // Update is called once per frame
    void Update()
    {
        if (ticketChosen)
        {
            ticketFlyBy();
        }
        else
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
    }

    void ticketFlyBy()
    {
        Vector3 TicketPos = new Vector3(Screen.width / 2, Mathf.Lerp(-Screen.height / 3, Screen.height * 4/3f, flyByTimer), 0);
        ticket.position = TicketPos;

        if (flyByTimer < 1/2f)
            flyByTimer += Time.deltaTime / 4;
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                removeTicket = true;
                turnIn.SetActive(false);
            }
            if (removeTicket)
                if (flyByTimer < 1)
                    flyByTimer += Time.deltaTime / 4;
                else
                    exitDoor();
        }
    }

    void exitDoor()
    {
        turnIn.GetComponent<Text>().text = "Click to exit";

        Vector3 look_vec = player_cam.transform.forward;
        Vector3 to_switch = door.position - player_cam.transform.position;
        to_switch.y = 0;
        float distance = to_switch.magnitude;
        float cos_similarity = 0.8f;

        float max_dist = 3f;

        if (distance < max_dist && Vector3.Dot(look_vec, to_switch / distance) > cos_similarity)
        {
            turnIn.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("");
            }
        }
        else
        {
            turnIn.SetActive(false);
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
        if (ChosenPoster != -1)
            destination = destinations[ChosenPoster];
    }

    void GetTicket()
    {
        // vectors we will need to tell if you are close and looking at the switch
        Vector3 look_vec = player_cam.transform.forward;
        Vector3 to_switch = AgentAnimation.GetComponent<Transform>().position - player_cam.transform.position;
        to_switch.y = 0;
        float distance = to_switch.magnitude;
        float cos_similarity = 0.8f;

        float max_dist = 3f;

        if (distance < max_dist && Vector3.Dot(look_vec, to_switch / distance) > cos_similarity)
        {
            turnIn.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                ticketChosen = true;
                ticketText.text = destination;
                turnIn.GetComponent<Text>().text = "Click to continue";
                message.text = "Return the ticket to the Mayor";
            }
        }
        else
        {
            turnIn.SetActive(false);
        }
    }
}
