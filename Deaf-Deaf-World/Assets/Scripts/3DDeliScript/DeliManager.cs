using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliManager : MonoBehaviour
{
    //[Header("Pathways")]
    private Transform player;
    private doorExit exit;
    private deliOrder order;

    private Transform doorSpawn;
    private Transform orderSpawn;
    
    [SerializeField]
    private bool entering;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager GameManagerReference = GameObject.FindObjectOfType<GameManager>();
        entering = !GameManagerReference.is2DSubwayDone;

        player = GameObject.Find("Player").transform;
        exit = GameObject.Find("doorSpot").GetComponent<doorExit>();
        order = GameObject.Find("orderSpot").GetComponent<deliOrder>();

        doorSpawn = GameObject.Find("doorSpawn").transform;
        orderSpawn = GameObject.Find("orderSpawn").transform;

        if (entering)
        {
            player.position = doorSpawn.position;
            player.rotation = doorSpawn.rotation;

            exit.canExit = false;
            order.canOrder = true;
        }
        else
        {
            player.position = orderSpawn.position;
            player.rotation = orderSpawn.rotation;

            exit.canExit = true;
            order.canOrder = false;
        }
    }

}
