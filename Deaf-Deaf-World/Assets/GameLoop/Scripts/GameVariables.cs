using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour
{
    public static GameVariables gameVariablesInstance;  //instance variable for class, since we would need to call this from other scripts
    
    public enum GameState
    {
        startGame,
        endOfGame,
        idle,
        dialogue,
        tasks,
        activity //Like FireAlarm
    }
    
    public enum Tasks  //enum of keeping track of task states
    {
        Subway,
        TravelAgency
    }

    public Tasks taskState;

    void Awake()
    {
        if (gameVariablesInstance == null)  //To check if instance already exists
            gameVariablesInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
