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
    GameObject SubwayTriggerArea;

    [SerializeField]
    GameObject FireAlarmTriggerArea;

    [SerializeField]
    GameObject TravelAgencyTriggerArea;

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
        }
       // if (PlayerPrefs.GetInt("isOnboardingDone") == 1)
       else
        {
            print("TurnOff the Onboarding");
            Mayor.SetActive(false);
            Onboarding.SetActive(false);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManagerReference.isTravelAgencyDone)
        {
            TravelAgencyTriggerArea.SetActive(false);
            FireAlarmTriggerArea.SetActive(true);
        }



        //if (GameManagerReference.isTravelAgencyDone && GameManagerReference.isSubwayDone)
        //{
        //    FireAlarmTriggerArea.SetActive(true);
        //}
        //else
        //{
        //    if (GameManagerReference.isSubwayDone)
        //    {
        //        SubwayTriggerArea.SetActive(false);
        //    }
        //    else if (GameManagerReference.isFireAlarmDone)
        //    {
        //        FireAlarmTriggerArea.SetActive(false);
        //    }
        //    else if (GameManagerReference.isTravelAgencyDone)
        //    {
        //        TravelAgencyTriggerArea.SetActive(false);
        //    }
        //}

        if (GameManagerReference.xyz)
        {
            SetPlayerAfterExitMinigame(GameVariables.Tasks.TravelAgency);
        }

    }

    IEnumerator twosecwait(float af)
    {
        yield return new WaitForSeconds(af);
        playerTransform.transform.position = new Vector3(0, 0, 0);
    }

    public void SetPlayerAfterExitMinigame(GameVariables.Tasks tasks)
    {
        switch (tasks)
        {
            case GameVariables.Tasks.TravelAgency:
                print("Switch case");
                playerTransform.transform.position = travelAgencyExitPoint.transform.localPosition;
                //playerTransform.transform.rotation = Quaternion.Euler(playerTransform.transform.rotation.x, travelAgencyExitPoint.transform.localRotation.y, playerTransform.transform.rotation.z);
                break;
            case GameVariables.Tasks.Subway:
                playerTransform.transform.position = subwayGameExitPoint.transform.localPosition;
                playerTransform.transform.rotation = subwayGameExitPoint.transform.localRotation;
                break;
            case GameVariables.Tasks.MeetTheMayor:
                playerTransform.transform.position = fireAlarmExitPoint.transform.localPosition;
                playerTransform.transform.rotation = fireAlarmExitPoint.transform.localRotation;
                break;
        }
    }
}
