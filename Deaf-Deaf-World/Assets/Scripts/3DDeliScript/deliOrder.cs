using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deliOrder : MonoBehaviour
{
    public Camera camera;
    public GameObject exitUI;
    public bool canOrder;


    // Update is called once per frame
    void Update()
    {
        if (canOrder)
            order();
    }


    public void order()
    {
        exitUI.GetComponent<Text>().text = "Click to order";

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
                //GameEvents.current.TravelAgencyGameTriggerEnd();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("Subway");
            }
        }
        else
        {
            exitUI.SetActive(false);
        }
    }
}
