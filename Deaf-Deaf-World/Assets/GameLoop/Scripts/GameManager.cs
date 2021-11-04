using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;
    public  GameObject CheckListPanel;

    public  GameObject instructionsObject;

    public  TaskList_SO taskListSOReference;

    public bool isSubwayDone = false;
    public bool isFireAlarmDone = false;
    public bool isTravelAgencyDone = false;

    private void Awake()
    {
        gameManagerInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        //SetSceneElements();
        GameEvents.current.onSubwayGameTriggerEnter += OnSubwayEnter;
        GameEvents.current.onSubwayGameTriggerExit += OnSubwayExit;
        GameEvents.current.onSubwayGameTriggerStart += OnSubwayStart;
        GameEvents.current.onSubwayGameTriggerEnd += OnSubwayEnd;

        GameEvents.current.onFireAlarmGameTriggerEnter += OnFireAlarmEnter;
        GameEvents.current.onFireAlarmGameTriggerExit += OnFireAlarmExit;
        GameEvents.current.onFireAlarmGameTriggerStart += OnFireAlarmStart;
        GameEvents.current.onFireAlarmGameTriggerEnd += OnFireAlarmEnd;


        GameEvents.current.onTravelAgencyTriggerEnter += OnTravelAgencyEnter;
        GameEvents.current.onTravelAgencyTriggerExit += OnTravelAgencyExit;
        GameEvents.current.onTravelAgencyTriggerStart += OnTravelAgencyStart;
        GameEvents.current.onTravelAgencyTriggerEnd += OnTravelAgencyEnd;
    }


    // Update is called once per frame
    void Update()
    {

    }


    //void SetSceneElements()
    //{
    //    for (int i = 0; i < CheckListPanel.transform.childCount; i++)
    //    {
    //        Transform temp = CheckListPanel.transform.GetChild(i);
    //        if (i < taskListSOReference.tasks.Count)
    //        {

    //            print(temp.name);
    //            temp.name = taskListSOReference.tasks[i].ToString();
    //            temp.transform.GetComponentInChildren<TextMeshProUGUI>().text = taskListSOReference.tasks[i].ToString();
    //        }
    //        else
    //        {
    //            temp.gameObject.SetActive(false);
    //        }
    //    }
    //}

    #region SubwayGame Functions
    void OnSubwayEnter()
    {
        print("Subway Enter Event");
        instructionsObject.gameObject.SetActive(true);
    }
    void OnSubwayExit()
    {
        print("Subway Exit Event");
        instructionsObject.gameObject.SetActive(false);
    }

    void OnSubwayStart()
    {
        print("Subway Event start");
        instructionsObject.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    void OnSubwayEnd()
    {
        isSubwayDone = true;
        SceneManager.LoadScene(0);
        print("Subway Event done");
    }

    #endregion

    #region FireAlarmGame Functions
    void OnFireAlarmEnter()
    {
        print("FireAlarm Enter Event");
        instructionsObject.gameObject.SetActive(true);
    }
    void OnFireAlarmExit()
    {
        print("FireAlarm Exit Event");
        instructionsObject.gameObject.SetActive(false);
    }

    void OnFireAlarmStart()
    {
        print("FireAlarm Event start");
        instructionsObject.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    void OnFireAlarmEnd()
    {
        isFireAlarmDone = true;
        SceneManager.LoadScene(0);
        print("FireAlarm Event done");
    }

    #endregion


    #region Travel Agency Game Functions
    void OnTravelAgencyEnter()
    {
        print("Travel Agency Enter Event");
        instructionsObject.gameObject.SetActive(true);
    }

    void OnTravelAgencyExit()
    {
        print("Travel Agency Exit Event");
        instructionsObject.gameObject.SetActive(false);
    }

    void OnTravelAgencyStart()
    {
        print("Travel Agency Event start");
        instructionsObject.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    void OnTravelAgencyEnd()
    {
        isTravelAgencyDone = true;
        SceneManager.LoadScene(0);
        print("Travel Agency Event done");

    }

    #endregion




}
