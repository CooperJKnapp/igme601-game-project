using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestPlayerPrefs : MonoBehaviour
{
    public TextMeshProUGUI prefText;
    public TextMeshProUGUI currentText;
    int prefSceneInt;
    float prefSceneFloat;
    string prefSceneString;

    void Start()
    {
        prefSceneInt = PlayerPrefs.GetInt("SceneInt", 0);
        prefSceneFloat = PlayerPrefs.GetFloat("SceneFloat", 0.00f);
        prefSceneString = PlayerPrefs.GetString("SceneString", "Scene");

        prefText.text =  "Saved Int: " + prefSceneInt + "\nSaved Float: " + prefSceneFloat + "\nSaved String: " + prefSceneString;
    }

    public void SetInt(int n)
    {
        prefSceneInt = n;
        PlayerPrefs.SetInt("SceneInt", prefSceneInt);
    }

    public void SetFloat(float n)
    {
        prefSceneFloat = n;
        PlayerPrefs.SetFloat("SceneFloat", prefSceneFloat);
    }

    public void SetString(string n)
    {
        prefSceneString = n;
        PlayerPrefs.SetString("SceneString", prefSceneString);
    }

    private void Update()
	{
        currentText.text = "Current Int: " + prefSceneInt + "\nCurrent Float: " + prefSceneFloat + "\nCurrent String: " + prefSceneString;
    }
}
