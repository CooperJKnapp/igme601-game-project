using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "NPC_Dialogues Object", menuName = "Scriptable Objects/NPC_Dialogues")]
public class NPC_Dialogues_SO : ScriptableObject
{
    [Header("First Dialogue list")]
    public List<playerDialogues> firstPlayerDialogueList;
    public List<NPCDialogues> first1NpcDialogueList;
    public List<NPCDialogues> first2NpcDialogueList;


    [Header("Second Dialogue list")]
    public List<playerDialogues> secondPlayerDialogueList;
    public List<NPCDialogues> secondNpcDialogueList;

    [Header("First Dialogue list")]
    public List<playerDialogues> thirdPlayerDialogueList;
    public List<NPCDialogues> thirdNpcDialogueList;

}

[Serializable]
public class playerDialogues
{
    public string playerDialogue;
}

[Serializable]
public class NPCDialogues
{
    public string npcDialogue;
}
