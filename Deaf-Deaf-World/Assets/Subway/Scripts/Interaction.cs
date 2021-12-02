using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

	public void Exit()
	{
        //Application.Quit();
        SceneManager.LoadScene("Subway3D");
    }
}
