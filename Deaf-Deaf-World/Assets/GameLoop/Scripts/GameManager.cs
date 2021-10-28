using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject CheckListPanel;
    
    
    [SerializeField]
    TaskList_SO taskListSOReference;



    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {

        //for (int i = 0; i < taskListSOReference.tasks.Count;i++)
        //{
        //    print(taskListSOReference.tasks[i].ToString());
        //}

        EventManager.Instance.AddListener<SubwayGameEvent>(OnSubwayGameEnd);
        //EventManager.Instance.AddListener<TravelAgencyGameEvent>(OnTravelAgencyEnd);

        SetSceneElements();
        StartCoroutine("triggerE",5f);
    }


    //Test event trigger
    IEnumerator triggerE(float t)
    {
        print("started corouitne");
        yield return new WaitForSeconds(t);
         SubwayGameEvent SubEvent = new SubwayGameEvent();
        OnSubwayGameEnd(SubEvent);
        print("Triggered Event");
    }
    
    //

    // Update is called once per frame
    void Update()
    {
        
    }


    void SetSceneElements()
    {
        for (int i = 0; i < CheckListPanel.transform.childCount; i++)
        {
            Transform temp = CheckListPanel.transform.GetChild(i);
            if (i< taskListSOReference.tasks.Count)
            {
                
                print(temp.name);
                temp.name = taskListSOReference.tasks[i].ToString();
                temp.transform.GetComponentInChildren<TextMeshProUGUI>().text = taskListSOReference.tasks[i].ToString();
            }
            else
            {
                temp.gameObject.SetActive(false);
            }
        }
    }

    void OnSubwayGameStart()
    {

    }

    void OnSubwayGameEnd(SubwayGameEvent info)
    {

        print("Subway Event done");
        EventManager.Instance.QueueEvent(info);
    }
    void OnTravelAgencyStart()
    {

    }

    void OnTravelAgencyEnd(TravelAgencyGameEvent info)
    {
        print("Travel Agency Event done");
    }

}
