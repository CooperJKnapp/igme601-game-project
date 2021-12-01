using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayorDeliveryZone : MonoBehaviour {
    [SerializeField]
    private GameObject instructionsPopup;
    [SerializeField]
    private FireAlarmDialogue dialogueSystem;

    private bool playerInside;

    private void Start() {
        playerInside = false;
    }

    private void Update() {
        if(Input.GetButtonDown("Fire1") && playerInside) {
            // Start Mayor dialogue
            dialogueSystem.BeginDialogue();
            instructionsPopup.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("Player")) {
            instructionsPopup.SetActive(true);
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag.Equals("Player")) {
            instructionsPopup.SetActive(false);
            playerInside = false;
        }
    }
}
