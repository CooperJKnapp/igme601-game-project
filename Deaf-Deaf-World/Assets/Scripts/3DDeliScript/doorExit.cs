using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class doorExit : MonoBehaviour
{
    public Camera camera;
    public GameObject exitUI;
    public bool canExit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canExit)
            exitDoor();
    }


    void exitDoor()
    {
        exitUI.GetComponent<Text>().text = "Click to exit";

        Vector3 look_vec = camera.transform.forward;
        Vector3 to_switch = transform.position - camera.transform.position;
        to_switch.y = 0;
        float distance = to_switch.magnitude;
        float cos_similarity = 0.8f;

        float max_dist = 3f;

        if (distance < max_dist && Vector3.Dot(look_vec, to_switch / distance) > cos_similarity)
        {
            exitUI.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                GameEvents.current.SubwayGameTriggerEnd();
                //SceneManager.LoadScene("Overworld");
            }
        }
        else
        {
            exitUI.SetActive(false);
        }
    }
}
