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
    
    public GameObject SubwayTriggerArea;

    public GameObject FireAlarmTriggerArea;

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


    private void OnEnable()
    {
        print(" Debug Overworld set again");
    }

    /*
    void CheckIfGameOver()
    {
        // if (GameManagerReference.isSubwayDone && GameManagerReference.isTravelAgencyDone && GameManagerReference.isFireAlarmDone)
        if (GameManagerReference.isTravelAgencyDone && GameManagerReference.isSubwayDone && GameManagerReference.isFireAlarmDone)
        {
            playerTransform.GetComponent<FirstPersonController>().canWalk = false;
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        wait = 0;
        //Check for closing the trigger areas, I know Hardcoded as F 

        if (GameManagerReference.isSubwayDone)
        {
            SubwayTriggerArea.SetActive(false);
        }

        if (GameManagerReference.isTravelAgencyDone)
        {
            TravelAgencyTriggerArea.SetActive(false);
        }

        if (GameManagerReference.isTravelAgencyDone && GameManagerReference.isSubwayDone)
        {
           // TravelAgencyTriggerArea.SetActive(false);
           FireAlarmTriggerArea.SetActive(true);
        }

        playerTransform.GetComponent<FirstPersonController>().enabled = false;
        ResetPos();

        //Check the Game if over and set the player's movement off
        //CheckIfGameOver();
    }

    private int wait;

    private void Update()
    {
        if (wait == 10)
        {
            //ResetPos();
            playerTransform.GetComponent<FirstPersonController>().enabled = true;
        }
        wait++;
        //print("player trans in the update: " + playerTransform.transform.position);
    }

    private void ResetPos()
    {

        //Check and set for Players exit position from the minigames to overworld
        if (GameManagerReference.resetThePlayerAfterTravelAgency)
        {
            //GameManagerReference.resetThePlayerAfterTravelAgency = false;
            SetPlayerAfterExitMinigame(GameVariables.Tasks.TravelAgency);
            print("Debug Checked reset and setplayer travel");
        }
        if (GameManagerReference.resetThePlayerAfterSandwichGame)
        {
            //GameManagerReference.resetThePlayerAfterSandwichGame = false;
            SetPlayerAfterExitMinigame(GameVariables.Tasks.Subway);
            print(" Debug Checked reset and setplayer sandwich");
        }
        if (GameManagerReference.resetThePlayerAfterFireAlarm)
        {
            //GameManagerReference.resetThePlayerAfterFireAlarm = false;
            SetPlayerAfterExitMinigame(GameVariables.Tasks.MeetTheMayor);
            print("Debug Checked reset and setplayer mayor");
        }

    }

    public void SetPlayerAfterExitMinigame(GameVariables.Tasks tasks)
    {
        switch (tasks)
        {
            case GameVariables.Tasks.TravelAgency:
                print("player trans before: " + playerTransform.transform.position);
                playerTransform.transform.position = travelAgencyExitPoint.transform.position;
                playerTransform.transform.rotation = Quaternion.Euler(playerTransform.transform.rotation.x, travelAgencyExitPoint.transform.localRotation.y, playerTransform.transform.rotation.z);
                print("debug position TA");
                print("player trans after: " + playerTransform.transform.position);
                break;
            case GameVariables.Tasks.Subway:
                playerTransform.transform.position = subwayGameExitPoint.transform.position;
                playerTransform.transform.rotation = Quaternion.Euler(playerTransform.transform.rotation.x, subwayGameExitPoint.transform.localRotation.y, playerTransform.transform.rotation.z);
                print("debug position DDD");
                break;
            case GameVariables.Tasks.MeetTheMayor:
                playerTransform.transform.position = fireAlarmExitPoint.transform.position;
                playerTransform.transform.rotation = Quaternion.Euler(playerTransform.transform.rotation.x, fireAlarmExitPoint.transform.localRotation.y, playerTransform.transform.rotation.z);
                break;
        }
    }
}
