using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;


public class NPCInteract : MonoBehaviour
{
    public static NPCInteract NPCInteractInstance;

    [SerializeField]
    TextMeshProUGUI interactionInstructionText;

    public bool isNPCinteractable = false;

    public KeyCode npcInteractKey;

    [SerializeField]
    Collision tempCollision;

    private void Awake()
    {
        NPCInteractInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(npcInteractKey) && isNPCinteractable)
        {
            print("Hellow");
            print("Open Mobile phone");
            //Stop the player movement

            FirstPersonController.canMove = false;
            // Stop the NPC movement
            ///tempCollision.gameObject.GetComponent<NavMeshAgent>().speed = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            interactionInstructionText.gameObject.SetActive(true);
            isNPCinteractable = true;
            tempCollision = collision;
            print("NPC Enter collider");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            interactionInstructionText.gameObject.SetActive(false);
            isNPCinteractable = false;
            tempCollision = null;
            print("NPC Exit collider");
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("NPC"))
    //    {
    //        if (Input.GetKeyDown(npcInteractKey))
    //        {
    //            print("Open Mobile phone");
    //           // Stop the player movement
    //           // Stop the NPC movement
    //           // collision.gameObject.GetComponent<NPCMovement>();
    //        }
    //    }
    //}


    private void OnMouseDown()
    {

    }


}
