using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    GameManager refer;

    void Start()
    {
        refer = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

	public void Exit()
	{
        //Application.Quit();
        refer.is2DSubwayDone = true;
        SceneManager.LoadScene("Subway3D");
    }
}
