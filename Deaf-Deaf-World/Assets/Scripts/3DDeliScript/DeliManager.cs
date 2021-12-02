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

    private int frame = 0;

    private void Start()
    {
        frame = 0;
    }

    private void Awake()
    {
        frame = 0;
    }

    private void Update()
    {
        if (frame == 1)
        {
            setUp();
        }
        frame++;
    }

    // Start is called before the first frame update
    void setUp()
    {
        GameManager GameManagerReference = GameObject.FindObjectOfType<GameManager>();
        entering = !GameManagerReference.is2DSubwayDone;
        print("Debug entering: " + entering);
        print("Debug GameManagerReference: " + GameManagerReference.is2DSubwayDone);

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
