using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardingManager : MonoBehaviour
{
    private int onboardingStage;
    /* 0 = waiting for movement controls
     * 1 = showing movement controls, waiting for movement input
     * 2 = showing look controls, waiting for look input
     * 3 = showing "Go meet the mayor", waiting to pass under DDW sign
     * 4 = mayor dialogue
     */

    // Multi-stage
    private float waitingTimer;

    // Stage 0
    [Header("Stage 0")]
    [SerializeField]
    private float timeToWaitBeforeControlsPrompt;

    // Stage 1
    [Header("Stage 1")]
    [SerializeField]
    private GameObject movementControlsPopup;
    private bool horizontalPosCheck;
    private bool horizontalNegCheck;
    private bool verticalPosCheck;
    private bool verticalNegCheck;
    private bool FullMovementCheck
    {
        get
        {
            return (horizontalPosCheck && horizontalNegCheck && verticalPosCheck && verticalNegCheck);
        }
    }
    [SerializeField]
    private float timeToWaitBeforeLookPrompt;

    // Stage 2
    [Header("Stage 2")]
    [SerializeField]
    private GameObject lookingControlsPopup;
    [SerializeField]
    private float timeToWaitBeforeMayorActive;
    private bool lookingCheck;

    // Stage 3
    [Header("Stage 3")]
    [SerializeField]
    private GameObject meetTheMayorPopup;
    [SerializeField]
    private OnboardingMayorHitbox mayorHitbox;
    [SerializeField]
    private Outline mayorOutline;

    // Stage 4
    [Header("Stage 4")]
    [SerializeField]
    private OnboardingDialogue introductionDialogue;

    // Stage Finish
    [Header("Stage Finish")]
    [SerializeField]
    private Outline travelAgencyOutline;
    [SerializeField]
    private GameObject theMayor;
    [SerializeField]
    private MayorMovement mayorMovement;

    // Start is called before the first frame update
    void Start()
    {
        mayorMovement = GameObject.Find("Mayor").GetComponent<MayorMovement>();
        mayorMovement.enabled = false;
        print("Onboarding start");
        // Multi-stage
        onboardingStage = 0;

        // Stage 0
        waitingTimer = timeToWaitBeforeControlsPrompt;

        // Stage 1
        horizontalPosCheck = false;
        horizontalNegCheck = false;
        verticalPosCheck = false;
        verticalNegCheck = false;

        // Stage 2
        lookingCheck = false;

        // Stage 3

        // Stage 4
    }

    // Update is called once per frame
    void Update()
    {
        switch (onboardingStage)
        {
            case 0:
                // Waiting for movement controls
                waitingTimer -= Time.deltaTime;
                if (waitingTimer <= 0.0f)
                {
                    // Init Stage 1
                    onboardingStage++;
                    movementControlsPopup.SetActive(true);
                }
                break;

            case 1:
                if (FullMovementCheck)
                {
                    // Wait till look prompt
                    waitingTimer -= Time.deltaTime;
                    if (waitingTimer <= 0.0f)
                    {
                        // Init Stage 2
                        onboardingStage++;
                        movementControlsPopup.SetActive(false);
                        lookingControlsPopup.SetActive(true);
                    }
                }
                else
                {
                    // Check control inputs
                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        horizontalPosCheck = true;
                    }

                    if (Input.GetAxis("Horizontal") < 0)
                    {
                        horizontalNegCheck = true;
                    }

                    if (Input.GetAxis("Vertical") > 0)
                    {
                        verticalPosCheck = true;
                    }

                    if (Input.GetAxis("Vertical") < 0)
                    {
                        verticalNegCheck = true;
                    }

                    if (FullMovementCheck)
                    {
                        // Init countdown timer
                        waitingTimer = timeToWaitBeforeLookPrompt;
                    }
                }
                break;

            case 2:
                if (lookingCheck)
                {
                    // Wait till timer out
                    waitingTimer -= Time.deltaTime;
                    if (waitingTimer <= 0.0f)
                    {
                        // Init Stage 3
                        onboardingStage++;
                        lookingControlsPopup.SetActive(false);
                        meetTheMayorPopup.SetActive(true);
                        mayorHitbox.Activate();
                        mayorOutline.enabled = true;
                    }
                }
                else
                {
                    // Check mouse inputs
                    if (Input.GetAxis("Mouse X") != 0.0f || Input.GetAxis("Mouse Y") != 0.0f)
                    {
                        // Set lookingCheck
                        lookingCheck = true;

                        // Init countdown timer
                        waitingTimer = timeToWaitBeforeMayorActive;
                    }
                }
                break;

            case 3:
                // Handled by OnboardingManager.AdvanceStage3();
                break;

            case 4:
                // Handled by OnboardingManager.AdvanceStage4();
                break;
        }
    }

    public void AdvanceStage3()
    {
        if (onboardingStage != 3)
        {
            return;
        }
        else
        {
            // Init stage 4
            onboardingStage++;
            meetTheMayorPopup.SetActive(false);
            mayorOutline.enabled = false;
            introductionDialogue.BeginDialogue();
        }
    }

    public void AdvanceStage4()
    {
        if (onboardingStage != 4)
        {
            return;
        }
        else
        {
            // Init stage finish
            onboardingStage++;
            //travelAgencyOutline.enabled = true;
            mayorMovement.enabled = true;
        }
    }
}
