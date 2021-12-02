using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;


public class NPCInteract : MonoBehaviour
{
    public static NPCInteract NPCInteractInstance;

    public bool isNPCinteractable = false;

    public KeyCode npcInteractKey;

    [SerializeField]
    GameObject MobileBody;

    [SerializeField]
    GameObject interactionInstructionText;

    [SerializeField]
    float TimeForMobileInstructions;

    Collider tempCollider;

    private void Awake()
    {
        NPCInteractInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(npcInteractKey) && isNPCinteractable)
        {
            StartInteraction();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            if (!other.gameObject.transform.GetComponentInParent<NPCData>().isAlreadyInteractedWith)
            {
                interactionInstructionText.SetActive(true);
                isNPCinteractable = true;
                tempCollider = other;
                print("NPC TriggerEnter collider");
            }
        }
    }

    private void OnTriggerExit(Collider other) //This condition happens when NPC interaction starts and isKinematic is turned true which makes the whole Collider trigger Exit
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            //Remove the instruction text
            interactionInstructionText.SetActive(false);
            tempCollider = null;
            print("NPC Exit collider");
        }
    }

    void StartInteraction()
    {



        //Set interactable bools
        isNPCinteractable = false;
        tempCollider.gameObject.transform.GetComponentInParent<NPCData>().isAlreadyInteractedWith = true;

        // Stop the NPC movement
        print("tempcollider " + tempCollider.gameObject.name);
        tempCollider.gameObject.transform.GetComponentInParent<Rigidbody>().isKinematic = true;

        //Stop the player movement
        //FirstPersonController.canMove = false;
        GameObject tempObj= GameObject.Find("Player");
        tempObj.GetComponent<FirstPersonController>().InteractableCanMove = false;
        
        //Open Phone
        print("Open Mobile phone");
        MobileBody.SetActive(true);

        //Set all the data for the mobile interface
        MobilePhone.mobilePhoneInstance.SetMobileIntialInteractionData();

    }

    IEnumerator showInstructionsForMobileInterface()
    {


        yield return new WaitForSeconds(4f);
        
    }
   


    public void ExitInteraction()
    {
        //Close the mobile
        MobileBody.SetActive(false);

        //Start the player movement again
        GameObject tempObj = GameObject.Find("Player");
        tempObj.GetComponent<FirstPersonController>().InteractableCanMove = true;

        // Stop the NPC movement **UPDATE** This code will not work now, because the tempcollider becomes null after setting the npc collider to isKinematic
        // print("tempcollider "+tempCollider.gameObject.name);
        //tempCollider.gameObject.transform.GetComponentInParent<Rigidbody>().isKinematic = false;

    }


}
