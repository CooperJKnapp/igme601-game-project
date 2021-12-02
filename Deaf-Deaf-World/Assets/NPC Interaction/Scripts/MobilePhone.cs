using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.EventSystems;

public class MobilePhone : MonoBehaviour
{
    public static MobilePhone mobilePhoneInstance;

    [Header("Selected Messages References")]

    [SerializeField] Transform messagesContainer;

    [SerializeField]
    GameObject playerMessageBoxPrefab;

    [SerializeField]
    GameObject npcMessageBoxPrefab;

    [Header("Dialogue Selector References")]

    [SerializeField]
    NPC_Dialogues_SO dialoguesSObj;

    [SerializeField]
    Transform playerDialogueSelectContainer;

    [SerializeField]
    GameObject playerDialogueSelectBoxPrefab;

    [SerializeField]
    public List<GameObject> listOfCapsuleColliders;

    bool isPhoneOpen = false;

    private void Awake()
    {
        mobilePhoneInstance = this;
    }

    private void OnEnable()
    {
        isPhoneOpen = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnDisable()
    {
        isPhoneOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Unlock Cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    [SerializeField]
    int currentDialoguePlayerCount = 0;

    [SerializeField]
    int playerDialogueStage = 0;

    void MoveTheContentScrollView()
    {

        //Scroll up the scroll view
        messagesContainer.localPosition = new Vector3(messagesContainer.localPosition.x, desiredHeightChangeMessagesContainer + messagesContainer.localPosition.y, messagesContainer.localPosition.z);
        print("Y going up");
    }


    public void SetMobileIntialInteractionData()
    {
        //playerDialogueStage = 0;

        //foreach (Transform child in messagesContainer)
        //{
        //    GameObject.Destroy(child.gameObject);
        //}

        //foreach (Transform child in playerDialogueSelectContainer)
        //{
        //    GameObject.Destroy(child.gameObject);
        //}

        //currentDialoguePlayerCount = dialoguesSObj.firstPlayerDialogueList.Count;

        //for (int i = 0; i < currentDialoguePlayerCount; i++)
        //{
        //    var selectBoxItem = Instantiate(playerDialogueSelectBoxPrefab);

        //    selectBoxItem.GetComponent<Button>().onClick.AddListener(delegate { OnClickPlayerStage0DialogueChoice(); });

        //    selectBoxItem.GetComponent<MessageChoice>().dialogueBoxNumber = i;

        //    selectBoxItem.GetComponentInChildren<TextMeshProUGUI>().text = dialoguesSObj.firstPlayerDialogueList[i].playerDialogue;

        //    selectBoxItem.transform.SetParent(playerDialogueSelectContainer);

        //    selectBoxItem.transform.localScale = Vector2.one;
        //}

        playerDialogueStage = 0;

        messagesContainer.localPosition = new Vector3(messagesContainer.localPosition.x, 0, messagesContainer.localPosition.z);
        print("Resetting the scroll view");

        foreach (Transform child in messagesContainer)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in playerDialogueSelectContainer)
        {
            GameObject.Destroy(child.gameObject);
        }

        currentDialoguePlayerCount = dialoguesSObj.firstPlayerDialogueList.Count;

        for (int i = 0; i < currentDialoguePlayerCount; i++)
        {
            var selectBoxItem = Instantiate(playerDialogueSelectBoxPrefab);

            selectBoxItem.GetComponent<Button>().onClick.AddListener(delegate { OnClickPlayerStage0DialogueChoice(); });

            selectBoxItem.GetComponent<MessageChoice>().dialogueBoxNumber = i;

            selectBoxItem.GetComponentInChildren<TextMeshProUGUI>().text = dialoguesSObj.firstPlayerDialogueList[i].playerDialogue;

            selectBoxItem.transform.SetParent(playerDialogueSelectContainer);

            selectBoxItem.transform.localScale = Vector2.one;
        }

    }

    [SerializeField]
    float desiredHeightChangeMessagesContainer;

    void OnClickPlayerStage0DialogueChoice()
    {
        foreach (Transform child in playerDialogueSelectContainer)
        {
            GameObject.Destroy(child.gameObject);
        }

        if (playerDialogueStage == 0)
        {
            //Send Player's message
            var playerMessageItem = Instantiate(playerMessageBoxPrefab);
            // do something with the instantiated item -- for instance
            playerMessageItem.GetComponentInChildren<TextMeshProUGUI>().text = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
            //parent the item to the content container
            playerMessageItem.transform.SetParent(messagesContainer);
            //reset the item's scale -- this can get munged with UI prefabs
            playerMessageItem.transform.localScale = Vector2.one;

            StartCoroutine(npcStage0Replies());
        }

    }

    IEnumerator npcStage0Replies()
    {
        //yield return new WaitForSeconds(1.5f);
        ////Recieve NPC 1st Reply

        //var npcReply1 = Instantiate(npcMessageBoxPrefab);
        //// do something with the instantiated item -- for instance
        //npcReply1.GetComponentInChildren<TextMeshProUGUI>().text = dialoguesSObj.first1NpcDialogueList[UnityEngine.Random.Range(0, dialoguesSObj.first1NpcDialogueList.Count)].npcDialogue;

        ////parent the item to the content container
        //npcReply1.transform.SetParent(messagesContainer);
        ////reset the item's scale -- this can get munged with UI prefabs
        //npcReply1.transform.localScale = Vector2.one;



        //yield return new WaitForSeconds(1.5f);

        ////Recieve NPC 2nd Reply
        //var npcReply2 = Instantiate(npcMessageBoxPrefab);
        //// do something with the instantiated item -- for instance
        //npcReply2.GetComponentInChildren<TextMeshProUGUI>().text = dialoguesSObj.first2NpcDialogueList[UnityEngine.Random.Range(0, dialoguesSObj.first2NpcDialogueList.Count)].npcDialogue;

        //npcReply2.transform.SetParent(messagesContainer);
        ////reset the item's scale -- this can get munged with UI prefabs
        //npcReply2.transform.localScale = Vector2.one;


        //MoveTheContentScrollView();

        //yield return new WaitForSeconds(1.5f);

        //playerDialogueStage = 1;

        //SetStage1InteractionData();

        yield return new WaitForSeconds(1.5f);
        //Recieve NPC 1st Reply

        var npcReply1 = Instantiate(npcMessageBoxPrefab);
        // do something with the instantiated item -- for instance
        npcReply1.GetComponentInChildren<TextMeshProUGUI>().text = dialoguesSObj.first1NpcDialogueList[UnityEngine.Random.Range(0, dialoguesSObj.first1NpcDialogueList.Count)].npcDialogue;

        //parent the item to the content container
        npcReply1.transform.SetParent(messagesContainer);
        //reset the item's scale -- this can get munged with UI prefabs
        npcReply1.transform.localScale = Vector2.one;



        yield return new WaitForSeconds(1.5f);

        //Recieve NPC 2nd Reply
        var npcReply2 = Instantiate(npcMessageBoxPrefab);
        // do something with the instantiated item -- for instance
        npcReply2.GetComponentInChildren<TextMeshProUGUI>().text = dialoguesSObj.first2NpcDialogueList[UnityEngine.Random.Range(0, dialoguesSObj.first2NpcDialogueList.Count)].npcDialogue;

        npcReply2.transform.SetParent(messagesContainer);
        //reset the item's scale -- this can get munged with UI prefabs
        npcReply2.transform.localScale = Vector2.one;


        MoveTheContentScrollViewUp();

        yield return new WaitForSeconds(1.5f);

        playerDialogueStage = 1;

        SetStage1InteractionData();

    }

    /*
    void SetStage1InteractionData()
    {
        List<playerDialogues> allCurrentChoices = dialoguesSObj.secondPlayerDialogueList;

        List<string> allCurrentCs = new List<string>();

        foreach (playerDialogues playerDialogues in dialoguesSObj.secondPlayerDialogueList)
        {
            if (playerDialogues.playerDialogue.Contains("Deli") && PlayerPrefs.GetInt("SandwichChoiceDone") == 1)
                //allCurrentChoices.Find(playerDialogues.playerDialogue.Contains(""))
                allCurrentChoices.RemoveAt(allCurrentChoices.FindIndex(x => playerDialogues.playerDialogue.Contains("Deli")));

            if (playerDialogues.playerDialogue.Contains("Travel") && PlayerPrefs.GetInt("TravelAgencyChoiceDone") == 1)
                //allCurrentChoices.Find(playerDialogues.playerDialogue.Contains(""))
                allCurrentChoices.RemoveAt(allCurrentChoices.FindIndex(x => playerDialogues.playerDialogue.Contains("Travel")));

            if (playerDialogues.playerDialogue.Contains("Hall") && PlayerPrefs.GetInt("CityHallChoiceDone") == 1)
                //allCurrentChoices.Find(playerDialogues.playerDialogue.Contains(""))
                allCurrentChoices.RemoveAt(allCurrentChoices.FindIndex(x => playerDialogues.playerDialogue.Contains("Hall")));
        }

        // currentDialoguePlayerCount = dialoguesSObj.secondPlayerDialogueList.Count;
        currentDialoguePlayerCount = allCurrentChoices.Count;



        for (int i = 0; i < currentDialoguePlayerCount; i++)
        {
            var selectBoxItem = Instantiate(playerDialogueSelectBoxPrefab);

            selectBoxItem.GetComponent<Button>().onClick.AddListener(delegate { OnClickPlayerStage1DialogueChoice(); });

            selectBoxItem.GetComponent<MessageChoice>().dialogueBoxNumber = i;


            string DialogueCreationChoice = dialoguesSObj.secondPlayerDialogueList[i].playerDialogue;


            selectBoxItem.GetComponentInChildren<TextMeshProUGUI>().text = dialoguesSObj.secondPlayerDialogueList[i].playerDialogue;

            selectBoxItem.transform.SetParent(playerDialogueSelectContainer);

            selectBoxItem.transform.localScale = Vector2.one;
        }

        void OnClickPlayerStage1DialogueChoice()
        {
            foreach (Transform child in playerDialogueSelectContainer)
            {
                GameObject.Destroy(child.gameObject);
            }

            if (playerDialogueStage == 1)
            {
                //Send Player's message
                var playerMessageItem = Instantiate(playerMessageBoxPrefab);

                //Save the kind of choice that player chose for help
                string choice = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;

                if (choice.Contains("Deli"))
                {
                    PlayerPrefs.SetInt("SandwichChoiceDone", 1);
                }
                else if (choice.Contains("Travel"))
                {
                    PlayerPrefs.SetInt("TravelAgencyChoiceDone", 1);
                }
                else if (choice.Contains("Hall"))
                {
                    PlayerPrefs.SetInt("CityHallChoiceDone", 1);
                }

                // do something with the instantiated item -- for instance
                playerMessageItem.GetComponentInChildren<TextMeshProUGUI>().text = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;



                //parent the item to the content container
                playerMessageItem.transform.SetParent(messagesContainer);
                //reset the item's scale -- this can get munged with UI prefabs
                playerMessageItem.transform.localScale = Vector2.one;

                MoveTheContentScrollView();

                StartCoroutine(npcStage1Replies());
            }
        }

        IEnumerator npcStage1Replies()
        {
            yield return new WaitForSeconds(1.5f);

            //Recieve NPC 1st Reply

            var npcReply = Instantiate(npcMessageBoxPrefab);
            // do something with the instantiated item -- for instance
            npcReply.GetComponentInChildren<TextMeshProUGUI>().text = dialoguesSObj.secondNpcDialogueList[UnityEngine.Random.Range(0, dialoguesSObj.secondNpcDialogueList.Count)].npcDialogue;

            //parent the item to the content container
            npcReply.transform.SetParent(messagesContainer);
            //reset the item's scale -- this can get munged with UI prefabs
            npcReply.transform.localScale = Vector2.one;

            MoveTheContentScrollView();

            yield return new WaitForSeconds(1.5f);

            playerDialogueStage = 2;
            SetStage2InteractionData();
        }


        #region Dialogue Stage 2 code
        void SetStage2InteractionData()
        {
            currentDialoguePlayerCount = dialoguesSObj.thirdPlayerDialogueList.Count;

            for (int i = 0; i < currentDialoguePlayerCount; i++)
            {
                var selectBoxItem = Instantiate(playerDialogueSelectBoxPrefab);

                selectBoxItem.GetComponent<Button>().onClick.AddListener(delegate { OnClickPlayerStage2DialogueChoice(); });

                selectBoxItem.GetComponent<MessageChoice>().dialogueBoxNumber = i;

                selectBoxItem.GetComponentInChildren<TextMeshProUGUI>().text = dialoguesSObj.thirdPlayerDialogueList[i].playerDialogue;

                selectBoxItem.transform.SetParent(playerDialogueSelectContainer);

                selectBoxItem.transform.localScale = Vector2.one;
            }
        }

        void OnClickPlayerStage2DialogueChoice()
        {
            foreach (Transform child in playerDialogueSelectContainer)
            {
                GameObject.Destroy(child.gameObject);
            }

            if (playerDialogueStage == 2)
            {
                //Send Player's message
                var playerMessageItem = Instantiate(playerMessageBoxPrefab);
                // do something with the instantiated item -- for instance
                playerMessageItem.GetComponentInChildren<TextMeshProUGUI>().text = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
                //item_go.GetComponent<Image>().color = i % 2 == 0 ? Color.yellow : Color.cyan;
                //parent the item to the content container
                playerMessageItem.transform.SetParent(messagesContainer);
                //reset the item's scale -- this can get munged with UI prefabs
                playerMessageItem.transform.localScale = Vector2.one;

                MoveTheContentScrollView();

                StartCoroutine(npcStage2Replies());
            }
        }

        IEnumerator npcStage2Replies()
        {
            yield return new WaitForSeconds(1.5f);

            //Recieve NPC 1st Reply

            var npcReply = Instantiate(npcMessageBoxPrefab);
            // do something with the instantiated item -- for instance
            npcReply.GetComponentInChildren<TextMeshProUGUI>().text = dialoguesSObj.thirdNpcDialogueList[UnityEngine.Random.Range(0, dialoguesSObj.thirdNpcDialogueList.Count)].npcDialogue;

            //parent the item to the content container
            npcReply.transform.SetParent(messagesContainer);
            //reset the item's scale -- this can get munged with UI prefabs
            npcReply.transform.localScale = Vector2.one;

            MoveTheContentScrollView();

            yield return new WaitForSeconds(1.5f);

            //playerDialogueStage = 2;

            NPCInteract.NPCInteractInstance.ExitInteraction();
        }

        #endregion

        // Update is called once per frame
        void Update()
        {

        }


    }
    */
    public List<playerDialogues> allCurrentChoices;
    public List<string> allCurrentCs;
    bool deliDone, agencyDone, cityHallDone = false;
    void SetStage1InteractionData()
    {
        allCurrentChoices = new List<playerDialogues>();
        foreach (playerDialogues playerDialogues in dialoguesSObj.secondPlayerDialogueList)
        {
            allCurrentChoices.Add(playerDialogues);
        }

        allCurrentCs = new List<string>();

        foreach (playerDialogues playerDialogues in allCurrentChoices)
        {
            //if (playerDialogues.playerDialogue.Contains("Deli") && PlayerPrefs.GetInt("SandwichChoiceDone") == 1)
            //    //allCurrentChoices.Find(playerDialogues.playerDialogue.Contains(""))
            //    allCurrentChoices.RemoveAt(allCurrentChoices.FindIndex(x => playerDialogues.playerDialogue.Contains("Deli")));

            //if (playerDialogues.playerDialogue.Contains("Travel") && PlayerPrefs.GetInt("TravelAgencyChoiceDone") == 1)
            //    //allCurrentChoices.Find(playerDialogues.playerDialogue.Contains(""))
            //    allCurrentChoices.RemoveAt(allCurrentChoices.FindIndex(x => playerDialogues.playerDialogue.Contains("Travel")));

            //if (playerDialogues.playerDialogue.Contains("Hall") && PlayerPrefs.GetInt("CityHallChoiceDone") == 1)
            //    //allCurrentChoices.Find(playerDialogues.playerDialogue.Contains(""))
            //    allCurrentChoices.RemoveAt(allCurrentChoices.FindIndex(x => playerDialogues.playerDialogue.Contains("Hall")));

            if (playerDialogues.playerDialogue.Contains("Deli") && PlayerPrefs.GetInt("SandwichChoiceDone") != 1)
            {
                allCurrentCs.Add(playerDialogues.playerDialogue);
            }

            if (playerDialogues.playerDialogue.Contains("Travel") && PlayerPrefs.GetInt("TravelAgencyChoiceDone") != 1)
            {
                allCurrentCs.Add(playerDialogues.playerDialogue);
            }

            if (playerDialogues.playerDialogue.Contains("Hall") && PlayerPrefs.GetInt("CityHallChoiceDone") != 1)
            {
                allCurrentCs.Add(playerDialogues.playerDialogue);
            }

        }

        // currentDialoguePlayerCount = dialoguesSObj.secondPlayerDialogueList.Count;
        currentDialoguePlayerCount = allCurrentCs.Count;



        for (int i = 0; i < currentDialoguePlayerCount; i++)
        {
            var selectBoxItem = Instantiate(playerDialogueSelectBoxPrefab);

            selectBoxItem.GetComponent<Button>().onClick.AddListener(delegate { OnClickPlayerStage1DialogueChoice(); });

            selectBoxItem.GetComponent<MessageChoice>().dialogueBoxNumber = i;

            //selectBoxItem.GetComponentInChildren<TextMeshProUGUI>().text = dialoguesSObj.secondPlayerDialogueList[i].playerDialogue;
            selectBoxItem.GetComponentInChildren<TextMeshProUGUI>().text = allCurrentCs[i];

            selectBoxItem.transform.SetParent(playerDialogueSelectContainer);

            selectBoxItem.transform.localScale = Vector2.one;
        }
    }
    void MoveTheContentScrollViewUp()
    {
        //Scroll up the scroll view
        messagesContainer.localPosition = new Vector3(messagesContainer.localPosition.x, desiredHeightChangeMessagesContainer + messagesContainer.localPosition.y, messagesContainer.localPosition.z);
        print("Y going up");
    }
    void OnClickPlayerStage1DialogueChoice()
    {
        foreach (Transform child in playerDialogueSelectContainer)
        {
            GameObject.Destroy(child.gameObject);
        }

        if (playerDialogueStage == 1)
        {
            //Send Player's message
            var playerMessageItem = Instantiate(playerMessageBoxPrefab);

            //Save the kind of choice that player chose for help
            string choice = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;

            if (choice.Contains("Deli"))
            {
                PlayerPrefs.SetInt("SandwichChoiceDone", 1);
                OverworldGM.overworldGMInstance.SubwayTriggerArea.GetComponent<Outline>().enabled = true;
                deliDone = true;

                allCurrentCs.RemoveAt(allCurrentCs.FindIndex(x => x.Contains("Deli")));

            }
            else if (choice.Contains("Travel"))
            {
                PlayerPrefs.SetInt("TravelAgencyChoiceDone", 1);
                OverworldGM.overworldGMInstance.TravelAgencyTriggerArea.GetComponent<Outline>().enabled = true;
                agencyDone = true;
                allCurrentCs.RemoveAt(allCurrentCs.FindIndex(x => x.Contains("Travel")));
            }
            else if (choice.Contains("Hall"))
            {
                PlayerPrefs.SetInt("CityHallChoiceDone", 1);
                OverworldGM.overworldGMInstance.FireAlarmTriggerArea.GetComponent<Outline>().enabled = true;
                cityHallDone = true;
                allCurrentCs.RemoveAt(allCurrentCs.FindIndex(x => x.Contains("Hall")));
            }

            // do something with the instantiated item -- for instance
            playerMessageItem.GetComponentInChildren<TextMeshProUGUI>().text = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;



            //parent the item to the content container
            playerMessageItem.transform.SetParent(messagesContainer);
            //reset the item's scale -- this can get munged with UI prefabs
            playerMessageItem.transform.localScale = Vector2.one;

            MoveTheContentScrollViewUp();

            StartCoroutine(npcStage1Replies());
        }
    }

    IEnumerator npcStage1Replies()
    {
        yield return new WaitForSeconds(1.5f);

        //Recieve NPC 1st Reply

        var npcReply = Instantiate(npcMessageBoxPrefab);
        // do something with the instantiated item -- for instance
        npcReply.GetComponentInChildren<TextMeshProUGUI>().text = dialoguesSObj.secondNpcDialogueList[UnityEngine.Random.Range(0, dialoguesSObj.secondNpcDialogueList.Count)].npcDialogue;

        //parent the item to the content container
        npcReply.transform.SetParent(messagesContainer);
        //reset the item's scale -- this can get munged with UI prefabs
        npcReply.transform.localScale = Vector2.one;

        MoveTheContentScrollViewUp();

        yield return new WaitForSeconds(1.5f);

        playerDialogueStage = 2;
        SetStage2InteractionData();
    }


    #region Dialogue Stage 2 code
    void SetStage2InteractionData()
    {
        currentDialoguePlayerCount = dialoguesSObj.thirdPlayerDialogueList.Count;

        for (int i = 0; i < currentDialoguePlayerCount; i++)
        {
            var selectBoxItem = Instantiate(playerDialogueSelectBoxPrefab);

            selectBoxItem.GetComponent<Button>().onClick.AddListener(delegate { OnClickPlayerStage2DialogueChoice(); });

            selectBoxItem.GetComponent<MessageChoice>().dialogueBoxNumber = i;

            selectBoxItem.GetComponentInChildren<TextMeshProUGUI>().text = dialoguesSObj.thirdPlayerDialogueList[i].playerDialogue;

            selectBoxItem.transform.SetParent(playerDialogueSelectContainer);

            selectBoxItem.transform.localScale = Vector2.one;
        }
    }

    void OnClickPlayerStage2DialogueChoice()
    {
        foreach (Transform child in playerDialogueSelectContainer)
        {
            GameObject.Destroy(child.gameObject);
        }

        if (playerDialogueStage == 2)
        {
            //Send Player's message
            var playerMessageItem = Instantiate(playerMessageBoxPrefab);
            // do something with the instantiated item -- for instance
            playerMessageItem.GetComponentInChildren<TextMeshProUGUI>().text = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
            //item_go.GetComponent<Image>().color = i % 2 == 0 ? Color.yellow : Color.cyan;
            //parent the item to the content container
            playerMessageItem.transform.SetParent(messagesContainer);
            //reset the item's scale -- this can get munged with UI prefabs
            playerMessageItem.transform.localScale = Vector2.one;

            MoveTheContentScrollViewUp();

            StartCoroutine(npcStage2Replies());
        }
    }

    IEnumerator npcStage2Replies()
    {
        yield return new WaitForSeconds(1.5f);

        //Recieve NPC 1st Reply

        var npcReply = Instantiate(npcMessageBoxPrefab);
        // do something with the instantiated item -- for instance
        npcReply.GetComponentInChildren<TextMeshProUGUI>().text = dialoguesSObj.thirdNpcDialogueList[UnityEngine.Random.Range(0, dialoguesSObj.thirdNpcDialogueList.Count)].npcDialogue;

        //parent the item to the content container
        npcReply.transform.SetParent(messagesContainer);
        //reset the item's scale -- this can get munged with UI prefabs
        npcReply.transform.localScale = Vector2.one;

        MoveTheContentScrollViewUp();

        yield return new WaitForSeconds(1.5f);

        //playerDialogueStage = 2;

        NPCInteract.NPCInteractInstance.ExitInteraction();

        if (allCurrentCs.Count <= 0)
        {
            print("Done with all the npc interactions");
        }
    }

    #endregion

    void turnOFFcolliders()
    {
        foreach(GameObject g in listOfCapsuleColliders)
        {
            g.GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }



}
