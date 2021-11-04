using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ToggleTasklist : MonoBehaviour
{
    public static ToggleTasklist toggleTasklistInstance;

    public KeyCode _key;

    GameObject taskButton;

    [SerializeField]
    GameObject CheckListPanel;

    [SerializeField]
    GameObject instructionsObject;

    [SerializeField]
    TaskList_SO TaskList_SO_Reference;

    [SerializeField]
    GameManager GameManagerReference;

    private void Awake()
    {
        taskButton = this.gameObject;
        GameManagerReference = GameObject.FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        print("Passing all the references to Game Manager");
        SetSceneElements();
        GameManagerReference.CheckListPanel = CheckListPanel;
        GameManagerReference.instructionsObject = instructionsObject;
        GameManagerReference.taskListSOReference = TaskList_SO_Reference;
        CheckIfGameOver();
    }

    void CheckIfGameOver()
    {
        // if (GameManagerReference.isSubwayDone && GameManagerReference.isTravelAgencyDone && GameManagerReference.isFireAlarmDone)
        if (GameManagerReference.isTravelAgencyDone && GameManagerReference.isFireAlarmDone)
        {
            instructionsObject.SetActive(true);
            instructionsObject.GetComponentInChildren<TextMeshProUGUI>().text = "GAMEOVER!!!";
            Time.timeScale = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            if (!taskButton.GetComponent<Image>().enabled)
            {
                CheckListPanel.SetActive(false);
                taskButton.GetComponent<Image>().enabled = true;
            }
            else
            {
                taskButton.GetComponent<Image>().enabled = false;
                CheckListPanel.SetActive(true);
            }
        }
    }
    void SetSceneElements()
    {


        int numberOfTasks = 0;

        for (int i = 0; i < CheckListPanel.transform.childCount; i++)
        {
            Transform temp = CheckListPanel.transform.GetChild(i);
            if (!GameManagerReference.isTravelAgencyDone)
            { numberOfTasks = 1; }
            else
            {
                numberOfTasks = 2;
            }
            //if (i < TaskList_SO_Reference.tasks.Count)
            if (i < numberOfTasks)
            {

                print(temp.name);
                temp.name = TaskList_SO_Reference.tasks[i].tasksName.ToString();
                temp.transform.GetComponentInChildren<TextMeshProUGUI>().text = TaskList_SO_Reference.tasks[i].tasksName.ToString();


                if (GameManagerReference.isSubwayDone && TaskList_SO_Reference.tasks[i].tasksName.ToString() == "Subway")
                {
                    temp.transform.GetComponentInChildren<Image>().color = Color.green;
                }
                else if (GameManagerReference.isTravelAgencyDone && TaskList_SO_Reference.tasks[i].tasksName.ToString() == "TravelAgency")
                {
                    temp.transform.GetComponentInChildren<Image>().color = Color.green;
                }
                else if (GameManagerReference.isFireAlarmDone && TaskList_SO_Reference.tasks[i].tasksName.ToString() == "MeetTheMayor")
                {
                    temp.transform.GetComponentInChildren<Image>().color = Color.green;
                }
                else
                {
                    print("Print nothing else");
                }
            }
            else
            {
                temp.gameObject.SetActive(false);
            }
        }
    }
}
