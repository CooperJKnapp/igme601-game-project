using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireAlarmDialogue : MonoBehaviour {
    [Header("Dialogue Options")]
    [SerializeField]
    private List<string> dialogueText;
    private int currentLine;

    private CursorLockMode previousLockState;

    [Header("Object References")]
    [SerializeField]
    private GameObject fullDialogueBox;
    [SerializeField]
    private Text dialogueTextbox;
    [SerializeField]
    private GameObject continueText;
    [SerializeField]
    private GameObject deliveryObjective;
    [SerializeField]
    private FirstPersonController playerToLock;
    [SerializeField]
    private Animator mayorAnimator;

    private int waitFrames;

    // Start is called before the first frame update
    void Start() {
        currentLine = 0;
        fullDialogueBox.SetActive(false);
        waitFrames = 0;
    }

    // Update is called once per frame
    void Update() {
        if (waitFrames > 0) {
            waitFrames--;
            return;
        }

        if (Input.GetButtonDown("Fire1") && fullDialogueBox.activeInHierarchy) {
            NextLine();
        }
    }

    public void BeginDialogue() {
        // Lock the player
        playerToLock.enabled = false;
        previousLockState = Cursor.lockState;
        Cursor.lockState = CursorLockMode.Locked;

        // Begin dialogue
        dialogueTextbox.text = dialogueText[0];
        fullDialogueBox.SetActive(true);

        // Stand the Mayor up
        mayorAnimator.SetBool("Sitting", true);
        mayorAnimator.SetBool("standing", true);

        // Hide the delivery objective
        deliveryObjective.SetActive(false);

        // Set the wait frames
        waitFrames = 1;
    }

    private void NextLine() {
        // Return if dialogue is not currently active
        if(!fullDialogueBox.activeInHierarchy) {
            return;
        }

        // Increment line
        currentLine++;

        if (currentLine == dialogueText.Count - 1) {
            // Freeze the dialogue
            EndDialogue();
        }

        if (currentLine >= dialogueText.Count) {
            // Don't allow overflow
            currentLine--;
            return;
        }

        // Update textbox
        dialogueTextbox.text = dialogueText[currentLine];
    }

    public void EndDialogue() {
        // Disable continue text
        continueText.SetActive(false);
    }
}
