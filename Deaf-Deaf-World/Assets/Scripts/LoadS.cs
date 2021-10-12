using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadS : MonoBehaviour
{
    public void SceneLoad(int l)
    {
        SceneManager.LoadScene(l);
    }
}
