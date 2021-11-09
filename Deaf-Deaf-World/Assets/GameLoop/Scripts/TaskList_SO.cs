using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="TaskList Object", menuName ="Scriptable Objects/TaskList")]
public class TaskList_SO : ScriptableObject
{
    [Header("Set a list of tasks")]
    public List<Task> tasks;
}
