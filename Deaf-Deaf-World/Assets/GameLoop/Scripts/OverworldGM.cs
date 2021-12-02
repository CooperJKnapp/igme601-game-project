using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldGM : MonoBehaviour
{
    public static OverworldGM overworldGMInstance;

    [Header("Onboarding Object Reference")]

    [SerializeField]
    GameObject Onboarding;

    [SerializeField]
    GameObject Mayor;

    [SerializeField]
    GameObject playerTransform;

    [Header("Game Manager Reference")]

    [SerializeField]
    GameManager GameManagerReference;

    [Header("Trigger Area Objects References")]
    [SerializeField]
    public GameObject SubwayTriggerArea;

    [SerializeField]
    public GameObject FireAlarmTriggerArea;

    [SerializeField]
    public GameObject TravelAgencyTriggerArea;

    [Header("Exit Point References")]

    [SerializeField]
    GameObject travelAgencyExitPoint;

    [SerializeField]
    GameObject subwayGameExitPoint;

    [SerializeField]
    GameObject fireAlarmExitPoint;

    private void Awake()
    {
        overworldGMInstance = this;
        GameManagerReference = GameObject.FindObjectOfType<GameManager>();

        if (!PlayerPrefs.HasKey("isOnboardingDone")){
            PlayerPrefs.SetInt("isOnboardingDone", 1);
            print("Onboarding PlayerPref set");
        }
        else
        {
            print("TurnOff the Onboarding");
            Mayor.SetActive(false);
            Onboarding.SetActive(false);
        }
    }

    void CheckIfGameOver()
    {
        // if (GameManagerReference.isSubwayDone && GameManagerReference.isTravelAgencyDone && GameManagerReference.isFireAlarmDone)
        if (GameManagerReference.isTravelAgencyDone && GameManagerReference.isFireAlarmDone)
        {
            playerTransform.GetComponent<FirstPersonController>().canWalk = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Check for closing the trigger areas, I know Hardcoded as F 
        if (GameManagerReference.isTravelAgencyDone)
        {
            TravelAgencyTriggerArea.SetActive(false);
            FireAlarmTriggerArea.SetActive(true);
        }

        //Check and set for Players exit position from the minigames to overworld
        if (GameManagerReference.resetThePlayerAfterTravelAgency)
        {
            GameManagerReference.resetThePlayerAfterTravelAgency = false;
            SetPlayerAfterExitMinigame(GameVariables.Tasks.TravelAgency);
        }
        if (GameManagerReference.resetThePlayerAfterSandwichGame)
        {
            GameManagerReference.resetThePlayerAfterSandwichGame = false;
            SetPlayerAfterExitMinigame(GameVariables.Tasks.Subway);
        }
        if (GameManagerReference.resetThePlayerAfterFireAlarm)
        {
            GameManagerReference.resetThePlayerAfterFireAlarm = false;
            SetPlayerAfterExitMinigame(GameVariables.Tasks.MeetTheMayor);
        }

        //Check the Game if over and set the player's movement off
        CheckIfGameOver();
    }

    public void SetPlayerAfterExitMinigame(GameVariables.Tasks tasks)
    {
        switch (tasks)
        {
            case GameVariables.Tasks.TravelAgency:
                playerTransform.transform.position = travelAgencyExitPoint.transform.position;
                playerTransform.transform.rotation = Quaternion.Euler(playerTransform.transform.rotation.x, travelAgencyExitPoint.transform.localRotation.y, playerTransform.transform.rotation.z);
                print("Travel agency set");
                break;
            case GameVariables.Tasks.Subway:
                playerTransform.transform.position = subwayGameExitPoint.transform.position;
                playerTransform.transform.rotation = Quaternion.Euler(playerTransform.transform.rotation.x, subwayGameExitPoint.transform.localRotation.y, playerTransform.transform.rotation.z);
                break;
            case GameVariables.Tasks.MeetTheMayor:
                playerTransform.transform.position = fireAlarmExitPoint.transform.position;
                playerTransform.transform.rotation = Quaternion.Euler(playerTransform.transform.rotation.x, fireAlarmExitPoint.transform.localRotation.y, playerTransform.transform.rotation.z);
                break;
        }
    }
}
