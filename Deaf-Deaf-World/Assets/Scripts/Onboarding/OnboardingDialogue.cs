using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnboardingDialogue : MonoBehaviour {
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
    private FirstPersonController playerToLock;
    [SerializeField]
    private OnboardingManager onboardingManager;

    // Start is called before the first frame update
    void Start() {
        currentLine = 0;
        fullDialogueBox.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown("Fire1") && fullDialogueBox.activeInHierarchy) {
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
    }

    private void NextLine() {
        // Return if dialogue is not currently active
        if(!fullDialogueBox.activeInHierarchy) {
            return;
        }

        // Increment line
        currentLine++;

        if(currentLine >= dialogueText.Count) {
            // End dialogue if at end of the line
            EndDialogue();
            return;
        }

        // Update textbox
        dialogueTextbox.text = dialogueText[currentLine];
    }

    public void EndDialogue() {
        // Unlock the player
        playerToLock.enabled = true;
        Cursor.lockState = previousLockState;

        // End dialogue
        fullDialogueBox.SetActive(false);
        onboardingManager.AdvanceStage4();
    }
}
